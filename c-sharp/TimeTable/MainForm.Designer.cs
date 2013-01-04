namespace TimeTable
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TABLEcomboBox = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.NAMEtextBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbxWeight = new System.Windows.Forms.TextBox();
            this.cbxName2 = new System.Windows.Forms.ComboBox();
            this.cbxName1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxLinksTable = new System.Windows.Forms.ComboBox();
            this.grdLinksTable = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grdTimetable = new System.Windows.Forms.DataGridView();
            this.cbxOnDay = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxForGroup = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.rbGroup = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTeacher = new System.Windows.Forms.RadioButton();
            this.cbxForTeacher = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLinksTable)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTimetable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(553, 402);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(545, 376);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Справочные таблицы";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TABLEcomboBox);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.NAMEtextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 31);
            this.panel1.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(317, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Таблица:";
            // 
            // TABLEcomboBox
            // 
            this.TABLEcomboBox.FormattingEnabled = true;
            this.TABLEcomboBox.Items.AddRange(new object[] {
            "groups",
            "rooms",
            "subjects",
            "teachers",
            "days",
            "times"});
            this.TABLEcomboBox.Location = new System.Drawing.Point(64, 5);
            this.TABLEcomboBox.Name = "TABLEcomboBox";
            this.TABLEcomboBox.Size = new System.Drawing.Size(87, 21);
            this.TABLEcomboBox.TabIndex = 2;
            this.TABLEcomboBox.TabStopChanged += new System.EventHandler(this.TABLEcomboBox_SelectionChangeCommitted);
            this.TABLEcomboBox.SelectedIndexChanged += new System.EventHandler(this.TABLEcomboBox_SelectionChangeCommitted);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(365, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "DEL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "name:";
            // 
            // NAMEtextBox
            // 
            this.NAMEtextBox.Location = new System.Drawing.Point(211, 5);
            this.NAMEtextBox.Name = "NAMEtextBox";
            this.NAMEtextBox.Size = new System.Drawing.Size(100, 20);
            this.NAMEtextBox.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(539, 333);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbxWeight);
            this.tabPage2.Controls.Add(this.cbxName2);
            this.tabPage2.Controls.Add(this.cbxName1);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cbxLinksTable);
            this.tabPage2.Controls.Add(this.grdLinksTable);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(545, 376);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Связывающие таблицы";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // tbxWeight
            // 
            this.tbxWeight.Location = new System.Drawing.Point(454, 6);
            this.tbxWeight.Name = "tbxWeight";
            this.tbxWeight.Size = new System.Drawing.Size(40, 20);
            this.tbxWeight.TabIndex = 15;
            this.tbxWeight.Text = "1";
            // 
            // cbxName2
            // 
            this.cbxName2.FormattingEnabled = true;
            this.cbxName2.Location = new System.Drawing.Point(338, 6);
            this.cbxName2.Name = "cbxName2";
            this.cbxName2.Size = new System.Drawing.Size(110, 21);
            this.cbxName2.TabIndex = 14;
            // 
            // cbxName1
            // 
            this.cbxName1.FormattingEnabled = true;
            this.cbxName1.Location = new System.Drawing.Point(222, 6);
            this.cbxName1.Name = "cbxName1";
            this.cbxName1.Size = new System.Drawing.Size(110, 21);
            this.cbxName1.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(174, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "ADD";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(500, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(37, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "DEL";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Таблица:";
            // 
            // cbxLinksTable
            // 
            this.cbxLinksTable.FormattingEnabled = true;
            this.cbxLinksTable.Items.AddRange(new object[] {
            "days_times",
            "rooms_subjects",
            "teachers_subjects",
            "groups_subjects"});
            this.cbxLinksTable.Location = new System.Drawing.Point(66, 6);
            this.cbxLinksTable.Name = "cbxLinksTable";
            this.cbxLinksTable.Size = new System.Drawing.Size(102, 21);
            this.cbxLinksTable.TabIndex = 4;
            this.cbxLinksTable.SelectedIndexChanged += new System.EventHandler(this.cbxLinksTable_SelectionChangeCommitted);
            // 
            // grdLinksTable
            // 
            this.grdLinksTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLinksTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdLinksTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLinksTable.Location = new System.Drawing.Point(3, 33);
            this.grdLinksTable.Name = "grdLinksTable";
            this.grdLinksTable.ReadOnly = true;
            this.grdLinksTable.Size = new System.Drawing.Size(539, 339);
            this.grdLinksTable.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.grdTimetable);
            this.tabPage3.Controls.Add(this.cbxOnDay);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(545, 376);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Расписание";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Enter += new System.EventHandler(this.tabPage3_Enter);
            // 
            // grdTimetable
            // 
            this.grdTimetable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTimetable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdTimetable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTimetable.Location = new System.Drawing.Point(3, 66);
            this.grdTimetable.Name = "grdTimetable";
            this.grdTimetable.ReadOnly = true;
            this.grdTimetable.Size = new System.Drawing.Size(539, 307);
            this.grdTimetable.TabIndex = 4;
            // 
            // cbxOnDay
            // 
            this.cbxOnDay.FormattingEnabled = true;
            this.cbxOnDay.Location = new System.Drawing.Point(301, 4);
            this.cbxOnDay.Name = "cbxOnDay";
            this.cbxOnDay.Size = new System.Drawing.Size(50, 21);
            this.cbxOnDay.TabIndex = 3;
            this.cbxOnDay.SelectedIndexChanged += new System.EventHandler(this.cbxForGroup_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(266, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "на";
            // 
            // cbxForGroup
            // 
            this.cbxForGroup.FormattingEnabled = true;
            this.cbxForGroup.Location = new System.Drawing.Point(97, 8);
            this.cbxForGroup.Name = "cbxForGroup";
            this.cbxForGroup.Size = new System.Drawing.Size(102, 21);
            this.cbxForGroup.TabIndex = 1;
            this.cbxForGroup.SelectedIndexChanged += new System.EventHandler(this.cbxForGroup_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(404, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(133, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "ПЕРЕГЕНЕРИРОВАТЬ";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // rbGroup
            // 
            this.rbGroup.AutoSize = true;
            this.rbGroup.Checked = true;
            this.rbGroup.Location = new System.Drawing.Point(3, 8);
            this.rbGroup.Name = "rbGroup";
            this.rbGroup.Size = new System.Drawing.Size(88, 17);
            this.rbGroup.TabIndex = 6;
            this.rbGroup.TabStop = true;
            this.rbGroup.Text = "для классов";
            this.rbGroup.UseVisualStyleBackColor = true;
            this.rbGroup.CheckedChanged += new System.EventHandler(this.rbGroup_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxForTeacher);
            this.groupBox1.Controls.Add(this.rbTeacher);
            this.groupBox1.Controls.Add(this.rbGroup);
            this.groupBox1.Controls.Add(this.cbxForGroup);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 60);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // rbTeacher
            // 
            this.rbTeacher.AutoSize = true;
            this.rbTeacher.Location = new System.Drawing.Point(3, 31);
            this.rbTeacher.Name = "rbTeacher";
            this.rbTeacher.Size = new System.Drawing.Size(91, 17);
            this.rbTeacher.TabIndex = 7;
            this.rbTeacher.Text = "для учителей";
            this.rbTeacher.UseVisualStyleBackColor = true;
            this.rbTeacher.CheckedChanged += new System.EventHandler(this.rbTeacher_CheckedChanged);
            // 
            // cbxForTeacher
            // 
            this.cbxForTeacher.Enabled = false;
            this.cbxForTeacher.FormattingEnabled = true;
            this.cbxForTeacher.Location = new System.Drawing.Point(97, 30);
            this.cbxForTeacher.Name = "cbxForTeacher";
            this.cbxForTeacher.Size = new System.Drawing.Size(102, 21);
            this.cbxForTeacher.TabIndex = 8;
            this.cbxForTeacher.SelectedIndexChanged += new System.EventHandler(this.cbxForGroup_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 402);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(569, 440);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLinksTable)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTimetable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TABLEcomboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox NAMEtextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxLinksTable;
        private System.Windows.Forms.DataGridView grdLinksTable;
        private System.Windows.Forms.ComboBox cbxName1;
        private System.Windows.Forms.TextBox tbxWeight;
        private System.Windows.Forms.ComboBox cbxName2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox cbxForGroup;
        private System.Windows.Forms.ComboBox cbxOnDay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView grdTimetable;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTeacher;
        private System.Windows.Forms.RadioButton rbGroup;
        private System.Windows.Forms.ComboBox cbxForTeacher;
    }
}