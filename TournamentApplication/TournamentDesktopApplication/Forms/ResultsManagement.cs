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
            if (t is null)
            {
                return;
            }
            lbRounds.Items.Clear();
            for (int i = 1; i <= t.TournamentSystem.CalculateRounds(t.Competitors.Count); i++)
            {
                lbRounds.Items.Add(i);
            }
        }

        private void LoadMatches(Tournament t)
        {
            lbMatches.Items.Clear();

            if (t is null)
            {
                return;
            }

            if (t.Status == Status.SCHEDULED || t.Status == Status.COMPLETED)
            {
                mm.GetMatchesForTournament(t);

            }
            else if (t.Status == Status.OVERDATE)
            {
                List<Match> matches = t.TournamentSystem.CreateMatchSchedule(t);
                mm.AddMatch(matches, t);
                MessageBox.Show($"Schedule has just been generated for {t.Name} tournament!");
                lbRounds.Items.Clear();
                LoadTournaments();
            }
            else if (t.Status == Status.CANCELED)
            {
                MessageBox.Show($"Unfortunately, this tournament has been cancelled!");
                lbRounds.Items.Clear();
                return;
            }
            else
            {
                lbRounds.Items.Clear();
                MessageBox.Show($"It is too early to load the matches!");
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



        private void lbTournaments_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tournament t = (Tournament)lbTournaments.SelectedItem;
            if (t is null)
            {
                MessageBox.Show("No tournament selected");
                return;
            }
            LoadRounds(t);
            LoadMatches(t);
            tm.CheckIfComplete(t);
        }

        private void lbMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            Match m = (Match)lbMatches.SelectedItem;
            if (m is null)
            {
                MessageBox.Show("No match selected");
                return;
            }
            numPlayer1.Value = m.Player1.Score;
            numPlayer2.Value = m.Player2.Score;
        }

        private void lbRounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbMatches.Items.Clear();
            Tournament t = (Tournament)lbTournaments.SelectedItem;
            if (t is null)
            {
                MessageBox.Show("No tournament selected");
                return;
            }

            try
            {
                if (lbRounds.SelectedItem is null)
                {
                    MessageBox.Show("No tournament selected");
                    return;
                }
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


    }
}
