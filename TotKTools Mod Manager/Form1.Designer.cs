namespace TotKModManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            timer2 = new System.Windows.Forms.Timer(components);
            nsButton2 = new NSButton();
            nsButton3 = new NSButton();
            nsGroupBox1 = new NSGroupBox();
            nsTabControl1 = new NSTabControl();
            tabPage1 = new TabPage();
            nsListView3 = new NSListView();
            nsButton1 = new NSButton();
            tabPage2 = new TabPage();
            nsButton5 = new NSButton();
            nsListView4 = new NSListView();
            tabPage4 = new TabPage();
            nsListView5 = new NSListView();
            nsButton6 = new NSButton();
            nsButton4 = new NSButton();
            nsLabel4 = new NSLabel();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            backupSaveToolStripMenuItem = new ToolStripMenuItem();
            backupModsToolStripMenuItem = new ToolStripMenuItem();
            restoreModsToolStripMenuItem = new ToolStripMenuItem();
            openModsFolderToolStripMenuItem = new ToolStripMenuItem();
            saveBackupsToolStripMenuItem = new ToolStripMenuItem();
            backupSavesToolStripMenuItem = new ToolStripMenuItem();
            restoreSavesToolStripMenuItem = new ToolStripMenuItem();
            openSaveFolderToolStripMenuItem = new ToolStripMenuItem();
            manuallyAddModToolStripMenuItem = new ToolStripMenuItem();
            clearShaderCacheToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            saveEditorToolStripMenuItem = new ToolStripMenuItem();
            rSTBMergerCOMINGSOONToolStripMenuItem = new ToolStripMenuItem();
            zSTLibCOMINGSOONToolStripMenuItem = new ToolStripMenuItem();
            switchToolboxCOMINGSOONToolStripMenuItem = new ToolStripMenuItem();
            nXEditorCOMINGSOONToolStripMenuItem = new ToolStripMenuItem();
            yuzuPresetsToolStripMenuItem = new ToolStripMenuItem();
            aMDToolStripMenuItem = new ToolStripMenuItem();
            standardPresetToolStripMenuItem1 = new ToolStripMenuItem();
            highPresetToolStripMenuItem1 = new ToolStripMenuItem();
            nVIDIAToolStripMenuItem = new ToolStripMenuItem();
            standardPresetToolStripMenuItem = new ToolStripMenuItem();
            highPresetToolStripMenuItem = new ToolStripMenuItem();
            steamDeckToolStripMenuItem = new ToolStripMenuItem();
            standardPresetToolStripMenuItem2 = new ToolStripMenuItem();
            highPresetNOTRECOMMENDEDToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            checkForUpdateToolStripMenuItem = new ToolStripMenuItem();
            nsGroupBox2 = new NSGroupBox();
            nsGroupBox3 = new NSGroupBox();
            nsLabel3 = new NSLabel();
            launch_Btn = new NSButton();
            nsTabControl2 = new NSTabControl();
            tabPage3 = new TabPage();
            nsOnOffBox1 = new NSOnOffBox();
            nsListView1 = new NSListView();
            tabPage5 = new TabPage();
            nsButton8 = new NSButton();
            nsOnOffBox2 = new NSOnOffBox();
            nsListView2 = new NSListView();
            nsLabel1 = new NSLabel();
            nsProgressBar1 = new NSProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            timer3 = new System.Windows.Forms.Timer(components);
            testToolStripMenuItem = new ToolStripMenuItem();
            nsGroupBox1.SuspendLayout();
            nsTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage4.SuspendLayout();
            menuStrip1.SuspendLayout();
            nsGroupBox2.SuspendLayout();
            nsGroupBox3.SuspendLayout();
            nsTabControl2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage5.SuspendLayout();
            SuspendLayout();
            // 
            // timer2
            // 
            timer2.Interval = 3000;
            timer2.Tick += timer2_Tick;
            // 
            // nsButton2
            // 
            nsButton2.Location = new Point(0, 0);
            nsButton2.Margin = new Padding(2);
            nsButton2.Name = "nsButton2";
            nsButton2.Size = new Size(0, 0);
            nsButton2.TabIndex = 13;
            // 
            // nsButton3
            // 
            nsButton3.Location = new Point(0, 0);
            nsButton3.Margin = new Padding(2);
            nsButton3.Name = "nsButton3";
            nsButton3.Size = new Size(0, 0);
            nsButton3.TabIndex = 12;
            // 
            // nsGroupBox1
            // 
            nsGroupBox1.Controls.Add(nsTabControl1);
            nsGroupBox1.Controls.Add(nsButton4);
            nsGroupBox1.Controls.Add(nsLabel4);
            nsGroupBox1.DrawSeperator = false;
            nsGroupBox1.Font = new Font("Segoe UI", 12F);
            nsGroupBox1.Location = new Point(7, 361);
            nsGroupBox1.Margin = new Padding(2);
            nsGroupBox1.Name = "nsGroupBox1";
            nsGroupBox1.Size = new Size(728, 317);
            nsGroupBox1.SubTitle = "These are the currently available mods for Game Version 1.2.1";
            nsGroupBox1.TabIndex = 14;
            nsGroupBox1.Text = "nsGroupBox1";
            nsGroupBox1.Title = "Available Mods";
            // 
            // nsTabControl1
            // 
            nsTabControl1.Alignment = TabAlignment.Left;
            nsTabControl1.Controls.Add(tabPage1);
            nsTabControl1.Controls.Add(tabPage2);
            nsTabControl1.Controls.Add(tabPage4);
            nsTabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            nsTabControl1.ItemSize = new Size(28, 115);
            nsTabControl1.Location = new Point(2, 39);
            nsTabControl1.Margin = new Padding(2);
            nsTabControl1.Multiline = true;
            nsTabControl1.Name = "nsTabControl1";
            nsTabControl1.SelectedIndex = 0;
            nsTabControl1.Size = new Size(724, 281);
            nsTabControl1.SizeMode = TabSizeMode.Fixed;
            nsTabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(50, 50, 50);
            tabPage1.Controls.Add(nsListView3);
            tabPage1.Controls.Add(nsButton1);
            tabPage1.Location = new Point(119, 4);
            tabPage1.Margin = new Padding(2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(2);
            tabPage1.Size = new Size(601, 273);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Graphics";
            // 
            // nsListView3
            // 
            nsListView3.Location = new Point(0, 45);
            nsListView3.Margin = new Padding(2);
            nsListView3.MultiSelect = true;
            nsListView3.Name = "nsListView3";
            nsListView3.Size = new Size(607, 229);
            nsListView3.TabIndex = 1;
            nsListView3.Text = "nsListView3";
            // 
            // nsButton1
            // 
            nsButton1.Font = new Font("Segoe UI", 12F);
            nsButton1.Location = new Point(4, 0);
            nsButton1.Margin = new Padding(2);
            nsButton1.Name = "nsButton1";
            nsButton1.Size = new Size(598, 41);
            nsButton1.TabIndex = 4;
            nsButton1.Text = "                                                            Add Selected";
            nsButton1.Click += nsButton1_Click;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(50, 50, 50);
            tabPage2.Controls.Add(nsButton5);
            tabPage2.Controls.Add(nsListView4);
            tabPage2.Location = new Point(119, 4);
            tabPage2.Margin = new Padding(2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(2);
            tabPage2.Size = new Size(601, 273);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "FPS";
            // 
            // nsButton5
            // 
            nsButton5.Font = new Font("Segoe UI", 12F);
            nsButton5.Location = new Point(4, 0);
            nsButton5.Margin = new Padding(2);
            nsButton5.Name = "nsButton5";
            nsButton5.Size = new Size(598, 41);
            nsButton5.TabIndex = 17;
            nsButton5.Text = "                                                            Add Selected";
            nsButton5.Click += nsButton5_Click;
            // 
            // nsListView4
            // 
            nsListView4.Location = new Point(0, 45);
            nsListView4.Margin = new Padding(2);
            nsListView4.MultiSelect = true;
            nsListView4.Name = "nsListView4";
            nsListView4.Size = new Size(607, 229);
            nsListView4.TabIndex = 2;
            nsListView4.Text = "nsListView4";
            // 
            // tabPage4
            // 
            tabPage4.BackColor = Color.FromArgb(50, 50, 50);
            tabPage4.Controls.Add(nsListView5);
            tabPage4.Controls.Add(nsButton6);
            tabPage4.Location = new Point(119, 4);
            tabPage4.Margin = new Padding(2);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(601, 273);
            tabPage4.TabIndex = 2;
            tabPage4.Text = "Cheats";
            // 
            // nsListView5
            // 
            nsListView5.Location = new Point(0, 45);
            nsListView5.Margin = new Padding(2);
            nsListView5.MultiSelect = true;
            nsListView5.Name = "nsListView5";
            nsListView5.Size = new Size(607, 229);
            nsListView5.TabIndex = 19;
            nsListView5.Text = "nsListView5";
            // 
            // nsButton6
            // 
            nsButton6.Font = new Font("Segoe UI", 12F);
            nsButton6.Location = new Point(4, 0);
            nsButton6.Margin = new Padding(2);
            nsButton6.Name = "nsButton6";
            nsButton6.Size = new Size(598, 41);
            nsButton6.TabIndex = 18;
            nsButton6.Text = "                                                            Add Selected";
            nsButton6.Click += nsButton6_Click;
            // 
            // nsButton4
            // 
            nsButton4.Font = new Font("Segoe UI", 12F);
            nsButton4.Location = new Point(629, 9);
            nsButton4.Margin = new Padding(2);
            nsButton4.Name = "nsButton4";
            nsButton4.Size = new Size(94, 26);
            nsButton4.TabIndex = 16;
            nsButton4.Text = "Download";
            nsButton4.Click += nsButton4_Click;
            // 
            // nsLabel4
            // 
            nsLabel4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            nsLabel4.Location = new Point(407, 13);
            nsLabel4.Margin = new Padding(2);
            nsLabel4.Name = "nsLabel4";
            nsLabel4.Size = new Size(218, 22);
            nsLabel4.TabIndex = 20;
            nsLabel4.Text = "nsLabel4";
            nsLabel4.Value1 = "Update Available Mods List:";
            nsLabel4.Value2 = "";
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 10F);
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, toolsToolStripMenuItem, yuzuPresetsToolStripMenuItem, aboutToolStripMenuItem, checkForUpdateToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(4, 1, 0, 1);
            menuStrip1.Size = new Size(744, 25);
            menuStrip1.TabIndex = 15;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { backupSaveToolStripMenuItem, saveBackupsToolStripMenuItem, manuallyAddModToolStripMenuItem, clearShaderCacheToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(41, 23);
            fileToolStripMenuItem.Text = "File";
            // 
            // backupSaveToolStripMenuItem
            // 
            backupSaveToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { backupModsToolStripMenuItem, restoreModsToolStripMenuItem, openModsFolderToolStripMenuItem });
            backupSaveToolStripMenuItem.Name = "backupSaveToolStripMenuItem";
            backupSaveToolStripMenuItem.Size = new Size(205, 24);
            backupSaveToolStripMenuItem.Text = "Mod Backups";
            // 
            // backupModsToolStripMenuItem
            // 
            backupModsToolStripMenuItem.Name = "backupModsToolStripMenuItem";
            backupModsToolStripMenuItem.Size = new Size(202, 24);
            backupModsToolStripMenuItem.Text = "Backup Mods";
            backupModsToolStripMenuItem.Click += backupModsToolStripMenuItem_Click;
            // 
            // restoreModsToolStripMenuItem
            // 
            restoreModsToolStripMenuItem.Name = "restoreModsToolStripMenuItem";
            restoreModsToolStripMenuItem.Size = new Size(202, 24);
            restoreModsToolStripMenuItem.Text = "Restore Mods";
            restoreModsToolStripMenuItem.Click += restoreModsToolStripMenuItem_Click;
            // 
            // openModsFolderToolStripMenuItem
            // 
            openModsFolderToolStripMenuItem.Name = "openModsFolderToolStripMenuItem";
            openModsFolderToolStripMenuItem.Size = new Size(202, 24);
            openModsFolderToolStripMenuItem.Text = "Open Mods Folder...";
            openModsFolderToolStripMenuItem.Click += openModsFolderToolStripMenuItem_Click;
            // 
            // saveBackupsToolStripMenuItem
            // 
            saveBackupsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { backupSavesToolStripMenuItem, restoreSavesToolStripMenuItem, openSaveFolderToolStripMenuItem });
            saveBackupsToolStripMenuItem.Name = "saveBackupsToolStripMenuItem";
            saveBackupsToolStripMenuItem.Size = new Size(205, 24);
            saveBackupsToolStripMenuItem.Text = "Save Backups";
            // 
            // backupSavesToolStripMenuItem
            // 
            backupSavesToolStripMenuItem.Name = "backupSavesToolStripMenuItem";
            backupSavesToolStripMenuItem.Size = new Size(195, 24);
            backupSavesToolStripMenuItem.Text = "Backup Saves";
            backupSavesToolStripMenuItem.Click += backupSavesToolStripMenuItem_Click;
            // 
            // restoreSavesToolStripMenuItem
            // 
            restoreSavesToolStripMenuItem.Name = "restoreSavesToolStripMenuItem";
            restoreSavesToolStripMenuItem.Size = new Size(195, 24);
            restoreSavesToolStripMenuItem.Text = "Restore Saves";
            restoreSavesToolStripMenuItem.Click += restoreSavesToolStripMenuItem_Click;
            // 
            // openSaveFolderToolStripMenuItem
            // 
            openSaveFolderToolStripMenuItem.Name = "openSaveFolderToolStripMenuItem";
            openSaveFolderToolStripMenuItem.Size = new Size(195, 24);
            openSaveFolderToolStripMenuItem.Text = "Open Save Folder...";
            openSaveFolderToolStripMenuItem.Click += openSaveFolderToolStripMenuItem_Click;
            // 
            // manuallyAddModToolStripMenuItem
            // 
            manuallyAddModToolStripMenuItem.Name = "manuallyAddModToolStripMenuItem";
            manuallyAddModToolStripMenuItem.Size = new Size(205, 24);
            manuallyAddModToolStripMenuItem.Text = "Manually Add Mod...";
            manuallyAddModToolStripMenuItem.Click += manuallyAddModToolStripMenuItem_Click;
            // 
            // clearShaderCacheToolStripMenuItem
            // 
            clearShaderCacheToolStripMenuItem.Name = "clearShaderCacheToolStripMenuItem";
            clearShaderCacheToolStripMenuItem.Size = new Size(205, 24);
            clearShaderCacheToolStripMenuItem.Text = "Clear Shader Cache";
            clearShaderCacheToolStripMenuItem.Click += clearShaderCacheToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(44, 23);
            editToolStripMenuItem.Text = "Edit";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(127, 24);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveEditorToolStripMenuItem, rSTBMergerCOMINGSOONToolStripMenuItem, zSTLibCOMINGSOONToolStripMenuItem, switchToolboxCOMINGSOONToolStripMenuItem, nXEditorCOMINGSOONToolStripMenuItem, testToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(52, 23);
            toolsToolStripMenuItem.Text = "Tools";
            toolsToolStripMenuItem.Click += toolsToolStripMenuItem_Click;
            // 
            // saveEditorToolStripMenuItem
            // 
            saveEditorToolStripMenuItem.Name = "saveEditorToolStripMenuItem";
            saveEditorToolStripMenuItem.Size = new Size(280, 24);
            saveEditorToolStripMenuItem.Text = "Save Editor";
            saveEditorToolStripMenuItem.Click += saveEditorToolStripMenuItem_Click;
            // 
            // rSTBMergerCOMINGSOONToolStripMenuItem
            // 
            rSTBMergerCOMINGSOONToolStripMenuItem.Name = "rSTBMergerCOMINGSOONToolStripMenuItem";
            rSTBMergerCOMINGSOONToolStripMenuItem.Size = new Size(280, 24);
            rSTBMergerCOMINGSOONToolStripMenuItem.Text = "RSTB Merger";
            rSTBMergerCOMINGSOONToolStripMenuItem.Click += rSTBMergerCOMINGSOONToolStripMenuItem_Click;
            // 
            // zSTLibCOMINGSOONToolStripMenuItem
            // 
            zSTLibCOMINGSOONToolStripMenuItem.Name = "zSTLibCOMINGSOONToolStripMenuItem";
            zSTLibCOMINGSOONToolStripMenuItem.Size = new Size(280, 24);
            zSTLibCOMINGSOONToolStripMenuItem.Text = "ZSTD Tool (Standalone App)";
            zSTLibCOMINGSOONToolStripMenuItem.Click += zSTLibCOMINGSOONToolStripMenuItem_Click;
            // 
            // switchToolboxCOMINGSOONToolStripMenuItem
            // 
            switchToolboxCOMINGSOONToolStripMenuItem.Name = "switchToolboxCOMINGSOONToolStripMenuItem";
            switchToolboxCOMINGSOONToolStripMenuItem.Size = new Size(280, 24);
            switchToolboxCOMINGSOONToolStripMenuItem.Text = "Switch Toolbox (COMING SOON)";
            // 
            // nXEditorCOMINGSOONToolStripMenuItem
            // 
            nXEditorCOMINGSOONToolStripMenuItem.Name = "nXEditorCOMINGSOONToolStripMenuItem";
            nXEditorCOMINGSOONToolStripMenuItem.Size = new Size(280, 24);
            nXEditorCOMINGSOONToolStripMenuItem.Text = "NX Editor (COMING SOON)";
            // 
            // yuzuPresetsToolStripMenuItem
            // 
            yuzuPresetsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aMDToolStripMenuItem, nVIDIAToolStripMenuItem, steamDeckToolStripMenuItem });
            yuzuPresetsToolStripMenuItem.Name = "yuzuPresetsToolStripMenuItem";
            yuzuPresetsToolStripMenuItem.Size = new Size(99, 23);
            yuzuPresetsToolStripMenuItem.Text = "Yuzu Presets";
            // 
            // aMDToolStripMenuItem
            // 
            aMDToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { standardPresetToolStripMenuItem1, highPresetToolStripMenuItem1 });
            aMDToolStripMenuItem.Name = "aMDToolStripMenuItem";
            aMDToolStripMenuItem.Size = new Size(146, 24);
            aMDToolStripMenuItem.Text = "AMD";
            // 
            // standardPresetToolStripMenuItem1
            // 
            standardPresetToolStripMenuItem1.Name = "standardPresetToolStripMenuItem1";
            standardPresetToolStripMenuItem1.Size = new Size(175, 24);
            standardPresetToolStripMenuItem1.Text = "Standard Preset";
            standardPresetToolStripMenuItem1.Click += standardPresetToolStripMenuItem1_Click;
            // 
            // highPresetToolStripMenuItem1
            // 
            highPresetToolStripMenuItem1.Name = "highPresetToolStripMenuItem1";
            highPresetToolStripMenuItem1.Size = new Size(175, 24);
            highPresetToolStripMenuItem1.Text = "High Preset";
            highPresetToolStripMenuItem1.Click += highPresetToolStripMenuItem1_Click;
            // 
            // nVIDIAToolStripMenuItem
            // 
            nVIDIAToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { standardPresetToolStripMenuItem, highPresetToolStripMenuItem });
            nVIDIAToolStripMenuItem.Name = "nVIDIAToolStripMenuItem";
            nVIDIAToolStripMenuItem.Size = new Size(146, 24);
            nVIDIAToolStripMenuItem.Text = "NVIDIA";
            // 
            // standardPresetToolStripMenuItem
            // 
            standardPresetToolStripMenuItem.Name = "standardPresetToolStripMenuItem";
            standardPresetToolStripMenuItem.Size = new Size(175, 24);
            standardPresetToolStripMenuItem.Text = "Standard Preset";
            standardPresetToolStripMenuItem.Click += standardPresetToolStripMenuItem_Click;
            // 
            // highPresetToolStripMenuItem
            // 
            highPresetToolStripMenuItem.Name = "highPresetToolStripMenuItem";
            highPresetToolStripMenuItem.Size = new Size(175, 24);
            highPresetToolStripMenuItem.Text = "High Preset";
            highPresetToolStripMenuItem.Click += highPresetToolStripMenuItem_Click;
            // 
            // steamDeckToolStripMenuItem
            // 
            steamDeckToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { standardPresetToolStripMenuItem2, highPresetNOTRECOMMENDEDToolStripMenuItem });
            steamDeckToolStripMenuItem.Name = "steamDeckToolStripMenuItem";
            steamDeckToolStripMenuItem.Size = new Size(146, 24);
            steamDeckToolStripMenuItem.Text = "SteamDeck";
            // 
            // standardPresetToolStripMenuItem2
            // 
            standardPresetToolStripMenuItem2.Name = "standardPresetToolStripMenuItem2";
            standardPresetToolStripMenuItem2.Size = new Size(175, 24);
            standardPresetToolStripMenuItem2.Text = "Standard Preset";
            standardPresetToolStripMenuItem2.Click += standardPresetToolStripMenuItem2_Click;
            // 
            // highPresetNOTRECOMMENDEDToolStripMenuItem
            // 
            highPresetNOTRECOMMENDEDToolStripMenuItem.Name = "highPresetNOTRECOMMENDEDToolStripMenuItem";
            highPresetNOTRECOMMENDEDToolStripMenuItem.Size = new Size(175, 24);
            highPresetNOTRECOMMENDEDToolStripMenuItem.Text = "High Preset";
            highPresetNOTRECOMMENDEDToolStripMenuItem.Click += highPresetNOTRECOMMENDEDToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(59, 23);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // checkForUpdateToolStripMenuItem
            // 
            checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            checkForUpdateToolStripMenuItem.Size = new Size(140, 23);
            checkForUpdateToolStripMenuItem.Text = "Check For Update...";
            checkForUpdateToolStripMenuItem.Click += checkForUpdateToolStripMenuItem_Click;
            // 
            // nsGroupBox2
            // 
            nsGroupBox2.Controls.Add(nsGroupBox3);
            nsGroupBox2.Controls.Add(launch_Btn);
            nsGroupBox2.Controls.Add(nsTabControl2);
            nsGroupBox2.DrawSeperator = false;
            nsGroupBox2.Font = new Font("Segoe UI", 12F);
            nsGroupBox2.Location = new Point(7, 28);
            nsGroupBox2.Margin = new Padding(2);
            nsGroupBox2.Name = "nsGroupBox2";
            nsGroupBox2.Size = new Size(729, 329);
            nsGroupBox2.SubTitle = "Currently Installed Mods";
            nsGroupBox2.TabIndex = 16;
            nsGroupBox2.Text = "nsGroupBox2";
            nsGroupBox2.Title = "Installed Mods";
            // 
            // nsGroupBox3
            // 
            nsGroupBox3.Controls.Add(nsLabel3);
            nsGroupBox3.DrawSeperator = false;
            nsGroupBox3.Location = new Point(151, 7);
            nsGroupBox3.Margin = new Padding(2);
            nsGroupBox3.Name = "nsGroupBox3";
            nsGroupBox3.Size = new Size(431, 28);
            nsGroupBox3.SubTitle = "";
            nsGroupBox3.TabIndex = 6;
            nsGroupBox3.Text = "nsGroupBox3";
            nsGroupBox3.Title = "";
            // 
            // nsLabel3
            // 
            nsLabel3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            nsLabel3.Location = new Point(9, 4);
            nsLabel3.Margin = new Padding(2);
            nsLabel3.Name = "nsLabel3";
            nsLabel3.Size = new Size(420, 23);
            nsLabel3.TabIndex = 5;
            nsLabel3.Text = "nsLabel3";
            nsLabel3.Value1 = "Mod Status: ";
            nsLabel3.Value2 = " Waiting...";
            nsLabel3.Click += nsLabel3_Click;
            // 
            // launch_Btn
            // 
            launch_Btn.Font = new Font("Segoe UI", 15.75F);
            launch_Btn.Location = new Point(588, 5);
            launch_Btn.Margin = new Padding(2);
            launch_Btn.Name = "launch_Btn";
            launch_Btn.Size = new Size(133, 33);
            launch_Btn.TabIndex = 3;
            launch_Btn.Text = "Launch TotK";
            launch_Btn.Click += nsButton7_Click;
            // 
            // nsTabControl2
            // 
            nsTabControl2.Alignment = TabAlignment.Left;
            nsTabControl2.Controls.Add(tabPage3);
            nsTabControl2.Controls.Add(tabPage5);
            nsTabControl2.DrawMode = TabDrawMode.OwnerDrawFixed;
            nsTabControl2.Font = new Font("Segoe UI", 12F);
            nsTabControl2.ItemSize = new Size(28, 115);
            nsTabControl2.Location = new Point(2, 42);
            nsTabControl2.Margin = new Padding(2);
            nsTabControl2.Multiline = true;
            nsTabControl2.Name = "nsTabControl2";
            nsTabControl2.SelectedIndex = 0;
            nsTabControl2.Size = new Size(727, 285);
            nsTabControl2.SizeMode = TabSizeMode.Fixed;
            nsTabControl2.TabIndex = 2;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.FromArgb(50, 50, 50);
            tabPage3.Controls.Add(nsOnOffBox1);
            tabPage3.Controls.Add(nsListView1);
            tabPage3.Location = new Point(119, 4);
            tabPage3.Margin = new Padding(2);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(2);
            tabPage3.Size = new Size(604, 277);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "Enabled";
            // 
            // nsOnOffBox1
            // 
            nsOnOffBox1.Checked = true;
            nsOnOffBox1.Location = new Point(545, 3);
            nsOnOffBox1.Margin = new Padding(2);
            nsOnOffBox1.MaximumSize = new Size(51, 19);
            nsOnOffBox1.MinimumSize = new Size(51, 19);
            nsOnOffBox1.Name = "nsOnOffBox1";
            nsOnOffBox1.Size = new Size(51, 19);
            nsOnOffBox1.TabIndex = 1;
            nsOnOffBox1.Text = "nsOnOffBox1";
            nsOnOffBox1.Click += nsOnOffBox1_Click;
            // 
            // nsListView1
            // 
            nsListView1.Location = new Point(-1, 34);
            nsListView1.Margin = new Padding(2);
            nsListView1.MultiSelect = true;
            nsListView1.Name = "nsListView1";
            nsListView1.Size = new Size(605, 249);
            nsListView1.TabIndex = 0;
            nsListView1.Text = "nsListView1";
            nsListView1.Click += nsListView1_Click_1;
            // 
            // tabPage5
            // 
            tabPage5.BackColor = Color.FromArgb(50, 50, 50);
            tabPage5.Controls.Add(nsButton8);
            tabPage5.Controls.Add(nsOnOffBox2);
            tabPage5.Controls.Add(nsListView2);
            tabPage5.Location = new Point(119, 4);
            tabPage5.Margin = new Padding(2);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(604, 277);
            tabPage5.TabIndex = 0;
            tabPage5.Text = "Disabled";
            // 
            // nsButton8
            // 
            nsButton8.Font = new Font("Segoe UI", 12F);
            nsButton8.Location = new Point(2, 2);
            nsButton8.Margin = new Padding(2);
            nsButton8.Name = "nsButton8";
            nsButton8.Size = new Size(217, 30);
            nsButton8.TabIndex = 21;
            nsButton8.Text = "Purge Disabled Mods Folder";
            nsButton8.Click += nsButton8_Click;
            // 
            // nsOnOffBox2
            // 
            nsOnOffBox2.Checked = false;
            nsOnOffBox2.Location = new Point(545, 3);
            nsOnOffBox2.Margin = new Padding(2);
            nsOnOffBox2.MaximumSize = new Size(51, 19);
            nsOnOffBox2.MinimumSize = new Size(51, 19);
            nsOnOffBox2.Name = "nsOnOffBox2";
            nsOnOffBox2.Size = new Size(51, 19);
            nsOnOffBox2.TabIndex = 3;
            nsOnOffBox2.Text = "nsOnOffBox2";
            nsOnOffBox2.Click += nsOnOffBox2_Click;
            // 
            // nsListView2
            // 
            nsListView2.Location = new Point(-1, 34);
            nsListView2.Margin = new Padding(2);
            nsListView2.MultiSelect = true;
            nsListView2.Name = "nsListView2";
            nsListView2.Size = new Size(605, 249);
            nsListView2.TabIndex = 1;
            nsListView2.Text = "nsListView2";
            nsListView2.Click += nsListView2_Click;
            // 
            // nsLabel1
            // 
            nsLabel1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            nsLabel1.Location = new Point(7, 682);
            nsLabel1.Margin = new Padding(2);
            nsLabel1.Name = "nsLabel1";
            nsLabel1.Size = new Size(137, 26);
            nsLabel1.TabIndex = 17;
            nsLabel1.Text = "nsLabel1";
            nsLabel1.Value1 = "Download Status:";
            nsLabel1.Value2 = "";
            nsLabel1.Click += nsLabel1_Click;
            // 
            // nsProgressBar1
            // 
            nsProgressBar1.Location = new Point(123, 685);
            nsProgressBar1.Margin = new Padding(2);
            nsProgressBar1.Maximum = 100;
            nsProgressBar1.Minimum = 0;
            nsProgressBar1.Name = "nsProgressBar1";
            nsProgressBar1.Size = new Size(434, 22);
            nsProgressBar1.TabIndex = 18;
            nsProgressBar1.Text = "nsProgressBar1";
            nsProgressBar1.Value = 0;
            // 
            // timer1
            // 
            timer1.Interval = 2000;
            timer1.Tick += timer1_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.ForeColor = Color.FromArgb(192, 0, 0);
            label1.Location = new Point(561, 689);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(163, 15);
            label1.TabIndex = 19;
            label1.Text = "000.00 MB of 000.00 MB 000%";
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new Size(280, 24);
            testToolStripMenuItem.Text = "Test";
            testToolStripMenuItem.Click += testToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(744, 715);
            Controls.Add(label1);
            Controls.Add(nsProgressBar1);
            Controls.Add(nsGroupBox2);
            Controls.Add(nsGroupBox1);
            Controls.Add(nsButton3);
            Controls.Add(nsButton2);
            Controls.Add(menuStrip1);
            Controls.Add(nsLabel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "Form1";
            Text = "TotKTools Mod Manager";
            Load += Form1_Load;
            nsGroupBox1.ResumeLayout(false);
            nsTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            nsGroupBox2.ResumeLayout(false);
            nsGroupBox3.ResumeLayout(false);
            nsTabControl2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TotKModManager.NSButton nsButton2;
        private TotKModManager.NSButton nsButton3;
        private TotKModManager.NSGroupBox nsGroupBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private TotKModManager.NSGroupBox nsGroupBox2;
        private TotKModManager.NSOnOffBox nsOnOffBox1;
        private TotKModManager.NSOnOffBox nsOnOffBox2;
        private TotKModManager.NSTabControl nsTabControl2;
        private TabPage tabPage3;
        private TabPage tabPage5;
        private TotKModManager.NSButton nsButton4;
        private TotKModManager.NSLabel nsLabel1;
        private TotKModManager.NSButton nsButton6;
        private TotKModManager.NSButton nsButton5;
        private TotKModManager.NSButton nsButton1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage4;
        public TotKModManager.NSListView nsListView5;
        private ToolStripMenuItem backupSaveToolStripMenuItem;
        private ToolStripMenuItem backupModsToolStripMenuItem;
        private ToolStripMenuItem restoreModsToolStripMenuItem;
        private ToolStripMenuItem saveBackupsToolStripMenuItem;
        private ToolStripMenuItem backupSavesToolStripMenuItem;
        private ToolStripMenuItem restoreSavesToolStripMenuItem;
        private TotKModManager.NSButton launch_Btn;
        private TotKModManager.NSLabel nsLabel3;
        private TotKModManager.NSProgressBar nsProgressBar1;
        private TotKModManager.NSGroupBox nsGroupBox3;
        private TotKModManager.NSLabel nsLabel4;
        private NSButton nsButton8;
        private Label label1;
        private ToolStripMenuItem clearShaderCacheToolStripMenuItem;
        private Button button1;
        public NSListView nsListView1;
        public NSListView nsListView3;
        public NSListView nsListView4;
        public NSListView nsListView2;
        private NSTabControl nsTabControl1;
        public System.Windows.Forms.Timer timer2;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Timer timer3;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem zSTLibCOMINGSOONToolStripMenuItem;
        private ToolStripMenuItem rSTBMergerCOMINGSOONToolStripMenuItem;
        private ToolStripMenuItem switchToolboxCOMINGSOONToolStripMenuItem;
        private ToolStripMenuItem nXEditorCOMINGSOONToolStripMenuItem;
        private ToolStripMenuItem yuzuPresetsToolStripMenuItem;
        private ToolStripMenuItem aMDToolStripMenuItem;
        private ToolStripMenuItem standardPresetToolStripMenuItem1;
        private ToolStripMenuItem highPresetToolStripMenuItem1;
        private ToolStripMenuItem nVIDIAToolStripMenuItem;
        private ToolStripMenuItem standardPresetToolStripMenuItem;
        private ToolStripMenuItem highPresetToolStripMenuItem;
        private ToolStripMenuItem steamDeckToolStripMenuItem;
        private ToolStripMenuItem standardPresetToolStripMenuItem2;
        private ToolStripMenuItem highPresetNOTRECOMMENDEDToolStripMenuItem;
        private ToolStripMenuItem manuallyAddModToolStripMenuItem;
        private ToolStripMenuItem openModsFolderToolStripMenuItem;
        private ToolStripMenuItem openSaveFolderToolStripMenuItem;
        private ToolStripMenuItem saveEditorToolStripMenuItem;
        private ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private ToolStripMenuItem testToolStripMenuItem;
    }
}