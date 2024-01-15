namespace TotKModManager
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            nsGroupBox1 = new NSGroupBox();
            linkLabel4 = new LinkLabel();
            nsButton1 = new NSButton();
            linkLabel3 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            label1 = new Label();
            nsGroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // nsGroupBox1
            // 
            nsGroupBox1.Controls.Add(linkLabel4);
            nsGroupBox1.Controls.Add(nsButton1);
            nsGroupBox1.Controls.Add(linkLabel3);
            nsGroupBox1.Controls.Add(linkLabel2);
            nsGroupBox1.Controls.Add(linkLabel1);
            nsGroupBox1.Controls.Add(label1);
            nsGroupBox1.DrawSeperator = false;
            nsGroupBox1.Location = new Point(8, 7);
            nsGroupBox1.Margin = new Padding(2);
            nsGroupBox1.Name = "nsGroupBox1";
            nsGroupBox1.Size = new Size(456, 266);
            nsGroupBox1.SubTitle = "";
            nsGroupBox1.TabIndex = 0;
            nsGroupBox1.Text = "nsGroupBox1";
            nsGroupBox1.Title = "About Us";
            // 
            // linkLabel4
            // 
            linkLabel4.AutoSize = true;
            linkLabel4.Font = new Font("Segoe UI", 10F);
            linkLabel4.LinkColor = Color.FromArgb(255, 128, 0);
            linkLabel4.Location = new Point(100, 234);
            linkLabel4.Margin = new Padding(2, 0, 2, 0);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new Size(52, 19);
            linkLabel4.TabIndex = 4;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "Credits";
            linkLabel4.VisitedLinkColor = Color.Red;
            linkLabel4.LinkClicked += this.linkLabel4_LinkClicked;
            // 
            // nsButton1
            // 
            nsButton1.Font = new Font("Segoe UI", 12F);
            nsButton1.Location = new Point(392, 224);
            nsButton1.Margin = new Padding(2);
            nsButton1.Name = "nsButton1";
            nsButton1.Size = new Size(56, 34);
            nsButton1.TabIndex = 1;
            nsButton1.Text = "Close";
            nsButton1.Click += this.nsButton1_Click;
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.Font = new Font("Segoe UI", 10F);
            linkLabel3.LinkColor = Color.FromArgb(255, 128, 0);
            linkLabel3.Location = new Point(99, 215);
            linkLabel3.Margin = new Padding(2, 0, 2, 0);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(131, 19);
            linkLabel3.TabIndex = 3;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "CashApp Donations";
            linkLabel3.VisitedLinkColor = Color.Red;
            linkLabel3.LinkClicked += this.linkLabel3_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Font = new Font("Segoe UI", 10F);
            linkLabel2.LinkColor = Color.FromArgb(255, 128, 0);
            linkLabel2.Location = new Point(99, 195);
            linkLabel2.Margin = new Padding(2, 0, 2, 0);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(100, 19);
            linkLabel2.TabIndex = 2;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "BuyMeACoffee";
            linkLabel2.VisitedLinkColor = Color.Red;
            linkLabel2.LinkClicked += this.linkLabel2_LinkClicked;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 10F);
            linkLabel1.LinkColor = Color.FromArgb(255, 128, 0);
            linkLabel1.Location = new Point(157, 100);
            linkLabel1.Margin = new Padding(2, 0, 2, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(157, 19);
            linkLabel1.TabIndex = 1;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "xxvoidxxmlg@gmail.com";
            linkLabel1.VisitedLinkColor = Color.Red;
            linkLabel1.LinkClicked += this.linkLabel1_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(5, 25);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(443, 228);
            label1.TabIndex = 0;
            label1.Text = resources.GetString("label1.Text");
            // 
            // AboutForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            BackColor = Color.Black;
            ClientSize = new Size(474, 284);
            Controls.Add(nsGroupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            ShowIcon = false;
            Text = "TotK Tools Mod Manager [About]";
            Load += this.AboutForm_Load;
            nsGroupBox1.ResumeLayout(false);
            nsGroupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private NSGroupBox nsGroupBox1;
        private Label label1;
        private LinkLabel linkLabel1;
        private NSButton nsButton1;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel4;
    }
}