namespace TotKModManager
{
    public partial class PreferredMirror : Form
    {
        public PreferredMirror()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://gamebanana.com/tools/15780");//email open
            Application.Exit();
        }

        private void nsButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://www.nexusmods.com/legendofzeldatearsofthekingdom/mods/122");//bmac open
            Application.Exit();
        }

       
        private void PreferredMirror_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var credits = new CreditsForm();
            credits.Show();
           
        }
    }
}
