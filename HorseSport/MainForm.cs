﻿using HorseSport.Data;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HorseSport {
	public partial class MainForm : Form {
		private static Logger logger = LogManager.GetCurrentClassLogger();
		public MainForm() {
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e) {
			JudgeManager.LoadData();
			foreach (var kvp in JudgeManager.Data.Values) {
				judgeView.Rows.Add(kvp.AsDataView());
			}
			logger.Info("Judges data loaded");
		}

		private void juryNodeMakeButton_Click(object sender, EventArgs e) {
			
		}

		private void usePrizesCheckBox_CheckedChanged(object sender, EventArgs e) {
			if (usePrizesCheckBox.Checked) {
				currencyTextBox.Visible = true;
			}
			else {
				currencyTextBox.Visible = false;
			}
		}
	}
}
