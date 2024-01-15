using SevenZipExtractor;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using TotK_Tools_Mod_Manager;
using static TotKModManager.NSListView;

namespace TotKModManager
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            //Instance = this;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string usercfg;
            usercfg = @"\UserCFG.ini";
            // User Settings Creation
            string userconfigs;

            userconfigs = Application.StartupPath + @"\UserCFG.ini";
            Module1.SaveToDisk("7z.dll", Application.StartupPath + @"\7z.dll");
            Module1.SaveToDisk("SaveEditor.7z", Application.StartupPath + @"\SaveEditor.7z");
            Module1.SaveToDisk("Totk.ZStdTool.exe", Application.StartupPath + @"\Totk.ZStdTool.exe");
            Module1.SaveToDisk("HashTable.bin", Application.StartupPath + @"\HashTable.bin");
            Module1.SaveToDisk("checksums.bin", Application.StartupPath + @"\checksums.bin");
            Module1.SaveToDisk("TotkRSTB.exe", Application.StartupPath + @"\TotkRSTB.exe");
            Module1.SaveToDisk("RstbLibrary.dll", Application.StartupPath + @"\RstbLibrary.dll");
            Module1.SaveToDisk("RstbLibrary.pdb", Application.StartupPath + @"\RstbLibrary.pdb");
            Module1.SaveToDisk("SarcLibrary.dll", Application.StartupPath + @"\SarcLibrary.dll");
            Module1.SaveToDisk("TotkRSTB.deps.json", Application.StartupPath + @"\TotkRSTB.deps.json");
            Module1.SaveToDisk("TotkRSTB.pdb", Application.StartupPath + @"\TotkRSTB.pdb");
            Module1.SaveToDisk("TotkRSTB.runtimeconfig.json", Application.StartupPath + @"\TotkRSTB.runtimeconfig.json");
            Module1.SaveToDisk("TotkRSTB.dll", Application.StartupPath + @"\TotkRSTB.dll");
            Module1.SaveToDisk("ZstdSharp.dll", Application.StartupPath + @"\ZstdSharp.dll");


            try
            {
                Module1.SaveToDisk("0100F2C0115B6000.ini", UserSettings(Application.StartupPath + usercfg, "EMU_Path") + @"\user\config\custom\0100F2C0115B6000.ini");
            }
            catch (Exception ex) 
            {
                ExceptionHandler.LogError(ex);
            }
            if (System.IO.File.Exists(userconfigs) == false)
            {

                DialogResult dialogResult = MessageBox.Show("No settings file detected, First time use detected." + Environment.NewLine + "Lets set-up your file paths!" + Environment.NewLine + "Set your EMU path, Mod path, and Backup Paths on the settings window.", "TotK Tools Mod Manager");
                if (dialogResult == DialogResult.OK)
                {
                    Module1.SaveToDisk("UserCFG.ini", userconfigs);

                    var settingsform = new Settings();

                    settingsform.Show(this);

                }
                else
                {
                    //do nothing
                }

            }
            DirectoryInfo dir = new DirectoryInfo(UserSettings(Application.StartupPath + usercfg, "Mod_Path") + @"\");//enabled folder
            DirectoryInfo[] subdirs = dir.GetDirectories();
            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\disabled\");
            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\mod_downloads\Mods\Graphics\");
            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\mod_downloads\Mods\FPS\");
            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\mod_downloads\Mods\CHEATS\");

            string dwnldflder;
            string unzip;
            unzip = Application.StartupPath + @"\SaveEditor.7z";
            dwnldflder = Application.StartupPath + @"\SaveEditor\";

            if (Directory.Exists(dwnldflder))
            {

                //do nothing
            }
            else
            {
                System.IO.Directory.CreateDirectory(dwnldflder);

                using (ArchiveFile archiveFile = new ArchiveFile(unzip))
                {
                    archiveFile.Extract(Application.StartupPath); // extract all

                }

            }




            foreach (DirectoryInfo item in subdirs)
            {
                nsListView1.AddItem(item.Name);
            }
            DirectoryInfo dir2 = new DirectoryInfo(Application.StartupPath + @"\disabled\");//disabled folder
            DirectoryInfo[] subdirs2 = dir2.GetDirectories();
            foreach (DirectoryInfo item2 in subdirs2)
            {
                nsListView2.AddItem(item2.Name);
            }
            DirectoryInfo dir3 = new DirectoryInfo(Application.StartupPath + @"\mod_downloads\Mods\Graphics\");//Loaded Graphics Folder
            DirectoryInfo[] subdirs3 = dir3.GetDirectories();
            foreach (DirectoryInfo item3 in subdirs3)
            {
                nsListView3.AddItem(item3.Name);
            }
            DirectoryInfo dir4 = new DirectoryInfo(Application.StartupPath + @"\mod_downloads\Mods\FPS\");//Loaded FPS Folder
            DirectoryInfo[] subdirs4 = dir4.GetDirectories();
            foreach (DirectoryInfo item4 in subdirs4)
            {
                nsListView4.AddItem(item4.Name);
            }
            DirectoryInfo dir5 = new DirectoryInfo(Application.StartupPath + @"\mod_downloads\Mods\CHEATS\");//Loaded CHEATS Folder
            DirectoryInfo[] subdirs5 = dir5.GetDirectories();
            foreach (DirectoryInfo item5 in subdirs5)
            {
                nsListView5.AddItem(item5.Name);
            }

            string currentApp = "TotK Tools Mod Manager [Version " + Application.ProductVersion + "]"; // Gets the applications current version
            Text = currentApp;





        }
        static void OpenFolderInExplorer(string folderPath)
        {
            // Check if the folder path is valid
            if (System.IO.Directory.Exists(folderPath))
            {
                // Use Process.Start to open Windows Explorer
                Process.Start("explorer.exe", folderPath);
            }
            else
            {
                MessageBox.Show("The specified path does not exist.");
            }
        }
        public string UserSettings(string File, string Identifier) // User Settings handler
        {

            using var S = new System.IO.StreamReader(File);
            string Result = "";
            while (S.Peek() != -1)
            {
                string Line = S.ReadLine();
                if (Line.ToLower().StartsWith(Identifier.ToLower() + "="))
                {
                    Result = Line.Substring(Identifier.Length + 1);
                }
            }
            return Result;
        }
        private void nsListView1_Click_1(object sender, EventArgs e)
        {
            nsOnOffBox1.Checked = true;


        }

        private void nsListView2_Click(object sender, EventArgs e)
        {

            nsOnOffBox2.Checked = false;

        }
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the source directory does not exist, throw an exception.
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }
            // If the destination directory does not exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }
            // Get the file contents of the directory to copy.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                string temppath = Path.Combine(destDirName, file.Name);
                try
                {
                    // Copy the file.
                    file.CopyTo(temppath, true);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.LogError(ex);
                    MessageBox.Show("Error Logged to log_file.txt" + Environment.NewLine + ex.Message);
                }
            }
            // If copySubDirs is true, copy the subdirectories.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    // Create the subdirectory.
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    // Copy the subdirectories.
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
        private static void DirectoryCopy2(string sourceDirName, string destDirName, bool copySubDirs)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(sourceDirName);
                DirectoryInfo[] dirs = dir.GetDirectories();

                if (!dir.Exists)
                {
                    throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);
                }

                // Adjust destination directory path to include the source folder name
                destDirName = Path.Combine(destDirName, dir.Name);

                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }

                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(destDirName, file.Name);
                    try
                    {
                        file.CopyTo(temppath, true);
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.LogError(ex);
                        // Log the exception to aid in debugging.
                        MessageBox.Show("Error Handler" + Environment.NewLine + ex.Message);
                    }
                }

                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string temppath = Path.Combine(destDirName, subdir.Name);
                        DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogError(ex);
                // Log the exception to aid in debugging.
                MessageBox.Show("Error Handler" + Environment.NewLine + ex.Message);
            }
        }

        private void nsOnOffBox1_Click(object sender, EventArgs e)
        {

            if (!nsOnOffBox1.Checked)
            {
                try
                {
                    for (int i = 0; i < nsListView1.SelectedItems.Length; i++)
                    {
                        nsListView1.RemoveItem(nsListView1.SelectedItems[0]);
                        foreach (NSListViewItem item in nsListView1.SelectedItems)
                        {


                            string userfile;
                            string userfile2;

                            string usercfg;
                            usercfg = @"\UserCFG.ini";
                            userfile2 = UserSettings(Application.StartupPath + usercfg, "Mod_Path") + @"\";//enabled folder
                            userfile = Application.StartupPath + @"\" + @"disabled\";
                            var dir = new DirectoryInfo(userfile2 + item.Text);
                            dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;

                            if (!nsListView2.Items.Any(i => i.Text == item.Text))
                            {

                                nsListView2.AddItem(item.Text);
                                nsLabel3.Value2 = "  [" + item.Text + " Disabled]";
                                timer2.Start();
                            }
                            else
                            {
                                nsLabel3.Value2 = "  [" + item.Text + " Disabled]";
                                timer2.Start();
                                //do nothing
                            }
                            File.SetAttributes(userfile2, FileAttributes.Normal);
                            File.SetAttributes(userfile, FileAttributes.Normal);
                            DirectoryCopy(userfile2 + item.Text, userfile + item.Text, true);
                            try
                            {
                                dir.Delete(true);
                            }
                            catch (Exception ex)
                            {
                                ExceptionHandler.LogError(ex);
                                MessageBox.Show("Error Handler" + Environment.NewLine + ex.Message);
                            }



                        }

                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.LogError(ex);
                    MessageBox.Show("Error Handler" + Environment.NewLine + ex.Message);
                }
            }
            else if (nsOnOffBox1.Checked)
            {
                //do nothing
            }

        }
        private void nsOnOffBox2_Click(object sender, EventArgs e)
        {
            if (nsOnOffBox2.Checked)
            {
                try
                {
                    for (int i = 0; i < nsListView2.SelectedItems.Length; i++)
                    {
                        nsListView2.RemoveItem(nsListView2.SelectedItems[0]);
                        foreach (NSListViewItem item in nsListView2.SelectedItems)
                        {

                            string userfile;
                            string userfile2;
                            string usercfg;
                            usercfg = @"\UserCFG.ini";
                            userfile2 = UserSettings(Application.StartupPath + usercfg, "Mod_Path") + @"\";//enabled folder
                            userfile = Application.StartupPath + @"\" + @"disabled\";
                            var dir = new DirectoryInfo(userfile + item.Text);
                            dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                            if (!nsListView1.Items.Any(i => i.Text == item.Text))
                            {

                                nsListView1.AddItem(item.Text);
                                nsLabel3.Value2 = "  [" + item.Text + " Enabled]";
                                timer2.Start();
                            }
                            else
                            {
                                nsLabel3.Value2 = "  [" + item.Text + " Enabled]";
                                timer2.Start();
                            }
                            File.SetAttributes(userfile, FileAttributes.Normal);
                            File.SetAttributes(userfile2, FileAttributes.Normal);
                            DirectoryCopy(userfile + item.Text, userfile2 + item.Text, true);
                            dir.Delete(true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.LogError(ex);
                    MessageBox.Show("Error Handler" + Environment.NewLine + ex.Message);
                }
            }
            else if (!nsOnOffBox2.Checked)
            {
                //do nothing
            }
        }

        private void nsButton4_Click(object sender, EventArgs e)
        {
            foreach (NSListViewItem eachItem in nsListView3.Items)
            {    
                nsListView3.RemoveItemAt(0); // Clear/Refresh lists

            }
            foreach (NSListViewItem eachItem in nsListView4.Items)
            {
                nsListView4.RemoveItemAt(0); // Clear/Refresh lists

            }
            foreach (NSListViewItem eachItem in nsListView5.Items)
            {
                nsListView5.RemoveItemAt(0); // Clear/Refresh lists

            }

            using (var client = new WebClient())
            {
                string uri;
                string creatdir;
                string dwnldflder;
                uri = "https://github.com/V0idpool/TotK-Tools-Mod-Manager/releases/download/ModPack/TOTK-Mods-collection_v3.1_full.7z";
                creatdir = Application.StartupPath + @"mod_downloads\";
                dwnldflder = Application.StartupPath + @"mod_downloads\MODS.7z";
                Directory.CreateDirectory(creatdir);
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback4);
                client.DownloadFileAsync(new System.Uri(uri), dwnldflder);
                client.Headers.Add("user-agent", "Chrome");
                client.DownloadFileCompleted += DownloadCompleted;

            }

        }
        public static string FormatDurationSeconds(int seconds)
        {
            var duration = TimeSpan.FromSeconds(seconds);
            string result = "";
            if (duration.TotalHours >= 1)
                result += (int)duration.TotalHours + " Hours, ";
            result += String.Format("{0:%m} Minutes, {0:%s} Seconds", duration);
            return result;
        }
        public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            string dwnldflder;
            string unzip;
            unzip = Application.StartupPath + @"\mod_downloads\MODS.7z";
            dwnldflder = Application.StartupPath + @"\mod_downloads\";
            System.IO.Directory.CreateDirectory(dwnldflder);
            using (ArchiveFile archiveFile = new ArchiveFile(unzip))
            {
                archiveFile.Extract(dwnldflder); // Extract all

            }
            timer1.Start();

            MessageBox.Show("Successsfully Downloaded Updates");


        }

        public void ClearAllModLists()
        {

            foreach (NSListViewItem eachItem in nsListView1.Items)
            {
             
                nsListView1.RemoveItemAt(0); // Clear/Refresh lists

            }
            foreach (NSListViewItem eachItem in nsListView2.Items)
            {
              
                nsListView2.RemoveItemAt(0); // Clear/Refresh lists

            }
            foreach (NSListViewItem eachItem in nsListView3.Items)
            {
             
                nsListView3.RemoveItemAt(0); // Clear/Refresh lists

            }
            foreach (NSListViewItem eachItem in nsListView4.Items)
            {
              
                nsListView4.RemoveItemAt(0); // Clear/Refresh lists

            }
            foreach (NSListViewItem eachItem in nsListView5.Items)
            {
             
                nsListView5.RemoveItemAt(0); // Clear/Refresh lists

            }


        }

        public static string FormatFileSize(long bytes)
        {
            var unit = 1024;
            if (bytes < unit) { return $"{bytes} B"; }

            var exp = (int)(Math.Log(bytes) / Math.Log(unit));
            return $"{bytes / Math.Pow(unit, exp):F2} {("KMGTPE")[exp - 1]}B";
        }
        private void DownloadProgressCallback4(object sender, DownloadProgressChangedEventArgs e)
        {

            var bytestoreceive = FormatFileSize(e.BytesReceived);
            var totalbytestoreceived = FormatFileSize(e.TotalBytesToReceive);
            string strMsg = String.Format("{0} {1} of {2} {3}%", e.UserState, bytestoreceive, totalbytestoreceived, e.ProgressPercentage);
            //Console.WriteLine(strMsg, e.UserState, e.BytesReceived, e.TotalBytesToReceive);
            label1.Text = strMsg;
            nsProgressBar1.Value = e.ProgressPercentage;
        }
        private void nsButton1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < nsListView3.SelectedItems.Length; i++)
                {
                    foreach (NSListViewItem item in nsListView3.SelectedItems)
                    {
                        string userfile;
                        string userfile2;
                        string usercfg;
                        usercfg = @"\UserCFG.ini";
                        userfile2 = Application.StartupPath + @"\mod_downloads\Mods\Graphics\";// Mod download folder \Graphics
                        userfile = UserSettings(Application.StartupPath + usercfg, "Mod_Path") + @"\";// Enabled folder
                        var dir = new DirectoryInfo(userfile2 + item.Text);
                        dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                        if (!nsListView1.Items.Any(i => i.Text == item.Text))
                        {

                            nsListView1.AddItem(item.Text);
                            nsLabel3.Value2 = "  [" + item.Text + " Enabled]";
                            timer2.Start();
                        }
                        else
                        {
                            nsLabel3.Value2 = "  [" + item.Text + " Enabled]";
                            timer2.Start();
                        }
                        File.SetAttributes(userfile, FileAttributes.Normal);
                        File.SetAttributes(userfile2, FileAttributes.Normal);
                        DirectoryCopy(userfile2 + item.Text, userfile + item.Text, true);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogError(ex);
                MessageBox.Show("Error Handler" + Environment.NewLine + ex.Message);
            }
        }
        private void nsButton5_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < nsListView4.SelectedItems.Length; i++)
                {
                    foreach (NSListViewItem item in nsListView4.SelectedItems)
                    {
                        string userfile;
                        string userfile2;
                        string usercfg;
                        usercfg = @"\UserCFG.ini";
                        userfile2 = Application.StartupPath + @"\mod_downloads\Mods\FPS\";// Mod download folder \FPS
                        userfile = UserSettings(Application.StartupPath + usercfg, "Mod_Path") + @"\";// Enabled folder
                        var dir = new DirectoryInfo(userfile2 + item.Text);
                        dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                        if (!nsListView1.Items.Any(i => i.Text == item.Text))
                        {

                            nsListView1.AddItem(item.Text);
                            nsLabel3.Value2 = "  [" + item.Text + " Enabled]";
                            timer2.Start();
                        }
                        else
                        {
                            nsLabel3.Value2 = "  [" + item.Text + " Enabled]";
                            timer2.Start();
                        }
                        File.SetAttributes(userfile, FileAttributes.Normal);
                        File.SetAttributes(userfile2, FileAttributes.Normal);
                        DirectoryCopy(userfile2 + item.Text, userfile + item.Text, true);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogError(ex);
                MessageBox.Show("Error Handler" + Environment.NewLine + ex.Message);
            }
        }
        private void nsButton6_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < nsListView5.SelectedItems.Length; i++)
                {
                    foreach (NSListViewItem item in nsListView5.SelectedItems)
                    {

                        string userfile;
                        string userfile2;
                        string usercfg;
                        usercfg = @"\UserCFG.ini";
                        userfile2 = Application.StartupPath + @"\mod_downloads\Mods\CHEATS\";// Mod download folder \CHEATS
                        userfile = UserSettings(Application.StartupPath + usercfg, "Mod_Path") + @"\";// Enabled folder
                        var dir = new DirectoryInfo(userfile2 + item.Text);
                        dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                        if (!nsListView1.Items.Any(i => i.Text == item.Text))
                        {


                            nsListView1.AddItem(item.Text);
                            nsLabel3.Value2 = "  [" + item.Text + " Enabled]";
                            timer2.Start();
                        }
                        else
                        {
                            nsLabel3.Value2 = "  [" + item.Text + " Enabled]";
                            timer2.Start();
                        }
                        File.SetAttributes(userfile, FileAttributes.Normal);
                        File.SetAttributes(userfile2, FileAttributes.Normal);
                        DirectoryCopy(userfile2 + item.Text, userfile + item.Text, true);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogError(ex);
                MessageBox.Show("Error Handler" + Environment.NewLine + ex.Message);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (Application.OpenForms["Settings"] == null)
            {

                var settingsform = new Settings();

                settingsform.Show(this);
               
            }
            else
            {
                //do nothing
            }
        }
        public void MyrefeshMethod()
        {   
            string usercfg;
            usercfg = @"\UserCFG.ini";
            // User Settings Creation

            foreach (NSListViewItem eachItem in nsListView1.Items)
            {
              
                nsListView1.RemoveItemAt(0); // Clear/Refresh lists

            }
            foreach (NSListViewItem eachItem in nsListView2.Items)
            {
                //eachItem.SubItems.RemoveAt(0);
                nsListView2.RemoveItemAt(0); // Clear/Refresh lists

            }

            DirectoryInfo dir = new DirectoryInfo(UserSettings(Application.StartupPath + usercfg, "Mod_Path") + @"\");//enabled folder
            DirectoryInfo[] subdirs = dir.GetDirectories();
            foreach (DirectoryInfo item in subdirs)
            {
                nsListView1.AddItem(item.Name);
            }
            DirectoryInfo dir2 = new DirectoryInfo(Application.StartupPath + @"\disabled\");//disabled folder
            DirectoryInfo[] subdirs2 = dir2.GetDirectories();
            foreach (DirectoryInfo item2 in subdirs2)
            {
                nsListView2.AddItem(item2.Name);
            }


        }
        private void nsListView1_Click(object sender, EventArgs e)
        {

        }

        private void nsButton7_Click(object sender, EventArgs e)
        {
            string usercfg;
            usercfg = @"\UserCFG.ini";
            System.Diagnostics.Process.Start(UserSettings(Application.StartupPath + usercfg, "EMU_Path") + @"\yuzu.exe");// Run game from path
        }

        private void backupSavesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to backup your saves?", "TotK Tools Mod Manager", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string userfile;
                string userfile2;
                string usercfg;
                var INI2 = new TotKModManager.inisettings(); // access to inisettings.cs functions
                INI2.Path = Application.StartupPath + @"\UserCFG.ini"; // defines path of .ini
                usercfg = @"\UserCFG.ini";
                userfile = UserSettings(Application.StartupPath + usercfg, "Save_Backup_Path");
                userfile2 = UserSettings(Application.StartupPath + usercfg, "Save_Path");
                var dir = new DirectoryInfo(userfile2);
                var dir2 = new DirectoryInfo(userfile);
                dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                dir2.Delete(true);
                DirectoryCopy(userfile2, userfile, true);
                MessageBox.Show("Save Data Successfully Backed Up!");
                INI2.WriteValue("Settings", "Last_Save_Backup", DateTime.Now.ToString(), INI2.GetPath());  

            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

        }

        private void restoreSavesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to restore your saves?", "TotK Tools Mod Manager", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string userfile;
                string userfile2;
                string usercfg;
                usercfg = @"\UserCFG.ini";
                userfile = UserSettings(Application.StartupPath + usercfg, "Save_Path");
                userfile2 = UserSettings(Application.StartupPath + usercfg, "Save_Backup_Path");
                var dir = new DirectoryInfo(userfile2);
                var dir2 = new DirectoryInfo(userfile);
                dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                dir2.Delete(true);
                DirectoryCopy(userfile2, userfile, true);
                MessageBox.Show("Save Data Successfully Restored From Back-up!");
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }



        }

        private void backupModsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to backup your mods?", "TotK Tools Mod Manager", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string userfile;
                string userfile2;
                string usercfg;
                var INI2 = new TotKModManager.inisettings(); // access to inisettings.cs functions
                INI2.Path = Application.StartupPath + @"\UserCFG.ini"; // defines path of .ini
                usercfg = @"\UserCFG.ini";
                userfile = UserSettings(Application.StartupPath + usercfg, "Mod_Backup_Path");
                userfile2 = UserSettings(Application.StartupPath + usercfg, "Mod_Path");
                var dir = new DirectoryInfo(userfile2);
                var dir2 = new DirectoryInfo(userfile);
                dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                dir2.Delete(true);
                DirectoryCopy(userfile2, userfile, true);
                MessageBox.Show("Mod Data Successfully Backed Up!");
                INI2.WriteValue("Settings", "Last_Mod_Backup", DateTime.Now.ToString(), INI2.GetPath()); 
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

        }

        private void restoreModsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to restore your mods?", "TotK Tools Mod Manager", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string userfile;
                string userfile2;
                string usercfg;
                usercfg = @"\UserCFG.ini";
                userfile = UserSettings(Application.StartupPath + usercfg, "Mod_Path");
                userfile2 = UserSettings(Application.StartupPath + usercfg, "Mod_Backup_Path");
                var dir = new DirectoryInfo(userfile2);
                var dir2 = new DirectoryInfo(userfile);
                dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                dir2.Delete(true);
                DirectoryCopy(userfile2, userfile, true);
                MessageBox.Show("Mod Data Successfully Restored From Back-up!");
                MyrefeshMethod();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["AboutForm"] == null)
            {
                var aboutform = new AboutForm();
                aboutform.Show();
            }
            else
            {
                //do nothing
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            nsLabel3.Value2 = "Waiting...";
            timer2.Enabled = false;
        }

        private void nsLabel1_Click(object sender, EventArgs e)
        {

        }

        private void nsLabel3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            string usercfg;
            usercfg = @"\UserCFG.ini";


            DirectoryInfo dir3 = new DirectoryInfo(Application.StartupPath + @"mod_downloads\Mods\Graphics\");//Loaded Graphics Folder
            DirectoryInfo[] subdirs3 = dir3.GetDirectories();
            foreach (DirectoryInfo item3 in subdirs3)
            {
                try
                {

                    nsListView3.AddItem(item3.Name);

                }
                catch (Exception ex)
                {
                    ExceptionHandler.LogError(ex);
                    MessageBox.Show("Error Handler" + Environment.NewLine + ex.Message);
                }

            }
            DirectoryInfo dir4 = new DirectoryInfo(Application.StartupPath + @"mod_downloads\Mods\FPS\");//Loaded FPS Folder
            DirectoryInfo[] subdirs4 = dir4.GetDirectories();
            foreach (DirectoryInfo item4 in subdirs4)
            {
                try
                {

                    nsListView4.AddItem(item4.Name);
                }

                catch (Exception ex)
                { 
                    ExceptionHandler.LogError(ex);
                    MessageBox.Show("Error Handler" + Environment.NewLine + ex.Message);
                }

            }
            DirectoryInfo dir5 = new DirectoryInfo(Application.StartupPath + @"mod_downloads\Mods\CHEATS\");//Loaded CHEATS Folder
            DirectoryInfo[] subdirs5 = dir5.GetDirectories();
            foreach (DirectoryInfo item5 in subdirs5)
            {

                try
                {


                    nsListView5.AddItem(item5.Name);


                }
                catch (Exception ex)
                {
                    ExceptionHandler.LogError(ex);
                    MessageBox.Show("Error Handler" + Environment.NewLine + ex.Message);
                }

            }

            timer1.Enabled = false;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void clearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                clearFolder(di.FullName);
                di.Delete();
            }
        }
        private void nsButton8_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to clear the Disabled Mods Folder?", "TotK Tools Mod Manager", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                string disableflder;
                disableflder = Application.StartupPath + @"\" + @"disabled\";
                clearFolder(disableflder);
                foreach (NSListViewItem eachItem in nsListView2.Items)
                {
                   
                    nsListView2.RemoveItemAt(0); // Clear/Refresh lists

                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void clearShaderCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to clear the Shader Cache Pipeline?", "TotK Tools Mod Manager", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                string userfile = @"\UserCFG.ini";

                string clrshaders;
                clrshaders = UserSettings(Application.StartupPath + userfile, "EMU_Path") + @"\" + @"user\shader";
                clearFolder(clrshaders);
                nsLabel3.Text = "[Shader Pipeline Cache Cleared]";
                timer2.Start();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
        private string FindFile(string directory, string fileName)
        {
            string foundFileName = null;
            try
            {
                foundFileName = Directory.GetFiles(directory, fileName,
    new EnumerationOptions
    {
        IgnoreInaccessible = true,
        RecurseSubdirectories = true,
    }).FirstOrDefault();
                if (String.IsNullOrEmpty(foundFileName))
                {
                    foreach (string dir in Directory.GetDirectories(directory))
                    {
                        foundFileName = FindFile(dir, fileName);
                        if (!String.IsNullOrEmpty(foundFileName))
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogError(ex);
            } // The most likely exception is UnauthorizedAccessException
                      // and there is not much to do about that :[

            return foundFileName;
        }

        private void zSTLibCOMINGSOONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var zsttool = new zstdtools();
            zsttool.Show();
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rSTBMergerCOMINGSOONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show();

        }

        private void standardPresetToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            try
            {
                string userfile;
                userfile = @"\UserCFG.ini";
                var INI2 = new TotKModManager.inisettings(); // access to inisettings.cs functions
                INI2.Path = UserSettings(Application.StartupPath + userfile, "EMU_Path") + @"\user\config\custom\0100F2C0115B6000.ini"; // defines path of .ini

                // Set Yuzu's qt-config file values for AMD Standard Preset option
                INI2.WriteValue("Core", "memory_layout_mode", "0", INI2.GetPath()); 
                INI2.WriteValue("Core", "speed_limit", "100", INI2.GetPath()); 
                INI2.WriteValue("Core", "use_multi_core", "true", INI2.GetPath());
                INI2.WriteValue("Core", @"memory_layout_mode\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Core", @"speed_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Core", @"use_multi_core\default", "true", INI2.GetPath());
                INI2.WriteValue("Core", @"use_unsafe_extended_memory_layout\default", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpu_accuracy", "0", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpu_accuracy_first_time", "false", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpu_backend", "0", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpu_debug_mode", "false", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_block_linking", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_const_prop", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_context_elimination", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_fast_dispatcher", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_fastmem", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_fastmem_exclusives", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_ignore_memory_aborts", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_misc_ir", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_page_tables", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_recompile_exclusives", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_reduce_misalign_checks", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_return_stack_buffer", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_fastmem_check", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_ignore_global_monitor", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_ignore_standard_fpcr", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_inaccurate_nan", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_reduce_fp_error", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_unfuse_fma", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpu_accuracy\use_global", "false", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpu_accuracy_first_time\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpu_backend\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpu_debug_mode\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_block_linking\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_const_prop\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_context_elimination\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_fast_dispatcher\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_fastmem\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_fastmem_exclusives\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_ignore_memory_aborts\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_misc_ir\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_page_tables\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_recompile_exclusives\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_reduce_misalign_checks\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_return_stack_buffer\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_fastmem_check\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_ignore_global_monitor\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_ignore_standard_fpcr\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_inaccurate_nan\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_reduce_fp_error\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_unfuse_fma\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "accelerate_astc", "1", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "anti_aliasing", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "aspect_ratio", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "astc_recompression", "2", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "async_astc", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "async_presentation", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "backend", "1", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "barrier_feedback_loops", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "bg_blue", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "bg_green", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "bg_red", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "disable_fps_limit", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "enable_compute_pipelines", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "force_max_clock", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "frame_limit", "100", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "fullscreen_mode", "1", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "gpu_accuracy", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "max_anisotropy", "3", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "resolution_setup", "2", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "scaling_filter", "1", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "shader_backend", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "shader_feedback", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "speed_limit", "100", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_assembly_shaders", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_asynchronous_gpu_emulation", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_asynchronous_shaders", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_caches_gc", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_disk_shader_cache", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_fast_gpu_time", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_frame_limit", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_nvdec_emulation", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_reactive_flushing", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_video_framerate", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_vsync", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_vulkan_driver_pipeline_cache", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "vulkan_device", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"accelerate_astc\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"anti_aliasing\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"aspect_ratio\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"astc_recompression\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"async_astc\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"async_presentation\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"backend\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"barrier_feedback_loops\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"bg_blue\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"bg_green\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"bg_red\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"debug", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"debug\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"disable_buffer_reorder", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"disable_buffer_reorder\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"disable_fps_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"enable_compute_pipelines\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"force_max_clock\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"frame_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"fullscreen_mode\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"gpu_accuracy\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"max_anisotropy\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"nvdec_emulation\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"resolution_setup\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"scaling_filter\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"shader_backend\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"shader_feedback\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"speed_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_assembly_shaders\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_asynchronous_gpu_emulation\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_asynchronous_shaders\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_caches_gc\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_disk_shader_cache\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_fast_gpu_time\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_frame_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_nvdec_emulation\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_reactive_flushing\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_video_framerate\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_vsync\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_vulkan_driver_pipeline_cache\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"vulkan_device\default", "true", INI2.GetPath()); 
                MessageBox.Show("AMD Standard Settings Applied!");
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogError(ex);
            }


        }

        private void highPresetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string userfile;
                userfile = @"\UserCFG.ini";
                var INI2 = new TotKModManager.inisettings(); // access to inisettings.cs functions
                INI2.Path = INI2.Path = UserSettings(Application.StartupPath + userfile, "EMU_Path") + @"\user\config\custom\0100F2C0115B6000.ini"; // defines path of .ini

                // Set Yuzu's qt-config file values for AMD High Preset option
                INI2.WriteValue("Core", "memory_layout_mode", "1", INI2.GetPath()); 
                INI2.WriteValue("Core", "speed_limit", "100", INI2.GetPath()); 
                INI2.WriteValue("Core", "use_multi_core", "true", INI2.GetPath());
                INI2.WriteValue("Core", @"memory_layout_mode\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Core", @"speed_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Core", @"use_multi_core\default", "true", INI2.GetPath());
                INI2.WriteValue("Core", @"use_unsafe_extended_memory_layout\default", "false", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpu_accuracy", "0", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpu_accuracy_first_time", "false", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpu_backend", "0", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpu_debug_mode", "false", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_block_linking", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_const_prop", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_context_elimination", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_fast_dispatcher", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_fastmem", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_fastmem_exclusives", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_ignore_memory_aborts", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_misc_ir", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_page_tables", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_recompile_exclusives", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_reduce_misalign_checks", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_return_stack_buffer", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_fastmem_check", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_ignore_global_monitor", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_ignore_standard_fpcr", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_inaccurate_nan", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_reduce_fp_error", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_unfuse_fma", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpu_accuracy\use_global", "false", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpu_accuracy_first_time\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpu_backend\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpu_debug_mode\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_block_linking\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_const_prop\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_context_elimination\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_fast_dispatcher\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_fastmem\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_fastmem_exclusives\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_ignore_memory_aborts\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_misc_ir\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_page_tables\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_recompile_exclusives\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_reduce_misalign_checks\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_return_stack_buffer\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_fastmem_check\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_ignore_global_monitor\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_ignore_standard_fpcr\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_inaccurate_nan\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_reduce_fp_error\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_unfuse_fma\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "accelerate_astc", "1", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "anti_aliasing", "2", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "aspect_ratio", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "astc_recompression", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "async_astc", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "async_presentation", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "backend", "1", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "barrier_feedback_loops", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "bg_blue", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "bg_green", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "bg_red", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "disable_fps_limit", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "enable_compute_pipelines", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "force_max_clock", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "frame_limit", "100", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "fullscreen_mode", "1", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "gpu_accuracy", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "max_anisotropy", "5", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "resolution_setup", "5", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "scaling_filter", "1", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "shader_backend", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "shader_feedback", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "speed_limit", "100", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_assembly_shaders", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_asynchronous_gpu_emulation", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_asynchronous_shaders", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_caches_gc", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_disk_shader_cache", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_fast_gpu_time", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_frame_limit", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_nvdec_emulation", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_reactive_flushing", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_video_framerate", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_vsync", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_vulkan_driver_pipeline_cache", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "vulkan_device", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"accelerate_astc\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"anti_aliasing\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"aspect_ratio\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"astc_recompression\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"async_astc\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"async_presentation\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"backend\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"barrier_feedback_loops\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"bg_blue\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"bg_green\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"bg_red\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"debug", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"debug\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"disable_buffer_reorder", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"disable_buffer_reorder\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"disable_fps_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"enable_compute_pipelines\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"force_max_clock\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"frame_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"fullscreen_mode\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"gpu_accuracy\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"max_anisotropy\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"nvdec_emulation\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"resolution_setup\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"scaling_filter\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"shader_backend\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"shader_feedback\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"speed_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_assembly_shaders\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_asynchronous_gpu_emulation\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_asynchronous_shaders\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_caches_gc\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_disk_shader_cache\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_fast_gpu_time\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_frame_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_nvdec_emulation\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_reactive_flushing\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_video_framerate\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_vsync\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_vulkan_driver_pipeline_cache\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"vulkan_device\default", "true", INI2.GetPath()); 
                MessageBox.Show("AMD High Settings Applied!");
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogError(ex);
            }
        }

        private void standardPresetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string userfile;
                userfile = @"\UserCFG.ini";
                var INI2 = new TotKModManager.inisettings(); // access to inisettings.cs functions
                INI2.Path = UserSettings(Application.StartupPath + userfile, "EMU_Path") + @"\user\config\custom\0100F2C0115B6000.ini"; // defines path of .ini

                // Set Yuzu's qt-config file values for Nvidia Standard Preset option
                INI2.WriteValue("Core", "memory_layout_mode", "0", INI2.GetPath()); 
                INI2.WriteValue("Core", "speed_limit", "100", INI2.GetPath()); 
                INI2.WriteValue("Core", "use_multi_core", "true", INI2.GetPath());
                INI2.WriteValue("Core", @"memory_layout_mode\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Core", @"speed_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Core", @"use_multi_core\default", "true", INI2.GetPath());
                INI2.WriteValue("Core", @"use_unsafe_extended_memory_layout", "false", INI2.GetPath());
                INI2.WriteValue("Core", @"use_unsafe_extended_memory_layout\default", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpu_accuracy", "0", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpu_accuracy_first_time", "false", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpu_backend", "0", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpu_debug_mode", "false", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_block_linking", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_const_prop", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_context_elimination", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_fast_dispatcher", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_fastmem", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_fastmem_exclusives", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_ignore_memory_aborts", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_misc_ir", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_page_tables", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_recompile_exclusives", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_reduce_misalign_checks", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_return_stack_buffer", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_fastmem_check", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_ignore_global_monitor", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_ignore_standard_fpcr", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_inaccurate_nan", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_reduce_fp_error", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_unfuse_fma", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpu_accuracy\use_global", "false", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpu_accuracy_first_time\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpu_backend\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpu_debug_mode\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_block_linking\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_const_prop\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_context_elimination\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_fast_dispatcher\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_fastmem\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_fastmem_exclusives\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_ignore_memory_aborts\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_misc_ir\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_page_tables\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_recompile_exclusives\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_reduce_misalign_checks\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_return_stack_buffer\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_fastmem_check\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_ignore_global_monitor\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_ignore_standard_fpcr\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_inaccurate_nan\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_reduce_fp_error\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_unfuse_fma\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "accelerate_astc", "1", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "anti_aliasing", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "aspect_ratio", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "astc_recompression", "2", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "async_astc", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "async_presentation", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "backend", "1", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "barrier_feedback_loops", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "bg_blue", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "bg_green", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "bg_red", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "disable_fps_limit", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "enable_compute_pipelines", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "force_max_clock", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "frame_limit", "100", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "fullscreen_mode", "1", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "gpu_accuracy", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "max_anisotropy", "3", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "resolution_setup", "2", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "scaling_filter", "1", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "shader_backend", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "shader_feedback", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "speed_limit", "100", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_assembly_shaders", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_asynchronous_gpu_emulation", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_asynchronous_shaders", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_caches_gc", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_disk_shader_cache", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_fast_gpu_time", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_frame_limit", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_nvdec_emulation", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_reactive_flushing", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_video_framerate", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_vsync", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_vulkan_driver_pipeline_cache", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "vulkan_device", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"accelerate_astc\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"anti_aliasing\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"aspect_ratio\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"astc_recompression\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"async_astc\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"async_presentation\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"backend\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"barrier_feedback_loops\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"bg_blue\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"bg_green\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"bg_red\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"debug", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"debug\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"disable_buffer_reorder", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"disable_buffer_reorder\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"disable_fps_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"enable_compute_pipelines\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"force_max_clock\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"frame_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"fullscreen_mode\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"gpu_accuracy\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"max_anisotropy\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"nvdec_emulation\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"resolution_setup\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"scaling_filter\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"shader_backend\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"shader_feedback\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"speed_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_assembly_shaders\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_asynchronous_gpu_emulation\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_asynchronous_shaders\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_caches_gc\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_disk_shader_cache\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_fast_gpu_time\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_frame_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_nvdec_emulation\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_reactive_flushing\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_video_framerate\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_vsync\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_vulkan_driver_pipeline_cache\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"vulkan_device\default", "true", INI2.GetPath()); 
                MessageBox.Show("NVIDIA Standard Settings Applied!");
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogError(ex);
            }
        }

        private void highPresetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                string userfile;
                userfile = @"\UserCFG.ini";
                var INI2 = new TotKModManager.inisettings(); // access to inisettings.cs functions
                INI2.Path = UserSettings(Application.StartupPath + userfile, "EMU_Path") + @"\user\config\custom\0100F2C0115B6000.ini"; // defines path of .ini

                // Set Yuzu's qt-config file values for NVIDIA High Preset option
                INI2.WriteValue("Core", "memory_layout_mode", "1", INI2.GetPath()); 
                INI2.WriteValue("Core", "speed_limit", "100", INI2.GetPath()); 
                INI2.WriteValue("Core", "use_multi_core", "true", INI2.GetPath());
                INI2.WriteValue("Core", @"memory_layout_mode\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Core", @"speed_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Core", @"use_multi_core\default", "true", INI2.GetPath());
                INI2.WriteValue("Core", @"use_unsafe_extended_memory_layout\default", "false", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpu_accuracy", "0", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpu_accuracy_first_time", "false", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpu_backend", "0", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpu_debug_mode", "false", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_block_linking", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_const_prop", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_context_elimination", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_fast_dispatcher", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_fastmem", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_fastmem_exclusives", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_ignore_memory_aborts", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_misc_ir", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_page_tables", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_recompile_exclusives", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_reduce_misalign_checks", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_return_stack_buffer", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_fastmem_check", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_ignore_global_monitor", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_ignore_standard_fpcr", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_inaccurate_nan", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_reduce_fp_error", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_unfuse_fma", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpu_accuracy\use_global", "false", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpu_accuracy_first_time\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpu_backend\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpu_debug_mode\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_block_linking\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_const_prop\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_context_elimination\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_fast_dispatcher\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_fastmem\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_fastmem_exclusives\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_ignore_memory_aborts\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_misc_ir\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_page_tables\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_recompile_exclusives\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_reduce_misalign_checks\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_return_stack_buffer\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_fastmem_check\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_ignore_global_monitor\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_ignore_standard_fpcr\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_inaccurate_nan\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_reduce_fp_error\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_unfuse_fma\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "accelerate_astc", "1", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "anti_aliasing", "2", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "aspect_ratio", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "astc_recompression", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "async_astc", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "async_presentation", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "backend", "1", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "barrier_feedback_loops", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "bg_blue", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "bg_green", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "bg_red", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "disable_fps_limit", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "enable_compute_pipelines", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "force_max_clock", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "frame_limit", "100", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "fullscreen_mode", "1", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "gpu_accuracy", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "max_anisotropy", "5", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "resolution_setup", "5", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "scaling_filter", "1", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "shader_backend", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "shader_feedback", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "speed_limit", "100", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_assembly_shaders", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_asynchronous_gpu_emulation", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_asynchronous_shaders", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_caches_gc", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_disk_shader_cache", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_fast_gpu_time", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_frame_limit", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_nvdec_emulation", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_reactive_flushing", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_video_framerate", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_vsync", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_vulkan_driver_pipeline_cache", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "vulkan_device", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"accelerate_astc\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"anti_aliasing\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"aspect_ratio\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"astc_recompression\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"async_astc\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"async_presentation\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"backend\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"barrier_feedback_loops\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"bg_blue\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"bg_green\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"bg_red\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"debug", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"debug\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"disable_buffer_reorder", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"disable_buffer_reorder\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"disable_fps_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"enable_compute_pipelines\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"force_max_clock\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"frame_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"fullscreen_mode\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"gpu_accuracy\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"max_anisotropy\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"nvdec_emulation\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"resolution_setup\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"scaling_filter\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"shader_backend\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"shader_feedback\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"speed_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_assembly_shaders\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_asynchronous_gpu_emulation\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_asynchronous_shaders\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_caches_gc\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_disk_shader_cache\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_fast_gpu_time\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_frame_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_nvdec_emulation\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_reactive_flushing\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_video_framerate\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_vsync\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_vulkan_driver_pipeline_cache\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"vulkan_device\default", "true", INI2.GetPath()); 
                MessageBox.Show("NVIDIA High Settings Applied!");
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogError(ex);
            }
        }

        private void standardPresetToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                string userfile;
                userfile = @"\UserCFG.ini";
                var INI2 = new TotKModManager.inisettings(); // access to inisettings.cs functions
                INI2.Path = UserSettings(Application.StartupPath + userfile, "EMU_Path") + @"\user\config\custom\0100F2C0115B6000.ini"; // defines path of .ini

                // Set Yuzu's qt-config file values for SteamDeck Standard Preset option
                INI2.WriteValue("Core", "memory_layout_mode", "0", INI2.GetPath()); 
                INI2.WriteValue("Core", "speed_limit", "100", INI2.GetPath()); 
                INI2.WriteValue("Core", "use_multi_core", "true", INI2.GetPath()); 
                INI2.WriteValue("Core", @"memory_layout_mode\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Core", @"speed_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Core", @"use_multi_core\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Core", @"use_unsafe_extended_memory_layout\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpu_accuracy", "0", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpu_accuracy_first_time", "false", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpu_backend", "0", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpu_debug_mode", "false", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_block_linking", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_const_prop", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_context_elimination", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_fast_dispatcher", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_fastmem", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_fastmem_exclusives", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_ignore_memory_aborts", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_misc_ir", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_page_tables", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_recompile_exclusives", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_reduce_misalign_checks", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_return_stack_buffer", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_fastmem_check", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_ignore_global_monitor", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_ignore_standard_fpcr", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_inaccurate_nan", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_reduce_fp_error", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", "cpuopt_unsafe_unfuse_fma", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpu_accuracy\use_global", "false", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpu_accuracy_first_time\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpu_backend\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpu_debug_mode\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_block_linking\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_const_prop\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_context_elimination\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_fast_dispatcher\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_fastmem\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_fastmem_exclusives\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_ignore_memory_aborts\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_misc_ir\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_page_tables\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_recompile_exclusives\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_reduce_misalign_checks\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_return_stack_buffer\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_fastmem_check\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_ignore_global_monitor\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_ignore_standard_fpcr\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_inaccurate_nan\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_reduce_fp_error\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_unfuse_fma\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "accelerate_astc", "1", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "anti_aliasing", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "aspect_ratio", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "astc_recompression", "1", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "async_astc", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "async_presentation", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "backend", "1", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "barrier_feedback_loops", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "bg_blue", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "bg_green", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "bg_red", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "disable_fps_limit", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "enable_compute_pipelines", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "force_max_clock", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "frame_limit", "100", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "fullscreen_mode", "1", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "gpu_accuracy", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "max_anisotropy", "3", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "resolution_setup", "2", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "scaling_filter", "1", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "shader_backend", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "shader_feedback", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "speed_limit", "100", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_assembly_shaders", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_asynchronous_gpu_emulation", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_asynchronous_shaders", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_caches_gc", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_disk_shader_cache", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_fast_gpu_time", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_frame_limit", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_nvdec_emulation", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_reactive_flushing", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_video_framerate", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_vsync", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "use_vulkan_driver_pipeline_cache", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", "vulkan_device", "0", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"accelerate_astc\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"anti_aliasing\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"aspect_ratio\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"astc_recompression\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"async_astc\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"async_presentation\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"backend\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"barrier_feedback_loops\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"bg_blue\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"bg_green\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"bg_red\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"debug", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"debug\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"disable_buffer_reorder", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"disable_buffer_reorder\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"disable_fps_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"enable_compute_pipelines\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"force_max_clock\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"frame_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"fullscreen_mode\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"gpu_accuracy\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"max_anisotropy\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"nvdec_emulation\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"resolution_setup\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"scaling_filter\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"shader_backend\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"shader_feedback\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"speed_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_assembly_shaders\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_asynchronous_gpu_emulation\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_asynchronous_shaders\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_caches_gc\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_disk_shader_cache\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_fast_gpu_time\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_frame_limit\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_nvdec_emulation\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_reactive_flushing\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_video_framerate\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_vsync\default", "false", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"use_vulkan_driver_pipeline_cache\default", "true", INI2.GetPath()); 
                INI2.WriteValue("Renderer", @"vulkan_device\default", "true", INI2.GetPath()); 
                MessageBox.Show("Steamdeck Standard Settings Applied!");
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogError(ex);
            }
        }

        private void highPresetNOTRECOMMENDEDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string userfile;
                userfile = @"\UserCFG.ini";
                var INI2 = new TotKModManager.inisettings(); // access to inisettings.cs functions
                INI2.Path = UserSettings(Application.StartupPath + userfile, "EMU_Path") + @"\user\config\custom\0100F2C0115B6000.ini"; // defines path of .ini

                // Set Yuzu's qt-config file values for SteamDeck High Preset option
                INI2.WriteValue("Core", "memory_layout_mode", "1", INI2.GetPath());
                INI2.WriteValue("Core", "speed_limit", "100", INI2.GetPath());
                INI2.WriteValue("Core", "use_multi_core", "true", INI2.GetPath());
                INI2.WriteValue("Core", @"memory_layout_mode\default", "false", INI2.GetPath());
                INI2.WriteValue("Core", @"speed_limit\default", "true", INI2.GetPath());
                INI2.WriteValue("Core", @"use_multi_core\default", "true", INI2.GetPath());
                INI2.WriteValue("Core", @"use_unsafe_extended_memory_layout\default", "false", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpu_accuracy", "0", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpu_accuracy_first_time", "false", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpu_backend", "0", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpu_debug_mode", "false", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpuopt_block_linking", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpuopt_const_prop", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpuopt_context_elimination", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpuopt_fast_dispatcher", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpuopt_fastmem", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpuopt_fastmem_exclusives", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpuopt_ignore_memory_aborts", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpuopt_misc_ir", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpuopt_page_tables", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpuopt_recompile_exclusives", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpuopt_reduce_misalign_checks", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpuopt_return_stack_buffer", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpuopt_unsafe_fastmem_check", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpuopt_unsafe_ignore_global_monitor", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpuopt_unsafe_ignore_standard_fpcr", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpuopt_unsafe_inaccurate_nan", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpuopt_unsafe_reduce_fp_error", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", "cpuopt_unsafe_unfuse_fma", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpu_accuracy\use_global", "false", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpu_accuracy_first_time\default", "false", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpu_backend\default", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpu_debug_mode\default", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpuopt_block_linking\default", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpuopt_const_prop\default", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpuopt_context_elimination\default", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpuopt_fast_dispatcher\default", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpuopt_fastmem\default", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpuopt_fastmem_exclusives\default", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpuopt_ignore_memory_aborts\default", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpuopt_misc_ir\default", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpuopt_page_tables\default", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpuopt_recompile_exclusives\default", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpuopt_reduce_misalign_checks\default", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpuopt_return_stack_buffer\default", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_fastmem_check\default", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_ignore_global_monitor\default", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_ignore_standard_fpcr\default", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_inaccurate_nan\default", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_reduce_fp_error\default", "true", INI2.GetPath());
                INI2.WriteValue("Cpu", @"cpuopt_unsafe_unfuse_fma\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", "accelerate_astc", "1", INI2.GetPath());
                INI2.WriteValue("Renderer", "anti_aliasing", "1", INI2.GetPath());
                INI2.WriteValue("Renderer", "aspect_ratio", "0", INI2.GetPath());
                INI2.WriteValue("Renderer", "astc_recompression", "2", INI2.GetPath());
                INI2.WriteValue("Renderer", "async_astc", "false", INI2.GetPath());
                INI2.WriteValue("Renderer", "async_presentation", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", "backend", "1", INI2.GetPath());
                INI2.WriteValue("Renderer", "barrier_feedback_loops", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", "bg_blue", "0", INI2.GetPath());
                INI2.WriteValue("Renderer", "bg_green", "0", INI2.GetPath());
                INI2.WriteValue("Renderer", "bg_red", "0", INI2.GetPath());
                INI2.WriteValue("Renderer", "disable_fps_limit", "false", INI2.GetPath());
                INI2.WriteValue("Renderer", "enable_compute_pipelines", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", "force_max_clock", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", "frame_limit", "100", INI2.GetPath());
                INI2.WriteValue("Renderer", "fullscreen_mode", "1", INI2.GetPath());
                INI2.WriteValue("Renderer", "gpu_accuracy", "0", INI2.GetPath());
                INI2.WriteValue("Renderer", "max_anisotropy", "4", INI2.GetPath());
                INI2.WriteValue("Renderer", "resolution_setup", "4", INI2.GetPath());
                INI2.WriteValue("Renderer", "scaling_filter", "1", INI2.GetPath());
                INI2.WriteValue("Renderer", "shader_backend", "0", INI2.GetPath());
                INI2.WriteValue("Renderer", "shader_feedback", "false", INI2.GetPath());
                INI2.WriteValue("Renderer", "speed_limit", "100", INI2.GetPath());
                INI2.WriteValue("Renderer", "use_assembly_shaders", "false", INI2.GetPath());
                INI2.WriteValue("Renderer", "use_asynchronous_gpu_emulation", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", "use_asynchronous_shaders", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", "use_caches_gc", "false", INI2.GetPath());
                INI2.WriteValue("Renderer", "use_disk_shader_cache", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", "use_fast_gpu_time", "false", INI2.GetPath());
                INI2.WriteValue("Renderer", "use_frame_limit", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", "use_nvdec_emulation", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", "use_reactive_flushing", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", "use_video_framerate", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", "use_vsync", "false", INI2.GetPath());
                INI2.WriteValue("Renderer", "use_vulkan_driver_pipeline_cache", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", "vulkan_device", "0", INI2.GetPath());
                INI2.WriteValue("Renderer", @"accelerate_astc\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"anti_aliasing\default", "false", INI2.GetPath());
                INI2.WriteValue("Renderer", @"aspect_ratio\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"astc_recompression\default", "false", INI2.GetPath());
                INI2.WriteValue("Renderer", @"async_astc\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"async_presentation\default", "false", INI2.GetPath());
                INI2.WriteValue("Renderer", @"backend\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"barrier_feedback_loops\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"bg_blue\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"bg_green\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"bg_red\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"debug", "false", INI2.GetPath());
                INI2.WriteValue("Renderer", @"debug\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"disable_buffer_reorder", "false", INI2.GetPath());
                INI2.WriteValue("Renderer", @"disable_buffer_reorder\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"disable_fps_limit\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"enable_compute_pipelines\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"force_max_clock\default", "false", INI2.GetPath());
                INI2.WriteValue("Renderer", @"frame_limit\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"fullscreen_mode\default", "false", INI2.GetPath());
                INI2.WriteValue("Renderer", @"gpu_accuracy\default", "false", INI2.GetPath());
                INI2.WriteValue("Renderer", @"max_anisotropy\default", "false", INI2.GetPath());
                INI2.WriteValue("Renderer", @"nvdec_emulation\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"resolution_setup\default", "false", INI2.GetPath());
                INI2.WriteValue("Renderer", @"scaling_filter\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"shader_backend\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"shader_feedback\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"speed_limit\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"use_assembly_shaders\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"use_asynchronous_gpu_emulation\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"use_asynchronous_shaders\default", "false", INI2.GetPath());
                INI2.WriteValue("Renderer", @"use_caches_gc\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"use_disk_shader_cache\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"use_fast_gpu_time\default", "false", INI2.GetPath());
                INI2.WriteValue("Renderer", @"use_frame_limit\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"use_nvdec_emulation\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"use_reactive_flushing\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"use_video_framerate\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"use_vsync\default", "false", INI2.GetPath());
                INI2.WriteValue("Renderer", @"use_vulkan_driver_pipeline_cache\default", "true", INI2.GetPath());
                INI2.WriteValue("Renderer", @"vulkan_device\default", "true", INI2.GetPath());
                MessageBox.Show("Steamdeck High Settings Applied!");
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogError(ex);
            }
        }

        private void manuallyAddModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var filebrowser = new FolderBrowserDialog();
                filebrowser.InitialDirectory = Application.StartupPath;
                if (filebrowser.ShowDialog() == DialogResult.OK)
                {

                    string userfile;
                    string userfile2;
                    string usercfg;
                    string folder;

                    usercfg = @"\UserCFG.ini";
                    userfile2 = Application.StartupPath + @"\mod_downloads\Mods\Graphics\";// Downloaded mods folder \Graphics 
                    userfile = UserSettings(Application.StartupPath + usercfg, "Mod_Path") + @"\";// Enabled folder
                    folder = Path.GetFileName(filebrowser.SelectedPath);
                    if (!nsListView1.Items.Any(i => i.Text == folder))
                    {

                        nsListView1.AddItem(folder);
                        nsLabel3.Value2 = "  [" + filebrowser.SelectedPath + " Enabled]";
                        timer2.Start();
                    }
                    else
                    {
                        nsLabel3.Value2 = "  [" + filebrowser.SelectedPath + " Enabled]";
                        timer2.Start();
                    }
                    File.SetAttributes(userfile, FileAttributes.Normal);
                    File.SetAttributes(userfile2, FileAttributes.Normal);
                    DirectoryCopy2(filebrowser.SelectedPath, userfile, true);
                }
            }
            catch (Exception ex) 
            {
                ExceptionHandler.LogError(ex);
            }

        }

        private void openModsFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string usercfg;
                usercfg = @"\UserCFG.ini";
                string folderPath = UserSettings(Application.StartupPath + usercfg, "Mod_Path");
                OpenFolderInExplorer(folderPath);
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogError(ex);
                MessageBox.Show("Error Handler" + Environment.NewLine + ex.Message);
            }
        }

        private void openSaveFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string usercfg;
                usercfg = @"\UserCFG.ini";
                string folderPath = UserSettings(Application.StartupPath + usercfg, "Save_Path");
                OpenFolderInExplorer(folderPath);
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogError(ex);
                MessageBox.Show("Error Handler" + Environment.NewLine + ex.Message);
            }
        }

        private void saveEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveeditor = new Save_Editor();

            saveeditor.Show();
        }
        static async Task<string> FetchHtmlContent(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    return await client.GetStringAsync(url);
                }
                catch (HttpRequestException ex)
                {
                    ExceptionHandler.LogError(ex);
                    Console.WriteLine($"Error fetching HTML content: {ex.Message}");
                    return null;
                }
            }
        }

        static string ExtractVersion(string htmlContent)
        {
            // Use a regular expression to find the version number
            Regex regex = new Regex(@"<div class=""stat"">([\d.]+)<\/div>");
            Match match = regex.Match(htmlContent);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return null;
        }
        private async void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Replace this URL with the actual URL of your Nexus Mods page
            string url = "https://www.nexusmods.com/legendofzeldatearsofthekingdom/mods/122";

            // Fetch HTML content from the URL
            string htmlContent = await FetchHtmlContent(url);
            if (htmlContent != null)
            {
                string versionNumber = ExtractVersion(htmlContent);
                // Load the HTML content into XmlDocument


                if (versionNumber != null)
                {
                    // Get the inner text which contains the version number


                    Console.WriteLine("Current Version: " + versionNumber);
                    if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                    {

                        string currentApp = $"{Application.ProductVersion}";


                        if (String.Compare(currentApp, versionNumber) < 0)
                        {
                            if (MessageBox.Show($"A new update is available!{Environment.NewLine}Would you like to update to version: {versionNumber}?", "TotK Tools Mod Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                var mirrors = new PreferredMirror();
                                mirrors.ShowDialog(); 

                            }
                        }
                        else
                        {
                            MessageBox.Show("You are currently up to date", "TotK Tools Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cannot Complete Update Check!{Environment.NewLine}No Network Connection Detected.", "TotK Tools Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    Console.WriteLine("Version information not found in the HTML.");
                }
            }
            else
            {
                Console.WriteLine("Error fetching HTML content.");
            }


        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
           var zstdtool = new Zstd();
            zstdtool.Show();
        }
    }

  
}