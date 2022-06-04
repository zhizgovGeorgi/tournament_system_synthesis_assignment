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
            //if (tbName.Text == "")
            //{
            //    MessageBox.Show("Please enter valid name");
            //    return;
            //}
            //else if (tbDescription.Text == "")
            //{
            //    MessageBox.Show("Please enter valid description");
            //    return;
            //}
            //else if (tbAdress.Text == "")
            //{
            //    MessageBox.Show("Please enter valid adress");
            //    return;
            //}
            //else if (dtpStartDate.Value == null)
            //{
            //    MessageBox.Show("Please enter valid start date");
            //    return;
            //}
            //else if (dtpEndDate.Value == null)
            //{
            //    MessageBox.Show("Please enter valid end date");
            //    return;
            //}
            //else if (numMinComp.Value < 0)
            //{
            //    MessageBox.Show("Please enter valid minimum number of competitors");
            //    return;
            //}
            //else if (numMaxComp.Value <= 0)
            //{
            //    MessageBox.Show("Please enter valid maximum number of competitors");
            //    return;
            //}
            //else if (cbTournamentSystem.SelectedItem == "")
            //{
            //    MessageBox.Show("Please enter valid tournament system");
            //    return;
            //}

            SystemDivider sd = new SystemDivider();
            Tournament t = new Tournament(tbName.Text, tbDescription.Text, dtpStartDate.Value, dtpEndDate.Value, (int)numMinComp.Value, (int)numMaxComp.Value, tbAdress.Text, sd.DivideTournamentSystems(cbTournamentSystem.Text), Status.UPCOMING);
            try
            {
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

                throw ex;
            }

        }

        private void btnCancelTournament_Click(object sender, EventArgs e)
        {
            Tournament t = (Tournament)lbTournaments.SelectedItem;
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
    }
}
