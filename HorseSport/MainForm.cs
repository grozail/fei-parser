using HorseSport.Data;
using HorseSport.Parser.Core;
using HorseSport.Parser.Model;
using HorseSport.Parser.Model.Event;
using HorseSport.Parser.Model.Event.Properties;
using HorseSport.Parser.Model.Living;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HorseSport {
	public partial class MainForm : Form {
		private static Logger logger = LogManager.GetCurrentClassLogger();

		public MainForm() {
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e) {
			AppState.Init();
			openFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "sources");
			JudgeManager.LoadData();
			foreach (var value in JudgeManager.Data.Values) {
				judgeBindingSource.Add(value);
			}
			judgeGridView.DataSource = judgeBindingSource;
			logger.Info("Judges data loaded");
		}

		private void usePrizesCheckBox_CheckedChanged(object sender, EventArgs e) {
			if (usePrizesCheckBox.Checked) {
				currencyTextBox.Visible = true;
			}
			else {
				currencyTextBox.Visible = false;
			}
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e) {
			if(openFileDialog.ShowDialog() == DialogResult.OK) {
				foreach (var fileName in openFileDialog.FileNames) {
					if (fileName.EndsWith(".xlsx")) {
						foreach (var competition in GeneralParser.Parse(fileName)) {
							competitionBindingSource.Add(competition);
						}
						competitionGridView.Update();
					}
					else if (fileName.EndsWith(".csv")) {
						InfoManager.LoadData(fileName);
						foreach (var eventInfo in InfoManager.Data) {
							infoBindingSource.Add(eventInfo);
						}
						infoGridView.Update();
					}
				}
			}
		}

		private void bindInfoCompetition_Click(object sender, EventArgs e) {
			var cRows = competitionGridView.SelectedRows;
			var iRows = infoGridView.SelectedRows;
			if (cRows.Count == 1 && iRows.Count == 1) {
				var competition = cRows[0].DataBoundItem as Competition;
				Description description = new Description();
				foreach (DataGridViewRow item in judgeGridView.Rows) {
					var checkCell = (item.Cells["Column7"] as DataGridViewCheckBoxCell);
					if (checkCell != null && checkCell.Value != null && (bool)checkCell.Value) {
						description.Jury.Add(item.DataBoundItem as Judge);
					}
				}
				if (usePrizesCheckBox.Checked) {
					description.Prizes = new Prizes(currencyTextBox.Text.ToUpper());
				}
				logger.Info("Description formed");
				competition.Description = description;
				
				var eInfo = iRows[0].DataBoundItem as EventInfo;
				competition.FEIID = eInfo.CompetitionID;
				competition.Name = eInfo.CompetitionName;
				competition.Rule = eInfo.Rule;
				competition.ScheduleCompetitionNr = eInfo.ScheduleCompetitionNR;
				AppState.AddToPool(competition);
			}
		}

		//TODO make better logic and try remove hardcode
		private void makeDocumentButton_Click(object sender, EventArgs e) {
			var iRows = infoGridView.SelectedRows;
			if (iRows.Count == 1) {
				var eInfo = iRows[0].DataBoundItem as EventInfo;
				var doc = new XDocument( 
					new XElement("EventResult",
									new XElement("Show", 
									new XAttribute("FEIID", eInfo.ShowID), 
									new XAttribute("StartDate", eInfo.ShowStartDate), 
									new XAttribute("EndDate", eInfo.ShowEndDate), 
										new XElement("Venue",
										new XAttribute("Name", eInfo.VenueName), 
										new XAttribute("Country", eInfo.VenueCountry)),
										new XElement("DressageEvent", 
										new XAttribute("FEIID", eInfo.EventID), 
										new XAttribute("Code", eInfo.EventCode), 
										new XAttribute("NF", eInfo.NF), 
										new XAttribute("StartDate", eInfo.EventStartDate), 
										new XAttribute("EndDate", eInfo.EventEndDate),
											new XElement("Competitions", AppState.Data.Select(c => c.ToXML()))))));
				doc.Save("test1.xml");
				AppState.Init();
			}
		}
	}
}
