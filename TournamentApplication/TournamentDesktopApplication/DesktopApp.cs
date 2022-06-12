using LogicLayer;

namespace TournamentDesktopApplication
{
    public partial class DesktopApp : Form
    {
        private Button currButton;
        private Random random;
        private int tempIndex;
        private Form activeFrom;
        private readonly ITournamentManager tm;
        private readonly IMatchManager mm;
        private readonly IUserManger um;
        public DesktopApp(ITournamentManager tm, IMatchManager mm, IUserManger um)
        {
            InitializeComponent();
            random = new Random();
            btnReset.Visible = false;
            this.tm = tm;
            this.um = um;
            this.mm = mm;
        }

        private Color SelectThemeColour()
        {
            int index = random.Next(ThemeColour.ColourList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColour.ColourList.Count);
            }
            tempIndex = index;
            string colour = ThemeColour.ColourList[index];
            return ColorTranslator.FromHtml(colour);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currButton != (Button)btnSender)
                {
                    DisableButton();
                    Color colour = SelectThemeColour();
                    currButton = (Button)btnSender;
                    currButton.BackColor = colour;
                    currButton.ForeColor = Color.White;
                    currButton.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    panelTitleBar.BackColor = colour;
                    paneLogo.BackColor = ThemeColour.ChangeColourBrightness(colour, -0.3);
                    ThemeColour.PrimaryColour = colour;
                    ThemeColour.SecondaryColour = ThemeColour.ChangeColourBrightness(colour, -0.3);
                    btnReset.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control prevButton in panelMenu.Controls)
            {
                if (prevButton.GetType() == typeof(Button))
                {
                    prevButton.BackColor = Color.FromArgb(51, 51, 76);
                    prevButton.ForeColor = Color.Gainsboro;
                    prevButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeFrom != null)
            {
                activeFrom.Close();
            }
            ActivateButton(btnSender);
            activeFrom = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

     

        private void btnTournaments_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.TournamentManagement(tm), sender);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (activeFrom!=null)
            {
                activeFrom.Close();
                Reset();
            }
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(51, 51, 76);
            paneLogo.BackColor = Color.FromArgb(39, 39, 58);
            currButton = null;
            btnReset.Visible = false;
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.ResultsManagement(tm, mm), sender);
        }
    }
}