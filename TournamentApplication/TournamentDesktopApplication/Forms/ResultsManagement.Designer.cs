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
            ((System.ComponentModel.ISupportInitialize)(this.numPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayer2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTournaments
            // 
            this.lbTournaments.FormattingEnabled = true;
            this.lbTournaments.ItemHeight = 15;
            this.lbTournaments.Location = new System.Drawing.Point(39, 80);
            this.lbTournaments.Name = "lbTournaments";
            this.lbTournaments.Size = new System.Drawing.Size(138, 304);
            this.lbTournaments.TabIndex = 0;
            // 
            // lbRounds
            // 
            this.lbRounds.FormattingEnabled = true;
            this.lbRounds.ItemHeight = 15;
            this.lbRounds.Location = new System.Drawing.Point(240, 80);
            this.lbRounds.Name = "lbRounds";
            this.lbRounds.Size = new System.Drawing.Size(48, 304);
            this.lbRounds.TabIndex = 1;
            // 
            // lbMatches
            // 
            this.lbMatches.FormattingEnabled = true;
            this.lbMatches.ItemHeight = 15;
            this.lbMatches.Location = new System.Drawing.Point(348, 80);
            this.lbMatches.Name = "lbMatches";
            this.lbMatches.Size = new System.Drawing.Size(284, 304);
            this.lbMatches.TabIndex = 2;
            // 
            // numPlayer1
            // 
            this.numPlayer1.Location = new System.Drawing.Point(680, 90);
            this.numPlayer1.Name = "numPlayer1";
            this.numPlayer1.Size = new System.Drawing.Size(73, 23);
            this.numPlayer1.TabIndex = 3;
            // 
            // numPlayer2
            // 
            this.numPlayer2.Location = new System.Drawing.Point(680, 217);
            this.numPlayer2.Name = "numPlayer2";
            this.numPlayer2.Size = new System.Drawing.Size(73, 23);
            this.numPlayer2.TabIndex = 4;
            // 
            // btnSaveResult
            // 
            this.btnSaveResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveResult.Location = new System.Drawing.Point(670, 291);
            this.btnSaveResult.Name = "btnSaveResult";
            this.btnSaveResult.Size = new System.Drawing.Size(96, 38);
            this.btnSaveResult.TabIndex = 5;
            this.btnSaveResult.Text = "Save Result";
            this.btnSaveResult.UseVisualStyleBackColor = true;
            // 
            // lblResultManagement
            // 
            this.lblResultManagement.AutoSize = true;
            this.lblResultManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblResultManagement.Location = new System.Drawing.Point(258, 19);
            this.lblResultManagement.Name = "lblResultManagement";
            this.lblResultManagement.Size = new System.Drawing.Size(153, 20);
            this.lblResultManagement.TabIndex = 6;
            this.lblResultManagement.Text = "Result Management";
            // 
            // ResultsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}