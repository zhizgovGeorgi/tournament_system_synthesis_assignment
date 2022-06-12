namespace TournamentDesktopApplication.Forms
{
    partial class ResultsManagement
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
            this.lbRounds = new System.Windows.Forms.ListBox();
            this.lbMatches = new System.Windows.Forms.ListBox();
            this.numPlayer1 = new System.Windows.Forms.NumericUpDown();
            this.numPlayer2 = new System.Windows.Forms.NumericUpDown();
            this.btnSaveResult = new System.Windows.Forms.Button();
            this.lblResultManagement = new System.Windows.Forms.Label();
            this.lblTournaments = new System.Windows.Forms.Label();
            this.lblRounds = new System.Windows.Forms.Label();
            this.lblMatch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayer2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTournaments
            // 
            this.lbTournaments.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTournaments.FormattingEnabled = true;
            this.lbTournaments.ItemHeight = 15;
            this.lbTournaments.Location = new System.Drawing.Point(39, 80);
            this.lbTournaments.Name = "lbTournaments";
            this.lbTournaments.Size = new System.Drawing.Size(172, 304);
            this.lbTournaments.TabIndex = 0;
            this.lbTournaments.SelectedIndexChanged += new System.EventHandler(this.lbTournaments_SelectedIndexChanged);
            // 
            // lbRounds
            // 
            this.lbRounds.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbRounds.FormattingEnabled = true;
            this.lbRounds.ItemHeight = 15;
            this.lbRounds.Location = new System.Drawing.Point(245, 80);
            this.lbRounds.Name = "lbRounds";
            this.lbRounds.Size = new System.Drawing.Size(86, 304);
            this.lbRounds.TabIndex = 1;
            this.lbRounds.SelectedIndexChanged += new System.EventHandler(this.lbRounds_SelectedIndexChanged);
            // 
            // lbMatches
            // 
            this.lbMatches.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbMatches.FormattingEnabled = true;
            this.lbMatches.ItemHeight = 15;
            this.lbMatches.Location = new System.Drawing.Point(375, 80);
            this.lbMatches.Name = "lbMatches";
            this.lbMatches.Size = new System.Drawing.Size(278, 304);
            this.lbMatches.TabIndex = 2;
            this.lbMatches.SelectedIndexChanged += new System.EventHandler(this.lbMatches_SelectedIndexChanged);
            // 
            // numPlayer1
            // 
            this.numPlayer1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numPlayer1.Location = new System.Drawing.Point(680, 90);
            this.numPlayer1.Name = "numPlayer1";
            this.numPlayer1.Size = new System.Drawing.Size(73, 23);
            this.numPlayer1.TabIndex = 3;
            // 
            // numPlayer2
            // 
            this.numPlayer2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numPlayer2.Location = new System.Drawing.Point(680, 217);
            this.numPlayer2.Name = "numPlayer2";
            this.numPlayer2.Size = new System.Drawing.Size(73, 23);
            this.numPlayer2.TabIndex = 4;
            // 
            // btnSaveResult
            // 
            this.btnSaveResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSaveResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveResult.Location = new System.Drawing.Point(669, 310);
            this.btnSaveResult.Name = "btnSaveResult";
            this.btnSaveResult.Size = new System.Drawing.Size(96, 38);
            this.btnSaveResult.TabIndex = 5;
            this.btnSaveResult.Text = "Save Result";
            this.btnSaveResult.UseVisualStyleBackColor = true;
            this.btnSaveResult.Click += new System.EventHandler(this.btnSaveResult_Click);
            // 
            // lblResultManagement
            // 
            this.lblResultManagement.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblResultManagement.AutoSize = true;
            this.lblResultManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblResultManagement.Location = new System.Drawing.Point(258, 19);
            this.lblResultManagement.Name = "lblResultManagement";
            this.lblResultManagement.Size = new System.Drawing.Size(153, 20);
            this.lblResultManagement.TabIndex = 6;
            this.lblResultManagement.Text = "Result Management";
            // 
            // lblTournaments
            // 
            this.lblTournaments.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTournaments.AutoSize = true;
            this.lblTournaments.Location = new System.Drawing.Point(40, 56);
            this.lblTournaments.Name = "lblTournaments";
            this.lblTournaments.Size = new System.Drawing.Size(76, 15);
            this.lblTournaments.TabIndex = 7;
            this.lblTournaments.Text = "Tournaments";
            // 
            // lblRounds
            // 
            this.lblRounds.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRounds.AutoSize = true;
            this.lblRounds.Location = new System.Drawing.Point(245, 56);
            this.lblRounds.Name = "lblRounds";
            this.lblRounds.Size = new System.Drawing.Size(47, 15);
            this.lblRounds.TabIndex = 8;
            this.lblRounds.Text = "Rounds";
            // 
            // lblMatch
            // 
            this.lblMatch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMatch.AutoSize = true;
            this.lblMatch.Location = new System.Drawing.Point(375, 56);
            this.lblMatch.Name = "lblMatch";
            this.lblMatch.Size = new System.Drawing.Size(52, 15);
            this.lblMatch.TabIndex = 9;
            this.lblMatch.Text = "Matches";
            // 
            // ResultsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMatch);
            this.Controls.Add(this.lblRounds);
            this.Controls.Add(this.lblTournaments);
            this.Controls.Add(this.lblResultManagement);
            this.Controls.Add(this.btnSaveResult);
            this.Controls.Add(this.numPlayer2);
            this.Controls.Add(this.numPlayer1);
            this.Controls.Add(this.lbMatches);
            this.Controls.Add(this.lbRounds);
            this.Controls.Add(this.lbTournaments);
            this.Name = "ResultsManagement";
            this.Text = "ResultsManagement";
            this.Load += new System.EventHandler(this.ResultsManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayer2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lbTournaments;
        private ListBox lbRounds;
        private ListBox lbMatches;
        private NumericUpDown numPlayer1;
        private NumericUpDown numPlayer2;
        private Button btnSaveResult;
        private Label lblResultManagement;
        private Label lblTournaments;
        private Label lblRounds;
        private Label lblMatch;
    }
}