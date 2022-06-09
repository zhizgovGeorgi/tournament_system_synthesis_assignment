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


            if (t.Status == Status.SCHEDULED || t.Status == Status.COMPLETED)
            {
                mm.GetMatchesForTournaament(t);
                LoadRounds(t);

            }
            else if (t.Status == Status.OVERDATE)
            {
                List<Match> matches = t.TournamentSystem.CreateMatchSchedule(t.Competitors, t);
                mm.AddMatch(matches, t);
                LoadRounds(t);
                MessageBox.Show($"Schedule has just been generated for {t.Name} tournament!");
            }
            else if (t.Status == Status.CANCELED)
            {
                MessageBox.Show($"Unfortunately, this tournament has been cancelled!");
                return;
            }
            else
            {
                MessageBox.Show($"It is too late to load the matches!");
                return;
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
            Tournament t = (Tournament)lbTournaments.SelectedItem;
            LoadMatches(t);
            
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


        private void btnSaveResult_Click(object sender, EventArgs e)
        {
            try
            {
                Match m = (Match)lbMatches.SelectedItem;
                Tournament t = (Tournament)lbTournaments.SelectedItem;
                if (m.IsComplete == true)
                {
                    MessageBox.Show("Once a score is set it cannot be reset !");
                    return;
                }
                m.SetScore((int)numPlayer1.Value, (int)numPlayer2.Value);
                mm.SetScore(m, t);
                tm.CheckIfComplete(t);
                MessageBox.Show("Successful update of score of the match");
            }
            catch (MyException ex)
            {

                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private void lbMatches_DoubleClick(object sender, EventArgs e)
        {
            Match m = (Match)lbMatches.SelectedItem;
            numPlayer1.Value = m.Player1.Score;
            numPlayer2.Value = m.Player2.Score;
        }

        
    }
}
