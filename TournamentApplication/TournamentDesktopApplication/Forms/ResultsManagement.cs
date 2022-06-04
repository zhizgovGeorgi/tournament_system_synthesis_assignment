using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TournamentDesktopApplication.Forms
{
    public partial class ResultsManagement : Form
    {
        ITournamentManager tm;
        IMatchManager mm;
        public ResultsManagement(ITournamentManager tm, IMatchManager mm)
        {
            InitializeComponent();
            this.tm = tm;
            this.mm = mm;
        }

        private void ResultsManagement_Load(object sender, EventArgs e)
        {
            LoadTheme();
            LoadTournaments();
        }

        private void LoadTournaments()
        {
            lbTournaments.Items.Clear();
            foreach (Tournament t in tm.GetAllTournaments())
            {
                lbTournaments.Items.Add(t);
            }
        }

        private void LoadRounds(Tournament t)
        {
            lbRounds.Items.Clear();
            for (int i = 1; i < t.Competitors.Count; i++)
            {
                lbRounds.Items.Add(i);
            }
        }

        private void LoadMatches(Tournament t)
        {
            lbMatches.Items.Clear();


            if (t.Status == Status.SCHEDULED)
            {
                mm.GetMatchesForTournaament(t);

            }
            else if (t.Status == Status.OVERDATE)
            {
                List<Match> matches = t.TournamentSystem.CreateMatchSchedule(t.Competitors, t);
                mm.AddMatch(matches, t);
                MessageBox.Show($"Schedule has just been generated for {t.Name} tournament!");
            }
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btns.BackColor = ThemeColour.PrimaryColour;
                    btns.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColour.SecondaryColour;

                }
            }
            lblResultManagement.ForeColor = ThemeColour.SecondaryColour;
            //btnAdd.ForeColor = ThemeColour.PrimaryColour;
            //btnDeleteTournament.ForeColor = ThemeColour.PrimaryColour;
            //btnEditTournament.ForeColor = ThemeColour.PrimaryColour;
        }

        private void lbTournaments_DoubleClick(object sender, EventArgs e)
        {
            LoadRounds((Tournament)lbTournaments.SelectedItem);
        }

        private void lbTournaments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbRounds_DoubleClick(object sender, EventArgs e)
        {
            lbMatches.Items.Clear();
            Tournament t = (Tournament)lbTournaments.SelectedItem;
            try
            {
                foreach (Match m in t.Matches)
                {
                    if (m.Rounds == (int)lbRounds.SelectedItem)
                    {
                        lbMatches.Items.Add(m);
                    }
                }

            }
            catch (MyException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnGenerateSchedule_Click(object sender, EventArgs e)
        {

            Tournament t = (Tournament)lbTournaments.SelectedItem;
            LoadMatches(t);
            
        }

        private void btnSaveResult_Click(object sender, EventArgs e)
        {

        }
    }
}
