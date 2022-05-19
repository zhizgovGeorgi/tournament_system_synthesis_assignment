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
    public partial class UserManagement : Form
    {
        public UserManagement()
        {
            InitializeComponent();
        }

        private void UserManagement_Load(object sender, EventArgs e)
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
           // lblLBEmployees.ForeColor = ThemeColour.SecondaryColour;
           // lblPrimary.ForeColor = ThemeColour.PrimaryColour;
        }
    }
}
