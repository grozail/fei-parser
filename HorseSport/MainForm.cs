using HorseSport.Data;
using HorseSport.Parser.Model.Event.Properties;
using HorseSport.Parser.Model.Living;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
			JudgeManager.LoadData();
			foreach (var value in JudgeManager.Data.Values) {
				bindingSource.Add(value);
			}
			judgeView.DataSource = bindingSource;
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

			}
		}

		private void descriptionMakeButton_Click(object sender, EventArgs e) {
			Description description = new Description();
			foreach (DataGridViewRow item in judgeView.Rows) {
				var checkCell = (item.Cells["In charge"] as DataGridViewCheckBoxCell);
				if (checkCell != null && checkCell.Value != null && (bool)checkCell.Value) {
					description.Jury.Add(item.DataBoundItem as Judge);
				}
			}
			if (usePrizesCheckBox.Checked) {
				description.Prizes = new Prizes(currencyTextBox.Text.ToUpper());
			}
			AppState.Description = description;
			logger.Info("Description formed");
		}
	}
}
