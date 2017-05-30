using System.IO;
using System.Windows.Forms;

namespace HorseSport {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.judgeView = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.descriptionMakeButton = new System.Windows.Forms.Button();
			this.usePrizesCheckBox = new System.Windows.Forms.CheckBox();
			this.currencyTextBox = new System.Windows.Forms.TextBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.menuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.judgeView)).BeginInit();
			this.statusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(1269, 24);
			this.menuStrip.TabIndex = 1;
			this.menuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// judgeView
			// 
			this.judgeView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.judgeView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
			this.judgeView.Location = new System.Drawing.Point(539, 27);
			this.judgeView.Name = "judgeView";
			this.judgeView.Size = new System.Drawing.Size(718, 182);
			this.judgeView.TabIndex = 2;
			// 
			// Column1
			// 
			this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Column1.DataPropertyName = "FEIID";
			this.Column1.HeaderText = "FEIID";
			this.Column1.Name = "Column1";
			this.Column1.Width = 59;
			// 
			// Column2
			// 
			this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Column2.DataPropertyName = "FamilyName";
			this.Column2.HeaderText = "Family Name";
			this.Column2.Name = "Column2";
			this.Column2.Width = 92;
			// 
			// Column3
			// 
			this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Column3.DataPropertyName = "FirstName";
			this.Column3.HeaderText = "First Name";
			this.Column3.Name = "Column3";
			this.Column3.Width = 82;
			// 
			// Column4
			// 
			this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Column4.DataPropertyName = "NF";
			this.Column4.HeaderText = "NF";
			this.Column4.Name = "Column4";
			this.Column4.Width = 46;
			// 
			// Column5
			// 
			this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Column5.DataPropertyName = "OfficialStatus";
			this.Column5.HeaderText = "Official Status";
			this.Column5.Name = "Column5";
			this.Column5.Width = 97;
			// 
			// Column6
			// 
			this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Column6.DataPropertyName = "Position";
			this.Column6.HeaderText = "Position";
			this.Column6.Name = "Column6";
			this.Column6.Width = 69;
			// 
			// Column7
			// 
			this.Column7.HeaderText = "In charge";
			this.Column7.Name = "Column7";
			// 
			// descriptionMakeButton
			// 
			this.descriptionMakeButton.Location = new System.Drawing.Point(539, 215);
			this.descriptionMakeButton.Name = "descriptionMakeButton";
			this.descriptionMakeButton.Size = new System.Drawing.Size(238, 23);
			this.descriptionMakeButton.TabIndex = 3;
			this.descriptionMakeButton.Text = "Make Description";
			this.descriptionMakeButton.UseVisualStyleBackColor = true;
			this.descriptionMakeButton.Click += new System.EventHandler(this.descriptionMakeButton_Click);
			// 
			// usePrizesCheckBox
			// 
			this.usePrizesCheckBox.AutoSize = true;
			this.usePrizesCheckBox.Location = new System.Drawing.Point(791, 217);
			this.usePrizesCheckBox.Name = "usePrizesCheckBox";
			this.usePrizesCheckBox.Size = new System.Drawing.Size(76, 17);
			this.usePrizesCheckBox.TabIndex = 4;
			this.usePrizesCheckBox.Text = "Use Prizes";
			this.usePrizesCheckBox.UseVisualStyleBackColor = true;
			this.usePrizesCheckBox.CheckedChanged += new System.EventHandler(this.usePrizesCheckBox_CheckedChanged);
			// 
			// currencyTextBox
			// 
			this.currencyTextBox.Location = new System.Drawing.Point(874, 217);
			this.currencyTextBox.Name = "currencyTextBox";
			this.currencyTextBox.Size = new System.Drawing.Size(100, 20);
			this.currencyTextBox.TabIndex = 5;
			this.currencyTextBox.Visible = false;
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "source";
			this.openFileDialog.Filter = "Source files (*.csv, *.xlsx)|*.csv;*.xlsx";
			this.openFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "sources");
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 513);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(1269, 22);
			this.statusStrip.TabIndex = 8;
			this.statusStrip.Text = "statusStrip1";
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
			this.toolStripStatusLabel.Text = "Status";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1269, 535);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.currencyTextBox);
			this.Controls.Add(this.usePrizesCheckBox);
			this.Controls.Add(this.descriptionMakeButton);
			this.Controls.Add(this.judgeView);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.Name = "MainForm";
			this.Text = "Horse sport excel parser (by grozail)";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.judgeView)).EndInit();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.DataGridView judgeView;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
		private System.Windows.Forms.Button descriptionMakeButton;
		private System.Windows.Forms.CheckBox usePrizesCheckBox;
		private System.Windows.Forms.TextBox currencyTextBox;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
		private System.Windows.Forms.BindingSource bindingSource;
	}
}

