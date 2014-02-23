namespace FarmPlanner
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnShowDetails = new System.Windows.Forms.Button();
            this.listCrops = new System.Windows.Forms.CheckedListBox();
            this.comboMonth = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboFarmSection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteSection = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnClearSelection = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dgvFarmView = new System.Windows.Forms.DataGridView();
            this.clmSection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.January = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.February = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.March = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.April = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.May = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.June = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.July = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.August = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.September = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.October = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.November = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.December = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvCorps = new System.Windows.Forms.DataGridView();
            this.CorpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorpPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorpColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboColor = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPeriod = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtSecction = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboYear = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFarmView)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorps)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.comboYear);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnShowDetails);
            this.groupBox1.Controls.Add(this.listCrops);
            this.groupBox1.Controls.Add(this.comboMonth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboFarmSection);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(926, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Farm Area";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnShowDetails
            // 
            this.btnShowDetails.BackgroundImage = global::FarmPlanner.Properties.Resources.information;
            this.btnShowDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowDetails.Location = new System.Drawing.Point(371, 26);
            this.btnShowDetails.Name = "btnShowDetails";
            this.btnShowDetails.Size = new System.Drawing.Size(75, 68);
            this.btnShowDetails.TabIndex = 6;
            this.btnShowDetails.UseVisualStyleBackColor = true;
            this.btnShowDetails.Click += new System.EventHandler(this.button5_Click);
            // 
            // listCrops
            // 
            this.listCrops.CheckOnClick = true;
            this.listCrops.FormattingEnabled = true;
            this.listCrops.Location = new System.Drawing.Point(478, 50);
            this.listCrops.MultiColumn = true;
            this.listCrops.Name = "listCrops";
            this.listCrops.Size = new System.Drawing.Size(425, 84);
            this.listCrops.TabIndex = 5;
            this.listCrops.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // comboMonth
            // 
            this.comboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMonth.FormattingEnabled = true;
            this.comboMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.comboMonth.Location = new System.Drawing.Point(162, 111);
            this.comboMonth.Name = "comboMonth";
            this.comboMonth.Size = new System.Drawing.Size(174, 23);
            this.comboMonth.TabIndex = 4;
            this.comboMonth.SelectedIndexChanged += new System.EventHandler(this.comboMonth_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Select Month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(478, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Choose Crops";
            // 
            // comboFarmSection
            // 
            this.comboFarmSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFarmSection.FormattingEnabled = true;
            this.comboFarmSection.Location = new System.Drawing.Point(162, 26);
            this.comboFarmSection.Name = "comboFarmSection";
            this.comboFarmSection.Size = new System.Drawing.Size(174, 23);
            this.comboFarmSection.TabIndex = 1;
            this.comboFarmSection.SelectedIndexChanged += new System.EventHandler(this.comboFarmSection_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose Farm Section";
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.btnDeleteSection);
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Controls.Add(this.lblMessage);
            this.groupBox2.Controls.Add(this.btnClearSelection);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.dgvFarmView);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(926, 502);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Farm View ";
            // 
            // btnDeleteSection
            // 
            this.btnDeleteSection.BackColor = System.Drawing.Color.LightCoral;
            this.btnDeleteSection.Enabled = false;
            this.btnDeleteSection.Location = new System.Drawing.Point(311, 453);
            this.btnDeleteSection.Name = "btnDeleteSection";
            this.btnDeleteSection.Size = new System.Drawing.Size(122, 29);
            this.btnDeleteSection.TabIndex = 6;
            this.btnDeleteSection.Text = "Delete Section !";
            this.btnDeleteSection.UseVisualStyleBackColor = false;
            this.btnDeleteSection.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(456, 453);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(106, 29);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(17, 442);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(275, 40);
            this.lblMessage.TabIndex = 4;
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.Enabled = false;
            this.btnClearSelection.Location = new System.Drawing.Point(581, 453);
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(92, 29);
            this.btnClearSelection.TabIndex = 3;
            this.btnClearSelection.Text = "Clear Section";
            this.btnClearSelection.UseVisualStyleBackColor = true;
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(692, 453);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(110, 29);
            this.button4.TabIndex = 2;
            this.button4.Text = "Reset FamView";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(817, 453);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 29);
            this.button3.TabIndex = 1;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dgvFarmView
            // 
            this.dgvFarmView.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dgvFarmView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFarmView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSection,
            this.January,
            this.February,
            this.March,
            this.April,
            this.May,
            this.June,
            this.July,
            this.August,
            this.September,
            this.October,
            this.November,
            this.December});
            this.dgvFarmView.Location = new System.Drawing.Point(20, 29);
            this.dgvFarmView.MultiSelect = false;
            this.dgvFarmView.Name = "dgvFarmView";
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvFarmView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFarmView.Size = new System.Drawing.Size(889, 397);
            this.dgvFarmView.TabIndex = 0;
            this.dgvFarmView.SelectionChanged += new System.EventHandler(this.dgvFarmView_SelectionChanged);
            // 
            // clmSection
            // 
            this.clmSection.HeaderText = "Section";
            this.clmSection.Name = "clmSection";
            this.clmSection.ReadOnly = true;
            // 
            // January
            // 
            this.January.HeaderText = "January";
            this.January.Name = "January";
            this.January.ReadOnly = true;
            this.January.Width = 60;
            // 
            // February
            // 
            this.February.HeaderText = "February";
            this.February.Name = "February";
            this.February.ReadOnly = true;
            this.February.Width = 65;
            // 
            // March
            // 
            this.March.HeaderText = "March";
            this.March.Name = "March";
            this.March.ReadOnly = true;
            this.March.Width = 60;
            // 
            // April
            // 
            this.April.HeaderText = "April";
            this.April.Name = "April";
            this.April.ReadOnly = true;
            this.April.Width = 55;
            // 
            // May
            // 
            this.May.HeaderText = "May";
            this.May.Name = "May";
            this.May.ReadOnly = true;
            this.May.Width = 55;
            // 
            // June
            // 
            this.June.HeaderText = "June";
            this.June.Name = "June";
            this.June.ReadOnly = true;
            this.June.Width = 60;
            // 
            // July
            // 
            this.July.HeaderText = "July";
            this.July.Name = "July";
            this.July.ReadOnly = true;
            this.July.Width = 60;
            // 
            // August
            // 
            this.August.HeaderText = "August";
            this.August.Name = "August";
            this.August.ReadOnly = true;
            this.August.Width = 60;
            // 
            // September
            // 
            this.September.HeaderText = "September";
            this.September.Name = "September";
            this.September.ReadOnly = true;
            this.September.Width = 70;
            // 
            // October
            // 
            this.October.HeaderText = "October";
            this.October.Name = "October";
            this.October.ReadOnly = true;
            this.October.Width = 60;
            // 
            // November
            // 
            this.November.HeaderText = "November";
            this.November.Name = "November";
            this.November.ReadOnly = true;
            this.November.Width = 70;
            // 
            // December
            // 
            this.December.HeaderText = "December";
            this.December.Name = "December";
            this.December.ReadOnly = true;
            this.December.Width = 70;
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.dgvCorps);
            this.groupBox3.Controls.Add(this.comboColor);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.txtPeriod);
            this.groupBox3.Controls.Add(this.txtName);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(952, 183);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(394, 502);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Add Corp";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(172, 130);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 29);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvCorps
            // 
            this.dgvCorps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCorps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCorps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CorpName,
            this.CorpPeriod,
            this.CorpColor});
            this.dgvCorps.Location = new System.Drawing.Point(21, 183);
            this.dgvCorps.Name = "dgvCorps";
            this.dgvCorps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCorps.Size = new System.Drawing.Size(360, 299);
            this.dgvCorps.TabIndex = 8;
            this.dgvCorps.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCorps_CellMouseClick);
            this.dgvCorps.SelectionChanged += new System.EventHandler(this.dgvCorps_SelectionChanged);
            // 
            // CorpName
            // 
            this.CorpName.HeaderText = "CorpName";
            this.CorpName.Name = "CorpName";
            this.CorpName.ReadOnly = true;
            // 
            // CorpPeriod
            // 
            this.CorpPeriod.HeaderText = "CorpPeriod";
            this.CorpPeriod.Name = "CorpPeriod";
            this.CorpPeriod.ReadOnly = true;
            // 
            // CorpColor
            // 
            this.CorpColor.HeaderText = "CorpColor";
            this.CorpColor.Name = "CorpColor";
            this.CorpColor.ReadOnly = true;
            // 
            // comboColor
            // 
            this.comboColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboColor.DropDownHeight = 150;
            this.comboColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboColor.FormattingEnabled = true;
            this.comboColor.IntegralHeight = false;
            this.comboColor.Location = new System.Drawing.Point(97, 95);
            this.comboColor.Name = "comboColor";
            this.comboColor.Size = new System.Drawing.Size(284, 22);
            this.comboColor.TabIndex = 7;
            this.comboColor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboColor_DrawItem);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(284, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPeriod
            // 
            this.txtPeriod.Location = new System.Drawing.Point(97, 61);
            this.txtPeriod.MaxLength = 3;
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Size = new System.Drawing.Size(284, 21);
            this.txtPeriod.TabIndex = 4;
            this.txtPeriod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCorp_KeyPress);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(97, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(284, 21);
            this.txtName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Color";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Period";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Name";
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.txtSecction);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(952, 21);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(394, 154);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Add Section";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(284, 60);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 29);
            this.button2.TabIndex = 6;
            this.button2.Text = "Add Section";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtSecction
            // 
            this.txtSecction.Location = new System.Drawing.Point(147, 24);
            this.txtSecction.Name = "txtSecction";
            this.txtSecction.Size = new System.Drawing.Size(234, 21);
            this.txtSecction.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Section Name";
            // 
            // comboYear
            // 
            this.comboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboYear.FormattingEnabled = true;
            this.comboYear.Items.AddRange(new object[] {
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.comboYear.Location = new System.Drawing.Point(162, 67);
            this.comboYear.Name = "comboYear";
            this.comboYear.Size = new System.Drawing.Size(174, 23);
            this.comboYear.TabIndex = 10;
            this.comboYear.SelectedIndexChanged += new System.EventHandler(this.comboYear_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Select Year";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1362, 707);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Farm Planner";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFarmView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorps)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox listCrops;
        private System.Windows.Forms.ComboBox comboMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboFarmSection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvFarmView;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSection;
        private System.Windows.Forms.DataGridViewTextBoxColumn January;
        private System.Windows.Forms.DataGridViewTextBoxColumn February;
        private System.Windows.Forms.DataGridViewTextBoxColumn March;
        private System.Windows.Forms.DataGridViewTextBoxColumn April;
        private System.Windows.Forms.DataGridViewTextBoxColumn May;
        private System.Windows.Forms.DataGridViewTextBoxColumn June;
        private System.Windows.Forms.DataGridViewTextBoxColumn July;
        private System.Windows.Forms.DataGridViewTextBoxColumn August;
        private System.Windows.Forms.DataGridViewTextBoxColumn September;
        private System.Windows.Forms.DataGridViewTextBoxColumn October;
        private System.Windows.Forms.DataGridViewTextBoxColumn November;
        private System.Windows.Forms.DataGridViewTextBoxColumn December;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPeriod;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboColor;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtSecction;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvCorps;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorpPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorpColor;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnShowDetails;
        private System.Windows.Forms.Button btnClearSelection;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnDeleteSection;
        private System.Windows.Forms.ComboBox comboYear;
        private System.Windows.Forms.Label label7;
    }
}

