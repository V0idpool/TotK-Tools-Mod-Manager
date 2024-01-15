namespace TotKModManager
{
    partial class Emudetector
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Emudetector));
            nsLabel3 = new NSLabel();
            nsButton7 = new NSButton();
            nsComboBox1 = new NSComboBox();
            nsLabel1 = new NSLabel();
            nsLabel2 = new NSLabel();
            nsGroupBox1 = new NSGroupBox();
            nsLabel4 = new NSLabel();
            nsButton1 = new NSButton();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            nsGroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // nsLabel3
            // 
            nsLabel3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            nsLabel3.Location = new Point(24, 32);
            nsLabel3.Margin = new Padding(2);
            nsLabel3.Name = "nsLabel3";
            nsLabel3.Size = new Size(346, 23);
            nsLabel3.TabIndex = 6;
            nsLabel3.Text = "nsLabel3";
            nsLabel3.Value1 = "Indicate the Drive that your YUZU install is located on.";
            nsLabel3.Value2 = "";
            // 
            // nsButton7
            // 
            nsButton7.Font = new Font("Segoe UI", 12F);
            nsButton7.Location = new Point(306, 139);
            nsButton7.Margin = new Padding(2);
            nsButton7.Name = "nsButton7";
            nsButton7.Size = new Size(79, 25);
            nsButton7.TabIndex = 7;
            nsButton7.Text = "Continue";
            nsButton7.Click += nsButton7_Click;
            // 
            // nsComboBox1
            // 
            nsComboBox1.BackColor = Color.FromArgb(50, 50, 50);
            nsComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            nsComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            nsComboBox1.ForeColor = Color.White;
            nsComboBox1.Location = new Point(8, 140);
            nsComboBox1.Margin = new Padding(2);
            nsComboBox1.MaxLength = 32767;
            nsComboBox1.Name = "nsComboBox1";
            nsComboBox1.Size = new Size(227, 24);
            nsComboBox1.TabIndex = 8;
            // 
            // nsLabel1
            // 
            nsLabel1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            nsLabel1.Location = new Point(12, 56);
            nsLabel1.Margin = new Padding(2);
            nsLabel1.Name = "nsLabel1";
            nsLabel1.Size = new Size(370, 54);
            nsLabel1.TabIndex = 9;
            nsLabel1.Text = "nsLabel1";
            nsLabel1.Value1 = "";
            nsLabel1.Value2 = " This may take a minute or two to scan, please be patient! ";
            // 
            // nsLabel2
            // 
            nsLabel2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            nsLabel2.Location = new Point(132, 109);
            nsLabel2.Margin = new Padding(2);
            nsLabel2.Name = "nsLabel2";
            nsLabel2.Size = new Size(131, 28);
            nsLabel2.TabIndex = 10;
            nsLabel2.Text = "nsLabel2";
            nsLabel2.Value1 = "Status: ";
            nsLabel2.Value2 = " Waiting...";
            // 
            // nsGroupBox1
            // 
            nsGroupBox1.Controls.Add(nsLabel3);
            nsGroupBox1.Controls.Add(nsLabel4);
            nsGroupBox1.Controls.Add(nsButton1);
            nsGroupBox1.Controls.Add(nsLabel2);
            nsGroupBox1.Controls.Add(nsLabel1);
            nsGroupBox1.Controls.Add(nsComboBox1);
            nsGroupBox1.Controls.Add(nsButton7);
            nsGroupBox1.DrawSeperator = false;
            nsGroupBox1.Location = new Point(3, 2);
            nsGroupBox1.Margin = new Padding(2);
            nsGroupBox1.Name = "nsGroupBox1";
            nsGroupBox1.Size = new Size(395, 174);
            nsGroupBox1.SubTitle = "";
            nsGroupBox1.TabIndex = 11;
            nsGroupBox1.Text = "nsGroupBox1";
            nsGroupBox1.Title = "YUZU Auto Detect";
            // 
            // nsLabel4
            // 
            nsLabel4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            nsLabel4.Location = new Point(33, 42);
            nsLabel4.Margin = new Padding(2);
            nsLabel4.Name = "nsLabel4";
            nsLabel4.Size = new Size(326, 41);
            nsLabel4.TabIndex = 12;
            nsLabel4.Text = "nsLabel4";
            nsLabel4.Value1 = "";
            nsLabel4.Value2 = " The UI will freeze and block input until complete. ";
            // 
            // nsButton1
            // 
            nsButton1.Font = new Font("Segoe UI", 12F);
            nsButton1.Location = new Point(239, 139);
            nsButton1.Margin = new Padding(2);
            nsButton1.Name = "nsButton1";
            nsButton1.Size = new Size(63, 25);
            nsButton1.TabIndex = 11;
            nsButton1.Text = "Cancel";
            nsButton1.Click += nsButton1_Click;
            // 
            // timer1
            // 
            timer1.Interval = 2500;
            timer1.Tick += timer1_Tick;
            // 
            // timer2
            // 
            timer2.Tick += timer2_Tick;
            // 
            // Emudetector
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(399, 178);
            Controls.Add(nsGroupBox1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Emudetector";
            Text = "TotK Tools Mod Manager [EMU Drive Location]";
            Load += Emudetector_Load;
            nsGroupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TotKModManager.NSLabel nsLabel3;
        private TotKModManager.NSButton nsButton7;
        private TotKModManager.NSComboBox nsComboBox1;
        private NSLabel nsLabel1;
        private NSLabel nsLabel2;
        private NSGroupBox nsGroupBox1;
        private System.Windows.Forms.Timer timer1;
        private NSButton nsButton1;
        private System.Windows.Forms.Timer timer2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private NSLabel nsLabel4;
    }
}