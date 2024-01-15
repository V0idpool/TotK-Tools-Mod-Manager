using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TotKModManager
{
    public partial class Emudetector : Form
    {
        public Emudetector()
        {
            InitializeComponent();
        }

        private void Emudetector_Load(object sender, EventArgs e)
        {

            var drv = DriveInfo.GetDrives();
            foreach (DriveInfo dInfo in drv)
            {
                nsComboBox1.Items.Add(dInfo.Name);

                //dInfo.Name();
            }
            nsComboBox1.SelectedItem = @"C:\";
        }
        string foundFileName = null;
        private string FindFile(string directory, string fileName)
        {

            try
            {


                foundFileName = Directory.GetFiles(directory, fileName, new EnumerationOptions { IgnoreInaccessible = true, RecurseSubdirectories = true, }).FirstOrDefault();
                if (String.IsNullOrEmpty(foundFileName))
                {


                    foreach (string dir in Directory.GetDirectories(directory))
                    {
                        foundFileName = FindFile(dir, fileName);
                        if (!String.IsNullOrEmpty(foundFileName))

                            break;

                    }
                }
                else
                {

                }

            }
            catch (Exception ex) 
            {
                ExceptionHandler.LogError(ex);

            } // The most likely exception is UnauthorizedAccessException
              // and there is not much to do about that
            return foundFileName;

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
        private void nsButton7_Click(object sender, EventArgs e)
        {
            nsLabel2.Value2 = " Searching...";
            DialogResult dialogResult = MessageBox.Show("This is an experimental feature!" + Environment.NewLine + "Are you sure you want to Auto-Detect?" + Environment.NewLine + "This will cause the program to temporarily block user input until your install location is found." + Environment.NewLine + "This could take a few minutes depending on your drive speed, and amount of space used by your drive. Please be patient as it searches.", "TotK Tools Mod Manager", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
               
               

                    try
                    {

                        string userfile;
                        userfile = @"\UserCFG.ini";
                        var INI2 = new inisettings(); // access to inisettings.cs functions
                        INI2.Path = Application.StartupPath + @"\UserCFG.ini"; // defines path of .ini
                        string foundFilePath = FindFile(nsComboBox1.SelectedItem.ToString(), @"yuzu.exe");
                        if (!String.IsNullOrEmpty(foundFilePath))
                        {
                            string path = Path.GetDirectoryName(foundFilePath);

                            INI2.WriteValue("Settings", "EMU_Path", path.ToString(), INI2.GetPath());
                            INI2.WriteValue("Settings", "Mod_Path", path.ToString() + @"\user\load\0100F2C0115B6000", INI2.GetPath());
                            INI2.WriteValue("Settings", "Mod_Backup_Path", Application.StartupPath + @"Mod_Backups", INI2.GetPath());
                            INI2.WriteValue("Settings", "Save_Backup_Path", Application.StartupPath + @"Save_Backups", INI2.GetPath());
                            INI2.WriteValue("Settings", "Save_Path", path.ToString() + @"\user\nand\user\save", INI2.GetPath());
                            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Mod_Backups\");
                            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Save_Backups\");
                            timer1.Start();
                            MessageBox.Show("File found: " + foundFilePath);
                            if (Application.OpenForms["Settings"] == null)
                            {
                                try
                                {
                                    ((Form1)this.Owner).MyrefeshMethod();
                                }
                                catch (Exception ex)
                                {
                                ExceptionHandler.LogError(ex);
                                }
                                var settingsform = new Settings();
                                settingsform.Show();
                                this.Close();
                            }
                            else
                            {
                                //do nothing
                            }
                         
                        }
                        else
                        {
                            nsLabel2.Value2 = " Waiting...";
                            MessageBox.Show("Yuzu installation not detected on the selected drive!" + Environment.NewLine + "Please select the drive your EMU is installed on.");
                        }
                    }
                    catch (Exception ex)
                    {
                    ExceptionHandler.LogError(ex);
                    }
             
            
            }
            else if (dialogResult == DialogResult.No)
            {
                nsLabel2.Value2 = " Waiting...";
            }
 

           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            nsLabel2.Value2 = " Waiting...";
            timer1.Enabled = false;
        }

        private void nsButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            nsLabel2.Value2 = " Searching...";
            timer2.Enabled = false;
        }

    }
}

