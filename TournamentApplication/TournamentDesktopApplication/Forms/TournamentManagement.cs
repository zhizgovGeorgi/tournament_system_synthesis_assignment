using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayer;

namespace TournamentDesktopApplication.Forms
{
    public partial class TournamentManagement : Form
    {
        private readonly ITournamentManager tm;
        public TournamentManagement(ITournamentManager _tournamentManagement)
        {
            InitializeComponent();
            this.tm = _tournamentManagement;
            LoadTournament();
        }

        private void TournamentManagement_Load(object sender, EventArgs e)
        {
            LoadTheme();
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
            lblTournamets.ForeColor = ThemeColour.SecondaryColour;
            //btnAdd.ForeColor = ThemeColour.PrimaryColour;
            //btnDeleteTournament.ForeColor = ThemeColour.PrimaryColour;
            //btnEditTournament.ForeColor = ThemeColour.PrimaryColour;
        }

        private void lbTournaments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTournaments.SelectedIndex < 0)
            {
                return;
            }
            Object tournamentObject = lbTournaments.SelectedItem;
            if (!(tournamentObject is Tournament))
            {
                return;
            }
            Tournament tournament = (Tournament)tournamentObject;
            tbID.Text = tournament.Id.ToString();
            tbName.Text = tournament.Name;
            tbDescription.Text = tournament.Description;
            dtpStartDate.Value = tournament.StartDate;
            dtpEndDate.Value = tournament.EndDate;
            numMinComp.Value = tournament.MinCompetitors;
            numMaxComp.Value = tournament.MaxCompetitors;
            tbAdress.Text = tournament.Adress;
            cbTournamentSystem.Text = tournament.TournamentSystem.ToString();
        }

        private void LoadTournament(Status status)
        {
            lbTournaments.Items.Clear();
            foreach (Tournament t in tm.GetAllTournaments())
            {
                if (t.Status == status)
                {
                    lbTournaments.Items.Add(t);
                }
            }
        }

        private void LoadTournament()
        {
            lbTournaments.Items.Clear();
            foreach (Tournament t in tm.GetAllTournaments())
            {
                lbTournaments.Items.Add(t);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty( tbName.Text))
            {
                MessageBox.Show("Please enter valid name");
                return;
            }
            else if (string.IsNullOrEmpty(tbDescription.Text))
            {
                MessageBox.Show("Please enter valid description");
                return;
            }
            else if (string.IsNullOrEmpty(tbAdress.Text))
            {
                MessageBox.Show("Please enter valid adress");
                return;
            }
            else if (dtpStartDate.Value == null)
            {
                MessageBox.Show("Please enter valid start date");
                return;
            }
            else if (dtpEndDate.Value == null)
            {
                MessageBox.Show("Please enter valid end date");
                return;
            }
            else if (numMinComp.Value < 0)
            {
                MessageBox.Show("Please enter valid minimum number of competitors");
                return;
            }
            else if (numMaxComp.Value <= 0)
            {
                MessageBox.Show("Please enter valid maximum number of competitors");
                return;
            }
            else if (cbTournamentSystem.SelectedItem == "")
            {
                MessageBox.Show("Please enter valid tournament system");
                return;
            }

            try
            {
                SystemDivider sd = new SystemDivider();
                Tournament t = new Tournament(tbName.Text, tbDescription.Text, dtpStartDate.Value, dtpEndDate.Value, (int)numMinComp.Value, (int)numMaxComp.Value, tbAdress.Text, sd.DivideTournamentSystems(cbTournamentSystem.Text), Status.UPCOMING);
                tm.AddTournament(t);
                LoadTournament();
                MessageBox.Show("Successful creation of tournament");
            }
            catch (MyException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void btnCancelTournament_Click(object sender, EventArgs e)
        {
            Tournament t = (Tournament)lbTournaments.SelectedItem;
            if (t is null)
            {
                MessageBox.Show("Please, select a tournament first!");
                return;
            }
            Status status = Status.CANCELED;

            if (t.Status == Status.COMPLETED || t.Status == Status.SCHEDULED)
            {
                MessageBox.Show("You can no longer update the status of this tournament");
                return;
            }
            else if (t.Status == Status.CANCELED)
            {
                MessageBox.Show("The tournament has already been cancelled!");
                return;
            }

            try
            {

                tm.UpdateTournamentStatus(t, status);
                MessageBox.Show($"Successful cancelation of tournament - {t.Name}");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditTournament_Click(object sender, EventArgs e)
        {
            try
            {
                Tournament currTournament = (Tournament)lbTournaments.SelectedItem;
                if (currTournament is null)
                {
                    MessageBox.Show("Please, select a tournament first!");
                    return;
                }
                if (currTournament.Status == Status.UPCOMING)
                {
                    SystemDivider sd = new SystemDivider();
                    Tournament t = new Tournament(Convert.ToInt32(tbID.Text), tbName.Text, tbDescription.Text, dtpStartDate.Value, dtpEndDate.Value, (int)numMinComp.Value, (int)numMaxComp.Value, tbAdress.Text, sd.DivideTournamentSystems(cbTournamentSystem.Text), currTournament.Status);
                    tm.EditTournament(t);
                    MessageBox.Show($"Successful update of tournament {t.Name} with ID: {t.Id}");
                    LoadTournament();
                }
                else
                {
                    MessageBox.Show("Too late to update the tournament! You can only update it when it is upcoming(Open for refistration)!");
                    return;
                }
            }
            catch (MyException ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }
            
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            LoadTournament();
        }

        private void rbUpcoming_CheckedChanged(object sender, EventArgs e)
        {
            Status status = Status.UPCOMING;
            LoadTournament(status);
        }

        private void rbOverDate_CheckedChanged(object sender, EventArgs e)
        {
            Status status = Status.OVERDATE;
            LoadTournament(status);
        }

        private void rbScheduled_CheckedChanged(object sender, EventArgs e)
        {
            Status status = Status.SCHEDULED;
            LoadTournament(status);
        }

        private void rbCancelled_CheckedChanged(object sender, EventArgs e)
        {
            Status status = Status.CANCELED;
            LoadTournament(status);
        }
    }
}
