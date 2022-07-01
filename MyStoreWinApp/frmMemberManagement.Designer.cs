namespace MyStoreWinApp
{
    partial class frmMemberManagement
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
            this.btnCLose = new System.Windows.Forms.Button();
            this.dgvMemberList = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.lbReleaseYear = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbManufacturer = new System.Windows.Forms.Label();
            this.lbCarName = new System.Windows.Forms.Label();
            this.lbCarID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.btnFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCLose
            // 
            this.btnCLose.Location = new System.Drawing.Point(620, 596);
            this.btnCLose.Name = "btnCLose";
            this.btnCLose.Size = new System.Drawing.Size(94, 29);
            this.btnCLose.TabIndex = 29;
            this.btnCLose.Text = "Close";
            this.btnCLose.UseVisualStyleBackColor = true;
            this.btnCLose.Click += new System.EventHandler(this.btnCLose_Click);
            // 
            // dgvMemberList
            // 
            this.dgvMemberList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMemberList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMemberList.Location = new System.Drawing.Point(12, 307);
            this.dgvMemberList.Name = "dgvMemberList";
            this.dgvMemberList.ReadOnly = true;
            this.dgvMemberList.RowHeadersWidth = 51;
            this.dgvMemberList.RowTemplate.Height = 29;
            this.dgvMemberList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMemberList.Size = new System.Drawing.Size(1231, 283);
            this.dgvMemberList.TabIndex = 28;
            this.dgvMemberList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMemberList_CellContentClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(781, 170);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(117, 42);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(554, 170);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(117, 42);
            this.btnNew.TabIndex = 26;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(332, 170);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(117, 42);
            this.btnLoad.TabIndex = 25;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtMemberName
            // 
            this.txtMemberName.Location = new System.Drawing.Point(201, 66);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(365, 27);
            this.txtMemberName.TabIndex = 24;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(797, 113);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(365, 27);
            this.txtCity.TabIndex = 23;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(797, 17);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(365, 27);
            this.txtEmail.TabIndex = 22;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(797, 66);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(365, 27);
            this.txtPassword.TabIndex = 21;
            // 
            // txtMemberId
            // 
            this.txtMemberId.Location = new System.Drawing.Point(201, 17);
            this.txtMemberId.Name = "txtMemberId";
            this.txtMemberId.Size = new System.Drawing.Size(365, 27);
            this.txtMemberId.TabIndex = 20;
            // 
            // lbReleaseYear
            // 
            this.lbReleaseYear.AutoSize = true;
            this.lbReleaseYear.Location = new System.Drawing.Point(711, 66);
            this.lbReleaseYear.Name = "lbReleaseYear";
            this.lbReleaseYear.Size = new System.Drawing.Size(70, 20);
            this.lbReleaseYear.TabIndex = 19;
            this.lbReleaseYear.Text = "Password";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(711, 20);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(46, 20);
            this.lbPrice.TabIndex = 18;
            this.lbPrice.Text = "Email";
            // 
            // lbManufacturer
            // 
            this.lbManufacturer.AutoSize = true;
            this.lbManufacturer.Location = new System.Drawing.Point(711, 116);
            this.lbManufacturer.Name = "lbManufacturer";
            this.lbManufacturer.Size = new System.Drawing.Size(34, 20);
            this.lbManufacturer.TabIndex = 17;
            this.lbManufacturer.Text = "City";
            // 
            // lbCarName
            // 
            this.lbCarName.AutoSize = true;
            this.lbCarName.Location = new System.Drawing.Point(86, 66);
            this.lbCarName.Name = "lbCarName";
            this.lbCarName.Size = new System.Drawing.Size(109, 20);
            this.lbCarName.TabIndex = 16;
            this.lbCarName.Text = "Member Name";
            // 
            // lbCarID
            // 
            this.lbCarID.AutoSize = true;
            this.lbCarID.Location = new System.Drawing.Point(86, 20);
            this.lbCarID.Name = "lbCarID";
            this.lbCarID.Size = new System.Drawing.Size(84, 20);
            this.lbCarID.TabIndex = 15;
            this.lbCarID.Text = "Member ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Country";
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(198, 113);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(368, 27);
            this.txtCountry.TabIndex = 31;
            // 
            // cboCountry
            // 
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.Location = new System.Drawing.Point(319, 259);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(209, 28);
            this.cboCountry.TabIndex = 32;
            this.cboCountry.SelectedIndexChanged += new System.EventHandler(this.cboCountry_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(583, 259);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(229, 28);
            this.comboBox2.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(543, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "City";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Country";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(830, 259);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(94, 29);
            this.btnFilter.TabIndex = 36;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // frmMemberManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 637);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.cboCountry);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCLose);
            this.Controls.Add(this.dgvMemberList);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtMemberName);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtMemberId);
            this.Controls.Add(this.lbReleaseYear);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbManufacturer);
            this.Controls.Add(this.lbCarName);
            this.Controls.Add(this.lbCarID);
            this.Name = "frmMemberManagement";
            this.Text = "frmMemberManagement";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMemberManagement_FormClosed);
            this.Load += new System.EventHandler(this.frmMemberManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCLose;
        private DataGridView dgvMemberList;
        private Button btnDelete;
        private Button btnNew;
        private Button btnLoad;
        private TextBox txtMemberName;
        private TextBox txtCity;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtMemberId;
        private Label lbReleaseYear;
        private Label lbPrice;
        private Label lbManufacturer;
        private Label lbCarName;
        private Label lbCarID;
        private Label label1;
        private TextBox txtCountry;
        private ComboBox cboCountry;
        private ComboBox comboBox2;
        private Label label2;
        private Label label3;
        private FileSystemWatcher fileSystemWatcher1;
        private Button btnFilter;
    }
}