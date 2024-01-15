namespace TotKModManager
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            Outputbox = new TextBox();
            nsGroupBox1 = new NSGroupBox();
            nsTextBox1 = new NSTextBox();
            nsLabel1 = new NSLabel();
            nsGroupBox2 = new NSGroupBox();
            nsLabel2 = new NSLabel();
            nsTabControl1 = new NSTabControl();
            tabPage1 = new TabPage();
            nsButton2 = new NSButton();
            nsButton1 = new NSButton();
            nsLabel3 = new NSLabel();
            nsLabel4 = new NSLabel();
            tabPage2 = new TabPage();
            nsButton3 = new NSButton();
            nsButton4 = new NSButton();
            nsLabel5 = new NSLabel();
            nsTextBox2 = new NSTextBox();
            nsLabel6 = new NSLabel();
            nsLabel7 = new NSLabel();
            tabPage3 = new TabPage();
            nsButton9 = new NSButton();
            nsTextBox5 = new NSTextBox();
            nsLabel12 = new NSLabel();
            nsButton7 = new NSButton();
            nsTextBox4 = new NSTextBox();
            nsButton5 = new NSButton();
            nsButton6 = new NSButton();
            nsLabel8 = new NSLabel();
            nsTextBox3 = new NSTextBox();
            nsLabel9 = new NSLabel();
            nsLabel10 = new NSLabel();
            nsLabel11 = new NSLabel();
            tabPage4 = new TabPage();
            nsLabel15 = new NSLabel();
            nsButton8 = new NSButton();
            nsTextBox6 = new NSTextBox();
            nsLabel13 = new NSLabel();
            nsButton10 = new NSButton();
            nsTextBox7 = new NSTextBox();
            nsLabel14 = new NSLabel();
            nsButton11 = new NSButton();
            nsButton12 = new NSButton();
            nsTextBox8 = new NSTextBox();
            nsLabel17 = new NSLabel();
            nsLabel23 = new NSLabel();
            nsLabel16 = new NSLabel();
            tabPage5 = new TabPage();
            nsButton14 = new NSButton();
            nsTextBox10 = new NSTextBox();
            nsLabel19 = new NSLabel();
            nsButton15 = new NSButton();
            nsButton16 = new NSButton();
            nsLabel20 = new NSLabel();
            nsTextBox11 = new NSTextBox();
            nsLabel21 = new NSLabel();
            nsLabel22 = new NSLabel();
            nsGroupBox1.SuspendLayout();
            nsGroupBox2.SuspendLayout();
            nsTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            SuspendLayout();
            // 
            // Outputbox
            // 
            Outputbox.BackColor = Color.Black;
            Outputbox.BorderStyle = BorderStyle.FixedSingle;
            Outputbox.ForeColor = Color.White;
            Outputbox.Location = new Point(3, 51);
            Outputbox.Multiline = true;
            Outputbox.Name = "Outputbox";
            Outputbox.ReadOnly = true;
            Outputbox.ScrollBars = ScrollBars.Vertical;
            Outputbox.Size = new Size(772, 281);
            Outputbox.TabIndex = 0;
            Outputbox.Text = resources.GetString("Outputbox.Text");
            // 
            // nsGroupBox1
            // 
            nsGroupBox1.BackColor = SystemColors.ActiveCaptionText;
            nsGroupBox1.Controls.Add(Outputbox);
            nsGroupBox1.DrawSeperator = false;
            nsGroupBox1.ForeColor = Color.White;
            nsGroupBox1.Location = new Point(11, 237);
            nsGroupBox1.Margin = new Padding(2);
            nsGroupBox1.Name = "nsGroupBox1";
            nsGroupBox1.Size = new Size(778, 335);
            nsGroupBox1.SubTitle = "Output Is Displayed Here";
            nsGroupBox1.TabIndex = 1;
            nsGroupBox1.Text = "nsGroupBox1";
            nsGroupBox1.Title = "RSTB Tool Output";
            // 
            // nsTextBox1
            // 
            nsTextBox1.Location = new Point(126, 145);
            nsTextBox1.Margin = new Padding(2);
            nsTextBox1.MaxLength = 32767;
            nsTextBox1.Multiline = false;
            nsTextBox1.Name = "nsTextBox1";
            nsTextBox1.ReadOnly = false;
            nsTextBox1.Size = new Size(402, 22);
            nsTextBox1.TabIndex = 2;
            nsTextBox1.TextAlign = HorizontalAlignment.Left;
            nsTextBox1.UseSystemPasswordChar = false;
            // 
            // nsLabel1
            // 
            nsLabel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            nsLabel1.Location = new Point(7, 144);
            nsLabel1.Name = "nsLabel1";
            nsLabel1.Size = new Size(121, 23);
            nsLabel1.TabIndex = 6;
            nsLabel1.Text = "nsLabel1";
            nsLabel1.Value1 = "File To Convert:";
            nsLabel1.Value2 = "";
            // 
            // nsGroupBox2
            // 
            nsGroupBox2.Controls.Add(nsLabel2);
            nsGroupBox2.Controls.Add(nsTabControl1);
            nsGroupBox2.DrawSeperator = false;
            nsGroupBox2.Location = new Point(12, 12);
            nsGroupBox2.Name = "nsGroupBox2";
            nsGroupBox2.Size = new Size(777, 220);
            nsGroupBox2.SubTitle = "";
            nsGroupBox2.TabIndex = 8;
            nsGroupBox2.Text = "nsGroupBox2";
            nsGroupBox2.Title = "RSTB Tool";
            // 
            // nsLabel2
            // 
            nsLabel2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsLabel2.Location = new Point(342, 10);
            nsLabel2.Name = "nsLabel2";
            nsLabel2.Size = new Size(226, 21);
            nsLabel2.TabIndex = 7;
            nsLabel2.Text = "nsLabel2";
            nsLabel2.Value1 = " ";
            nsLabel2.Value2 = " EXPERIMENTAL FEATURES";
            // 
            // nsTabControl1
            // 
            nsTabControl1.Alignment = TabAlignment.Left;
            nsTabControl1.Controls.Add(tabPage1);
            nsTabControl1.Controls.Add(tabPage2);
            nsTabControl1.Controls.Add(tabPage3);
            nsTabControl1.Controls.Add(tabPage4);
            nsTabControl1.Controls.Add(tabPage5);
            nsTabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            nsTabControl1.ItemSize = new Size(28, 115);
            nsTabControl1.Location = new Point(3, 37);
            nsTabControl1.Multiline = true;
            nsTabControl1.Name = "nsTabControl1";
            nsTabControl1.SelectedIndex = 0;
            nsTabControl1.Size = new Size(771, 179);
            nsTabControl1.SizeMode = TabSizeMode.Fixed;
            nsTabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(50, 50, 50);
            tabPage1.Controls.Add(nsButton2);
            tabPage1.Controls.Add(nsButton1);
            tabPage1.Controls.Add(nsLabel3);
            tabPage1.Controls.Add(nsTextBox1);
            tabPage1.Controls.Add(nsLabel4);
            tabPage1.Controls.Add(nsLabel1);
            tabPage1.Location = new Point(119, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(648, 171);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "YAML Conversion";
            // 
            // nsButton2
            // 
            nsButton2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsButton2.Location = new Point(614, 145);
            nsButton2.Name = "nsButton2";
            nsButton2.Size = new Size(28, 23);
            nsButton2.TabIndex = 11;
            nsButton2.Text = "...";
            nsButton2.Click += nsButton2_Click;
            // 
            // nsButton1
            // 
            nsButton1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nsButton1.Location = new Point(533, 145);
            nsButton1.Name = "nsButton1";
            nsButton1.Size = new Size(75, 23);
            nsButton1.TabIndex = 10;
            nsButton1.Text = "Convert";
            nsButton1.Click += nsButton1_Click;
            // 
            // nsLabel3
            // 
            nsLabel3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsLabel3.Location = new Point(158, 38);
            nsLabel3.Name = "nsLabel3";
            nsLabel3.Size = new Size(333, 31);
            nsLabel3.TabIndex = 8;
            nsLabel3.Text = "nsLabel3";
            nsLabel3.Value1 = "Select the YAML file to be converted to ZS.";
            nsLabel3.Value2 = " ";
            // 
            // nsLabel4
            // 
            nsLabel4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsLabel4.Location = new Point(93, 61);
            nsLabel4.Name = "nsLabel4";
            nsLabel4.Size = new Size(462, 31);
            nsLabel4.TabIndex = 9;
            nsLabel4.Text = "nsLabel4";
            nsLabel4.Value1 = " Information will be displayed in the output window below";
            nsLabel4.Value2 = " ";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(50, 50, 50);
            tabPage2.Controls.Add(nsButton3);
            tabPage2.Controls.Add(nsButton4);
            tabPage2.Controls.Add(nsLabel5);
            tabPage2.Controls.Add(nsTextBox2);
            tabPage2.Controls.Add(nsLabel6);
            tabPage2.Controls.Add(nsLabel7);
            tabPage2.Location = new Point(119, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(648, 171);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "RSTBL Conversion";
            // 
            // nsButton3
            // 
            nsButton3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsButton3.Location = new Point(614, 145);
            nsButton3.Name = "nsButton3";
            nsButton3.Size = new Size(28, 23);
            nsButton3.TabIndex = 17;
            nsButton3.Text = "...";
            nsButton3.Click += nsButton3_Click;
            // 
            // nsButton4
            // 
            nsButton4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nsButton4.Location = new Point(533, 145);
            nsButton4.Name = "nsButton4";
            nsButton4.Size = new Size(75, 23);
            nsButton4.TabIndex = 16;
            nsButton4.Text = "Convert";
            nsButton4.Click += nsButton4_Click;
            // 
            // nsLabel5
            // 
            nsLabel5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsLabel5.Location = new Point(65, 38);
            nsLabel5.Name = "nsLabel5";
            nsLabel5.Size = new Size(519, 31);
            nsLabel5.TabIndex = 14;
            nsLabel5.Text = "nsLabel5";
            nsLabel5.Value1 = "Select the ResourceSizeTable.Product file to be converted to YAML.";
            nsLabel5.Value2 = " ";
            // 
            // nsTextBox2
            // 
            nsTextBox2.Location = new Point(126, 145);
            nsTextBox2.Margin = new Padding(2);
            nsTextBox2.MaxLength = 32767;
            nsTextBox2.Multiline = false;
            nsTextBox2.Name = "nsTextBox2";
            nsTextBox2.ReadOnly = false;
            nsTextBox2.Size = new Size(402, 22);
            nsTextBox2.TabIndex = 12;
            nsTextBox2.TextAlign = HorizontalAlignment.Left;
            nsTextBox2.UseSystemPasswordChar = false;
            // 
            // nsLabel6
            // 
            nsLabel6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsLabel6.Location = new Point(93, 61);
            nsLabel6.Name = "nsLabel6";
            nsLabel6.Size = new Size(462, 31);
            nsLabel6.TabIndex = 15;
            nsLabel6.Text = "nsLabel6";
            nsLabel6.Value1 = " Information will be displayed in the output window below";
            nsLabel6.Value2 = " ";
            // 
            // nsLabel7
            // 
            nsLabel7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            nsLabel7.Location = new Point(7, 144);
            nsLabel7.Name = "nsLabel7";
            nsLabel7.Size = new Size(121, 23);
            nsLabel7.TabIndex = 13;
            nsLabel7.Text = "nsLabel7";
            nsLabel7.Value1 = "File To Convert:";
            nsLabel7.Value2 = "";
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.FromArgb(50, 50, 50);
            tabPage3.Controls.Add(nsButton9);
            tabPage3.Controls.Add(nsTextBox5);
            tabPage3.Controls.Add(nsLabel12);
            tabPage3.Controls.Add(nsButton7);
            tabPage3.Controls.Add(nsTextBox4);
            tabPage3.Controls.Add(nsButton5);
            tabPage3.Controls.Add(nsButton6);
            tabPage3.Controls.Add(nsLabel8);
            tabPage3.Controls.Add(nsTextBox3);
            tabPage3.Controls.Add(nsLabel9);
            tabPage3.Controls.Add(nsLabel10);
            tabPage3.Controls.Add(nsLabel11);
            tabPage3.Location = new Point(119, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(648, 171);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "RESTBL Merging";
            // 
            // nsButton9
            // 
            nsButton9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsButton9.Location = new Point(617, 121);
            nsButton9.Name = "nsButton9";
            nsButton9.Size = new Size(28, 23);
            nsButton9.TabIndex = 31;
            nsButton9.Text = "...";
            nsButton9.Click += nsButton9_Click;
            // 
            // nsTextBox5
            // 
            nsTextBox5.Location = new Point(110, 122);
            nsTextBox5.Margin = new Padding(2);
            nsTextBox5.MaxLength = 32767;
            nsTextBox5.Multiline = false;
            nsTextBox5.Name = "nsTextBox5";
            nsTextBox5.ReadOnly = false;
            nsTextBox5.Size = new Size(502, 22);
            nsTextBox5.TabIndex = 28;
            nsTextBox5.TextAlign = HorizontalAlignment.Left;
            nsTextBox5.UseSystemPasswordChar = false;
            // 
            // nsLabel12
            // 
            nsLabel12.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            nsLabel12.Location = new Point(7, 121);
            nsLabel12.Name = "nsLabel12";
            nsLabel12.Size = new Size(98, 23);
            nsLabel12.TabIndex = 29;
            nsLabel12.Text = "nsLabel12";
            nsLabel12.Value1 = "Output Path";
            nsLabel12.Value2 = "";
            // 
            // nsButton7
            // 
            nsButton7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsButton7.Location = new Point(617, 93);
            nsButton7.Name = "nsButton7";
            nsButton7.Size = new Size(28, 23);
            nsButton7.TabIndex = 27;
            nsButton7.Text = "...";
            nsButton7.Click += nsButton7_Click;
            // 
            // nsTextBox4
            // 
            nsTextBox4.Location = new Point(110, 94);
            nsTextBox4.Margin = new Padding(2);
            nsTextBox4.MaxLength = 32767;
            nsTextBox4.Multiline = false;
            nsTextBox4.Name = "nsTextBox4";
            nsTextBox4.ReadOnly = false;
            nsTextBox4.Size = new Size(502, 22);
            nsTextBox4.TabIndex = 24;
            nsTextBox4.TextAlign = HorizontalAlignment.Left;
            nsTextBox4.UseSystemPasswordChar = false;
            // 
            // nsButton5
            // 
            nsButton5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsButton5.Location = new Point(617, 65);
            nsButton5.Name = "nsButton5";
            nsButton5.Size = new Size(28, 23);
            nsButton5.TabIndex = 23;
            nsButton5.Text = "...";
            nsButton5.Click += nsButton5_Click;
            // 
            // nsButton6
            // 
            nsButton6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nsButton6.Location = new Point(570, 145);
            nsButton6.Name = "nsButton6";
            nsButton6.Size = new Size(75, 23);
            nsButton6.TabIndex = 22;
            nsButton6.Text = "Convert";
            nsButton6.Click += nsButton6_Click;
            // 
            // nsLabel8
            // 
            nsLabel8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsLabel8.Location = new Point(177, 2);
            nsLabel8.Name = "nsLabel8";
            nsLabel8.Size = new Size(294, 31);
            nsLabel8.TabIndex = 20;
            nsLabel8.Text = "nsLabel8";
            nsLabel8.Value1 = "Select the Mods RSTBL to be Merged.";
            nsLabel8.Value2 = " ";
            // 
            // nsTextBox3
            // 
            nsTextBox3.Location = new Point(110, 66);
            nsTextBox3.Margin = new Padding(2);
            nsTextBox3.MaxLength = 32767;
            nsTextBox3.Multiline = false;
            nsTextBox3.Name = "nsTextBox3";
            nsTextBox3.ReadOnly = false;
            nsTextBox3.Size = new Size(502, 22);
            nsTextBox3.TabIndex = 18;
            nsTextBox3.TextAlign = HorizontalAlignment.Left;
            nsTextBox3.UseSystemPasswordChar = false;
            // 
            // nsLabel9
            // 
            nsLabel9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsLabel9.Location = new Point(93, 25);
            nsLabel9.Name = "nsLabel9";
            nsLabel9.Size = new Size(462, 31);
            nsLabel9.TabIndex = 21;
            nsLabel9.Text = "nsLabel9";
            nsLabel9.Value1 = " Information will be displayed in the output window below";
            nsLabel9.Value2 = " ";
            // 
            // nsLabel10
            // 
            nsLabel10.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            nsLabel10.Location = new Point(7, 65);
            nsLabel10.Name = "nsLabel10";
            nsLabel10.Size = new Size(98, 23);
            nsLabel10.TabIndex = 19;
            nsLabel10.Text = "nsLabel10";
            nsLabel10.Value1 = "Vanilla RSTB";
            nsLabel10.Value2 = "";
            // 
            // nsLabel11
            // 
            nsLabel11.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            nsLabel11.Location = new Point(7, 93);
            nsLabel11.Name = "nsLabel11";
            nsLabel11.Size = new Size(110, 23);
            nsLabel11.TabIndex = 25;
            nsLabel11.Text = "nsLabel11";
            nsLabel11.Value1 = "Modded RSTB";
            nsLabel11.Value2 = "";
            // 
            // tabPage4
            // 
            tabPage4.BackColor = Color.FromArgb(50, 50, 50);
            tabPage4.Controls.Add(nsLabel15);
            tabPage4.Controls.Add(nsButton8);
            tabPage4.Controls.Add(nsTextBox6);
            tabPage4.Controls.Add(nsLabel13);
            tabPage4.Controls.Add(nsButton10);
            tabPage4.Controls.Add(nsTextBox7);
            tabPage4.Controls.Add(nsLabel14);
            tabPage4.Controls.Add(nsButton11);
            tabPage4.Controls.Add(nsButton12);
            tabPage4.Controls.Add(nsTextBox8);
            tabPage4.Controls.Add(nsLabel17);
            tabPage4.Controls.Add(nsLabel23);
            tabPage4.Controls.Add(nsLabel16);
            tabPage4.Location = new Point(119, 4);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(648, 171);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Mod Patching";
            // 
            // nsLabel15
            // 
            nsLabel15.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsLabel15.Location = new Point(102, 1);
            nsLabel15.Name = "nsLabel15";
            nsLabel15.Size = new Size(445, 30);
            nsLabel15.TabIndex = 34;
            nsLabel15.Text = "nsLabel15";
            nsLabel15.Value1 = "Select the vanilla RSTBL file, and the mod YAML to patch. ";
            nsLabel15.Value2 = " ";
            // 
            // nsButton8
            // 
            nsButton8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsButton8.Location = new Point(617, 121);
            nsButton8.Name = "nsButton8";
            nsButton8.Size = new Size(28, 23);
            nsButton8.TabIndex = 43;
            nsButton8.Text = "...";
            nsButton8.Click += nsButton8_Click;
            // 
            // nsTextBox6
            // 
            nsTextBox6.Location = new Point(82, 122);
            nsTextBox6.Margin = new Padding(2);
            nsTextBox6.MaxLength = 32767;
            nsTextBox6.Multiline = false;
            nsTextBox6.Name = "nsTextBox6";
            nsTextBox6.ReadOnly = false;
            nsTextBox6.Size = new Size(530, 22);
            nsTextBox6.TabIndex = 41;
            nsTextBox6.TextAlign = HorizontalAlignment.Left;
            nsTextBox6.UseSystemPasswordChar = false;
            // 
            // nsLabel13
            // 
            nsLabel13.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            nsLabel13.Location = new Point(7, 121);
            nsLabel13.Name = "nsLabel13";
            nsLabel13.Size = new Size(70, 23);
            nsLabel13.TabIndex = 42;
            nsLabel13.Text = "nsLabel13";
            nsLabel13.Value1 = "Output";
            nsLabel13.Value2 = "";
            // 
            // nsButton10
            // 
            nsButton10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsButton10.Location = new Point(617, 93);
            nsButton10.Name = "nsButton10";
            nsButton10.Size = new Size(28, 23);
            nsButton10.TabIndex = 40;
            nsButton10.Text = "...";
            nsButton10.Click += nsButton10_Click;
            // 
            // nsTextBox7
            // 
            nsTextBox7.Location = new Point(82, 94);
            nsTextBox7.Margin = new Padding(2);
            nsTextBox7.MaxLength = 32767;
            nsTextBox7.Multiline = false;
            nsTextBox7.Name = "nsTextBox7";
            nsTextBox7.ReadOnly = false;
            nsTextBox7.Size = new Size(530, 22);
            nsTextBox7.TabIndex = 38;
            nsTextBox7.TextAlign = HorizontalAlignment.Left;
            nsTextBox7.UseSystemPasswordChar = false;
            // 
            // nsLabel14
            // 
            nsLabel14.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            nsLabel14.Location = new Point(7, 93);
            nsLabel14.Name = "nsLabel14";
            nsLabel14.Size = new Size(70, 23);
            nsLabel14.TabIndex = 39;
            nsLabel14.Text = "nsLabel14";
            nsLabel14.Value1 = "Modded";
            nsLabel14.Value2 = "";
            // 
            // nsButton11
            // 
            nsButton11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsButton11.Location = new Point(617, 65);
            nsButton11.Name = "nsButton11";
            nsButton11.Size = new Size(28, 23);
            nsButton11.TabIndex = 37;
            nsButton11.Text = "...";
            nsButton11.Click += nsButton11_Click;
            // 
            // nsButton12
            // 
            nsButton12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nsButton12.Location = new Point(570, 145);
            nsButton12.Name = "nsButton12";
            nsButton12.Size = new Size(75, 23);
            nsButton12.TabIndex = 36;
            nsButton12.Text = "Convert";
            nsButton12.Click += nsButton12_Click;
            // 
            // nsTextBox8
            // 
            nsTextBox8.Location = new Point(82, 66);
            nsTextBox8.Margin = new Padding(2);
            nsTextBox8.MaxLength = 32767;
            nsTextBox8.Multiline = false;
            nsTextBox8.Name = "nsTextBox8";
            nsTextBox8.ReadOnly = false;
            nsTextBox8.Size = new Size(530, 22);
            nsTextBox8.TabIndex = 32;
            nsTextBox8.TextAlign = HorizontalAlignment.Left;
            nsTextBox8.UseSystemPasswordChar = false;
            // 
            // nsLabel17
            // 
            nsLabel17.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            nsLabel17.Location = new Point(7, 65);
            nsLabel17.Name = "nsLabel17";
            nsLabel17.Size = new Size(70, 23);
            nsLabel17.TabIndex = 33;
            nsLabel17.Text = "nsLabel17";
            nsLabel17.Value1 = "Vanilla";
            nsLabel17.Value2 = "";
            // 
            // nsLabel23
            // 
            nsLabel23.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsLabel23.Location = new Point(152, 21);
            nsLabel23.Name = "nsLabel23";
            nsLabel23.Size = new Size(345, 31);
            nsLabel23.TabIndex = 44;
            nsLabel23.Text = "nsLabel23";
            nsLabel23.Value1 = "It will be saved to the Output Path selected.";
            nsLabel23.Value2 = " ";
            // 
            // nsLabel16
            // 
            nsLabel16.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsLabel16.Location = new Point(93, 41);
            nsLabel16.Name = "nsLabel16";
            nsLabel16.Size = new Size(462, 31);
            nsLabel16.TabIndex = 35;
            nsLabel16.Text = "nsLabel16";
            nsLabel16.Value1 = " Information will be displayed in the output window below";
            nsLabel16.Value2 = " ";
            // 
            // tabPage5
            // 
            tabPage5.BackColor = Color.FromArgb(50, 50, 50);
            tabPage5.Controls.Add(nsButton14);
            tabPage5.Controls.Add(nsTextBox10);
            tabPage5.Controls.Add(nsLabel19);
            tabPage5.Controls.Add(nsButton15);
            tabPage5.Controls.Add(nsButton16);
            tabPage5.Controls.Add(nsLabel20);
            tabPage5.Controls.Add(nsTextBox11);
            tabPage5.Controls.Add(nsLabel21);
            tabPage5.Controls.Add(nsLabel22);
            tabPage5.Location = new Point(119, 4);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(648, 171);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Make Patch";
            // 
            // nsButton14
            // 
            nsButton14.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsButton14.Location = new Point(617, 121);
            nsButton14.Name = "nsButton14";
            nsButton14.Size = new Size(28, 23);
            nsButton14.TabIndex = 52;
            nsButton14.Text = "...";
            nsButton14.Click += nsButton14_Click;
            // 
            // nsTextBox10
            // 
            nsTextBox10.Location = new Point(82, 122);
            nsTextBox10.Margin = new Padding(2);
            nsTextBox10.MaxLength = 32767;
            nsTextBox10.Multiline = false;
            nsTextBox10.Name = "nsTextBox10";
            nsTextBox10.ReadOnly = false;
            nsTextBox10.Size = new Size(530, 22);
            nsTextBox10.TabIndex = 50;
            nsTextBox10.TextAlign = HorizontalAlignment.Left;
            nsTextBox10.UseSystemPasswordChar = false;
            // 
            // nsLabel19
            // 
            nsLabel19.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            nsLabel19.Location = new Point(7, 121);
            nsLabel19.Name = "nsLabel19";
            nsLabel19.Size = new Size(70, 23);
            nsLabel19.TabIndex = 51;
            nsLabel19.Text = "nsLabel19";
            nsLabel19.Value1 = "Modded";
            nsLabel19.Value2 = "";
            // 
            // nsButton15
            // 
            nsButton15.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsButton15.Location = new Point(617, 93);
            nsButton15.Name = "nsButton15";
            nsButton15.Size = new Size(28, 23);
            nsButton15.TabIndex = 49;
            nsButton15.Text = "...";
            nsButton15.Click += nsButton15_Click;
            // 
            // nsButton16
            // 
            nsButton16.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nsButton16.Location = new Point(570, 145);
            nsButton16.Name = "nsButton16";
            nsButton16.Size = new Size(75, 23);
            nsButton16.TabIndex = 48;
            nsButton16.Text = "Convert";
            nsButton16.Click += nsButton16_Click;
            // 
            // nsLabel20
            // 
            nsLabel20.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsLabel20.Location = new Point(202, 2);
            nsLabel20.Name = "nsLabel20";
            nsLabel20.Size = new Size(244, 31);
            nsLabel20.TabIndex = 46;
            nsLabel20.Text = "nsLabel20";
            nsLabel20.Value1 = "Select the Mods to be Merged.";
            nsLabel20.Value2 = " ";
            // 
            // nsTextBox11
            // 
            nsTextBox11.Location = new Point(82, 94);
            nsTextBox11.Margin = new Padding(2);
            nsTextBox11.MaxLength = 32767;
            nsTextBox11.Multiline = false;
            nsTextBox11.Name = "nsTextBox11";
            nsTextBox11.ReadOnly = false;
            nsTextBox11.Size = new Size(530, 22);
            nsTextBox11.TabIndex = 44;
            nsTextBox11.TextAlign = HorizontalAlignment.Left;
            nsTextBox11.UseSystemPasswordChar = false;
            // 
            // nsLabel21
            // 
            nsLabel21.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nsLabel21.Location = new Point(93, 25);
            nsLabel21.Name = "nsLabel21";
            nsLabel21.Size = new Size(462, 31);
            nsLabel21.TabIndex = 47;
            nsLabel21.Text = "nsLabel21";
            nsLabel21.Value1 = " Information will be displayed in the output window below";
            nsLabel21.Value2 = " ";
            // 
            // nsLabel22
            // 
            nsLabel22.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            nsLabel22.Location = new Point(7, 93);
            nsLabel22.Name = "nsLabel22";
            nsLabel22.Size = new Size(70, 23);
            nsLabel22.TabIndex = 45;
            nsLabel22.Text = "nsLabel22";
            nsLabel22.Value1 = "Vanilla";
            nsLabel22.Value2 = "";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 583);
            Controls.Add(nsGroupBox1);
            Controls.Add(nsGroupBox2);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form2";
            Text = "TotK RSTB Tool";
            Load += Form2_Load;
            nsGroupBox1.ResumeLayout(false);
            nsGroupBox1.PerformLayout();
            nsGroupBox2.ResumeLayout(false);
            nsTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox Outputbox;
        private TotKModManager.NSGroupBox nsGroupBox1;
        private TotKModManager.NSTextBox nsTextBox1;
        private NSLabel nsLabel1;
        private NSGroupBox nsGroupBox2;
        private NSTabControl nsTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private NSLabel nsLabel2;
        private NSLabel nsLabel3;
        private NSLabel nsLabel4;
        private NSButton nsButton1;
        private NSButton nsButton2;
        private NSButton nsButton3;
        private NSButton nsButton4;
        private NSLabel nsLabel5;
        private NSTextBox nsTextBox2;
        private NSLabel nsLabel6;
        private NSLabel nsLabel7;
        private NSButton nsButton9;
        private NSTextBox nsTextBox5;
        private NSLabel nsLabel12;
        private NSButton nsButton7;
        private NSTextBox nsTextBox4;
        private NSLabel nsLabel11;
        private NSButton nsButton5;
        private NSButton nsButton6;
        private NSLabel nsLabel8;
        private NSTextBox nsTextBox3;
        private NSLabel nsLabel9;
        private NSLabel nsLabel10;
        private NSButton nsButton8;
        private NSTextBox nsTextBox6;
        private NSLabel nsLabel13;
        private NSButton nsButton10;
        private NSTextBox nsTextBox7;
        private NSLabel nsLabel14;
        private NSButton nsButton11;
        private NSButton nsButton12;
        private NSLabel nsLabel15;
        private NSTextBox nsTextBox8;
        private NSLabel nsLabel16;
        private NSLabel nsLabel17;
        private NSButton nsButton14;
        private NSTextBox nsTextBox10;
        private NSLabel nsLabel19;
        private NSButton nsButton15;
        private NSButton nsButton16;
        private NSLabel nsLabel20;
        private NSTextBox nsTextBox11;
        private NSLabel nsLabel21;
        private NSLabel nsLabel22;
        private NSLabel nsLabel23;
        private NSButton nsButton13;
        private NSTextBox nsTextBox9;
        private NSLabel nsLabel18;
        private NSButton nsButton17;
        private NSButton nsButton18;
        private NSLabel nsLabel24;
        private NSTextBox nsTextBox12;
        private NSLabel nsLabel25;
        private NSLabel nsLabel26;
    }
}