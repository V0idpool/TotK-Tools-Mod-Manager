namespace TotKModManager
{
    partial class PreferredMirror
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferredMirror));
            nsGroupBox1 = new NSGroupBox();
            nsButton1 = new NSButton();
            linkLabel2 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            label1 = new Label();
            nsGroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // nsGroupBox1
            // 
            nsGroupBox1.Controls.Add(nsButton1);
            nsGroupBox1.Controls.Add(linkLabel2);
            nsGroupBox1.Controls.Add(linkLabel1);
            nsGroupBox1.Controls.Add(label1);
            nsGroupBox1.DrawSeperator = false;
            nsGroupBox1.Location = new Point(8, 7);
            nsGroupBox1.Margin = new Padding(2);
            nsGroupBox1.Name = "nsGroupBox1";
            nsGroupBox1.Size = new Size(457, 146);
            nsGroupBox1.SubTitle = "Select your preffered download mirror";
            nsGroupBox1.TabIndex = 0;
            nsGroupBox1.Text = "nsGroupBox1";
            nsGroupBox1.Title = "Preffered Mirror";
            // 
            // nsButton1
            // 
            nsButton1.Font = new Font("Segoe UI", 12F);
            nsButton1.Location = new Point(379, 99);
            nsButton1.Margin = new Padding(2);
            nsButton1.Name = "nsButton1";
            nsButton1.Size = new Size(66, 34);
            nsButton1.TabIndex = 1;
            nsButton1.Text = "Cancel";
            nsButton1.Click += nsButton1_Click;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Font = new Font("Segoe UI", 10F);
            linkLabel2.LinkColor = Color.FromArgb(255, 128, 0);
            linkLabel2.Location = new Point(145, 67);
            linkLabel2.Margin = new Padding(2, 0, 2, 0);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(283, 19);
            linkLabel2.TabIndex = 2;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "https://www.nexusmods.com/totk/mods/122";
            linkLabel2.VisitedLinkColor = Color.Red;
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 10F);
            linkLabel1.LinkColor = Color.FromArgb(255, 128, 0);
            linkLabel1.Location = new Point(139, 48);
            linkLabel1.Margin = new Padding(2, 0, 2, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(242, 19);
            linkLabel1.TabIndex = 1;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "https://gamebanana.com/tools/15780";
            linkLabel1.VisitedLinkColor = Color.Red;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 49);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(136, 38);
            label1.TabIndex = 0;
            label1.Text = "NexusMods Mirror:\r\nGameBanana Mirror:";
            // 
            // PreferredMirror
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            BackColor = Color.Black;
            ClientSize = new Size(473, 162);
            Controls.Add(nsGroupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PreferredMirror";
            ShowIcon = false;
            Text = "TotK Tools Mod Manager [Preffered Mirror]";
            Load += PreferredMirror_Load;
            nsGroupBox1.ResumeLayout(false);
            nsGroupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private NSGroupBox nsGroupBox1;
        private Label label1;
        private LinkLabel linkLabel1;
        private NSButton nsButton1;
        private LinkLabel linkLabel2;
    }
}