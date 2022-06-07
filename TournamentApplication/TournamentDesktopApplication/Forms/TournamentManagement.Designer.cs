namespace TournamentDesktopApplication.Forms
{
    partial class TournamentManagement
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
            this.lbTournaments = new System.Windows.Forms.ListBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.numMinComp = new System.Windows.Forms.NumericUpDown();
            this.numMaxComp = new System.Windows.Forms.NumericUpDown();
            this.tbAdress = new System.Windows.Forms.TextBox();
            this.cbTournamentSystem = new System.Windows.Forms.ComboBox();
            this.lblTournamets = new System.Windows.Forms.Label();
            this.lblTournamentName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblAdress = new System.Windows.Forms.Label();
            this.lblTournamentSystem = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaxComp = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancelTournament = new System.Windows.Forms.Button();
            this.btnEditTournament = new System.Windows.Forms.Button();
            this.lblLocation = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMinComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxComp)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTournaments
            // 
            this.lbTournaments.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTournaments.FormattingEnabled = true;
            this.lbTournaments.ItemHeight = 15;
            this.lbTournaments.Location = new System.Drawing.Point(320, 71);
            this.lbTournaments.Name = "lbTournaments";
            this.lbTournaments.Size = new System.Drawing.Size(453, 244);
            this.lbTournaments.TabIndex = 0;
            this.lbTournaments.SelectedIndexChanged += new System.EventHandler(this.lbTournaments_SelectedIndexChanged);
            // 
            // tbName
            // 
            this.tbName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbName.Location = new System.Drawing.Point(41, 94);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(200, 23);
            this.tbName.TabIndex = 1;
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbDescription.Location = new System.Drawing.Point(41, 147);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(200, 79);
            this.tbDescription.TabIndex = 2;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpStartDate.Location = new System.Drawing.Point(38, 248);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 23);
            this.dtpStartDate.TabIndex = 3;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpEndDate.Location = new System.Drawing.Point(38, 312);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 23);
            this.dtpEndDate.TabIndex = 4;
            // 
            // numMinComp
            // 
            this.numMinComp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numMinComp.Location = new System.Drawing.Point(38, 360);
            this.numMinComp.Name = "numMinComp";
            this.numMinComp.Size = new System.Drawing.Size(61, 23);
            this.numMinComp.TabIndex = 5;
            // 
            // numMaxComp
            // 
            this.numMaxComp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numMaxComp.Location = new System.Drawing.Point(180, 360);
            this.numMaxComp.Name = "numMaxComp";
            this.numMaxComp.Size = new System.Drawing.Size(61, 23);
            this.numMaxComp.TabIndex = 6;
            // 
            // tbAdress
            // 
            this.tbAdress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbAdress.Location = new System.Drawing.Point(38, 421);
            this.tbAdress.Name = "tbAdress";
            this.tbAdress.Size = new System.Drawing.Size(200, 23);
            this.tbAdress.TabIndex = 7;
            // 
            // cbTournamentSystem
            // 
            this.cbTournamentSystem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbTournamentSystem.FormattingEnabled = true;
            this.cbTournamentSystem.Items.AddRange(new object[] {
            "RoundRobin",
            "DoubleRoundRobin"});
            this.cbTournamentSystem.Location = new System.Drawing.Point(38, 477);
            this.cbTournamentSystem.Name = "cbTournamentSystem";
            this.cbTournamentSystem.Size = new System.Drawing.Size(200, 23);
            this.cbTournamentSystem.TabIndex = 8;
            // 
            // lblTournamets
            // 
            this.lblTournamets.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTournamets.AutoSize = true;
            this.lblTournamets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTournamets.Location = new System.Drawing.Point(474, 36);
            this.lblTournamets.Name = "lblTournamets";
            this.lblTournamets.Size = new System.Drawing.Size(131, 20);
            this.lblTournamets.TabIndex = 9;
            this.lblTournamets.Text = "TOURNAMENTS";
            // 
            // lblTournamentName
            // 
            this.lblTournamentName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTournamentName.AutoSize = true;
            this.lblTournamentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTournamentName.Location = new System.Drawing.Point(41, 71);
            this.lblTournamentName.Name = "lblTournamentName";
            this.lblTournamentName.Size = new System.Drawing.Size(122, 16);
            this.lblTournamentName.TabIndex = 10;
            this.lblTournamentName.Text = "Tournament Name:";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDescription.Location = new System.Drawing.Point(41, 128);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(78, 16);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.Text = "Description:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStartDate.Location = new System.Drawing.Point(38, 229);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(69, 16);
            this.lblStartDate.TabIndex = 12;
            this.lblStartDate.Text = "Start Date:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEndDate.Location = new System.Drawing.Point(38, 293);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(66, 16);
            this.lblEndDate.TabIndex = 13;
            this.lblEndDate.Text = "End Date:";
            // 
            // lblAdress
            // 
            this.lblAdress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAdress.AutoSize = true;
            this.lblAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAdress.Location = new System.Drawing.Point(38, 458);
            this.lblAdress.Name = "lblAdress";
            this.lblAdress.Size = new System.Drawing.Size(53, 16);
            this.lblAdress.TabIndex = 14;
            this.lblAdress.Text = "Adress:";
            // 
            // lblTournamentSystem
            // 
            this.lblTournamentSystem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTournamentSystem.AutoSize = true;
            this.lblTournamentSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTournamentSystem.Location = new System.Drawing.Point(38, 456);
            this.lblTournamentSystem.Name = "lblTournamentSystem";
            this.lblTournamentSystem.Size = new System.Drawing.Size(130, 16);
            this.lblTournamentSystem.TabIndex = 15;
            this.lblTournamentSystem.Text = "Tournament System:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(38, 341);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Min. Competitors";
            // 
            // lblMaxComp
            // 
            this.lblMaxComp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMaxComp.AutoSize = true;
            this.lblMaxComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMaxComp.Location = new System.Drawing.Point(150, 341);
            this.lblMaxComp.Name = "lblMaxComp";
            this.lblMaxComp.Size = new System.Drawing.Size(110, 16);
            this.lblMaxComp.TabIndex = 17;
            this.lblMaxComp.Text = "Max. Competitors";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(360, 385);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 51);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Add Tournament";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancelTournament
            // 
            this.btnCancelTournament.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelTournament.Location = new System.Drawing.Point(498, 387);
            this.btnCancelTournament.Name = "btnCancelTournament";
            this.btnCancelTournament.Size = new System.Drawing.Size(94, 49);
            this.btnCancelTournament.TabIndex = 19;
            this.btnCancelTournament.Text = "Cancel Tournament";
            this.btnCancelTournament.UseVisualStyleBackColor = true;
            this.btnCancelTournament.Click += new System.EventHandler(this.btnCancelTournament_Click);
            // 
            // btnEditTournament
            // 
            this.btnEditTournament.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTournament.Location = new System.Drawing.Point(640, 387);
            this.btnEditTournament.Name = "btnEditTournament";
            this.btnEditTournament.Size = new System.Drawing.Size(94, 49);
            this.btnEditTournament.TabIndex = 20;
            this.btnEditTournament.Text = "Edit Tournament";
            this.btnEditTournament.UseVisualStyleBackColor = true;
            this.btnEditTournament.Click += new System.EventHandler(this.btnEditTournament_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLocation.Location = new System.Drawing.Point(38, 402);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(53, 16);
            this.lblLocation.TabIndex = 21;
            this.lblLocation.Text = "Adress:";
            // 
            // tbID
            // 
            this.tbID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbID.Enabled = false;
            this.tbID.Location = new System.Drawing.Point(41, 28);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(200, 23);
            this.tbID.TabIndex = 22;
            // 
            // lblId
            // 
            this.lblId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblId.Location = new System.Drawing.Point(52, 9);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(23, 16);
            this.lblId.TabIndex = 23;
            this.lblId.Text = "ID:";
            // 
            // TournamentManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 536);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.btnEditTournament);
            this.Controls.Add(this.btnCancelTournament);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblMaxComp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTournamentSystem);
            this.Controls.Add(this.lblAdress);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTournamentName);
            this.Controls.Add(this.lblTournamets);
            this.Controls.Add(this.cbTournamentSystem);
            this.Controls.Add(this.tbAdress);
            this.Controls.Add(this.numMaxComp);
            this.Controls.Add(this.numMinComp);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbTournaments);
            this.Name = "TournamentManagement";
            this.Text = "TournamentManagement";
            this.Load += new System.EventHandler(this.TournamentManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMinComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxComp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lbTournaments;
        private TextBox tbName;
        private TextBox tbDescription;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private NumericUpDown numMinComp;
        private NumericUpDown numMaxComp;
        private TextBox tbAdress;
        private ComboBox cbTournamentSystem;
        private Label lblTournamets;
        private Label lblTournamentName;
        private Label lblDescription;
        private Label lblStartDate;
        private Label lblEndDate;
        private Label lblAdress;
        private Label lblTournamentSystem;
        private Label label1;
        private Label lblMaxComp;
        private Button btnAdd;
        private Button btnCancelTournament;
        private Button btnEditTournament;
        private Label lblLocation;
        private TextBox tbID;
        private Label lblId;
    }
}