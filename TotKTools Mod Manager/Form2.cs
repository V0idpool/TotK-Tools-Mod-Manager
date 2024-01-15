
using System.Diagnostics;

namespace TotKModManager
{
    public partial class Form2 : Form
    {

        private const string dquote = @"\"; // Double Quotes "
        private delegate void AppendOutputTextDelegate(string text);
        Process process = new()
        {
            StartInfo = new()
            {
                FileName = Path.Combine(Application.StartupPath, "TotkRSTB.exe"),
                UseShellExecute = false,

                CreateNoWindow = true,
                WorkingDirectory = Application.StartupPath

            }
        };
        public Form2()
        {
            InitializeComponent();
        }
        private void AppendOutputText(string text) // Append text to output box
        {
            if (Outputbox.InvokeRequired)
            {
                var myDelegate = new AppendOutputTextDelegate(AppendOutputText);
                this.Invoke(myDelegate, text);

            }
            else
            {
                Outputbox.AppendText(Environment.NewLine + text);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            AppendOutputText("A simple CMD tool for editing RSTB/RESTBL files for TOTK.");
            AppendOutputText("-------------------------------------------------------------------------------------------------------------");
            AppendOutputText("\r\nNOTE: TotkRSTB will always choose the entry with the highest value, \nremoving entries will result in the program choosing the vanilla.");

        }

        private void nsButton2_Click(object sender, EventArgs e)
        {
            using var filebrowser = new OpenFileDialog();
            filebrowser.InitialDirectory = Application.StartupPath;
            if (filebrowser.ShowDialog() == DialogResult.OK)
            {
                nsTextBox1.Text = filebrowser.FileName;
            }
        }

        private void nsButton1_Click(object sender, EventArgs e)
        {


            process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                if (string.IsNullOrEmpty(e.Data))
                    return;

                BeginInvoke(() =>
                {
                    AppendOutputText(Environment.NewLine + e.Data);
                    //Outputbox.Refresh();
                });
            });


            process.EnableRaisingEvents = true;

            process.StartInfo.Arguments = '"' + nsTextBox1.Text + '"';
            process.Start();

            process.WaitForExit();

            if (process.WaitForExit(500))
            {
                AppendOutputText(nsTextBox1.Text + " : Successfully Converted!\r\nThe converted file can be found in the source file directory.");
            }
            else
            {
                // MessageBox.Show("Task timed out! Are you sure its a valid file?");
                // Timed out.
            }
        }

        private void nsButton3_Click(object sender, EventArgs e)
        {
            using var filebrowser = new OpenFileDialog();
            filebrowser.InitialDirectory = Application.StartupPath;
            if (filebrowser.ShowDialog() == DialogResult.OK)
            {
                nsTextBox2.Text = filebrowser.FileName;
            }
        }

        private void nsButton4_Click(object sender, EventArgs e)
        {

            process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                if (string.IsNullOrEmpty(e.Data))
                    return;

                BeginInvoke(() =>
                {
                    AppendOutputText(Environment.NewLine + e.Data);
                    //Outputbox.Refresh();
                });
            });


            process.EnableRaisingEvents = true;

            process.StartInfo.Arguments = '"' + nsTextBox2.Text + '"';
            process.Start();

            process.WaitForExit();

            if (process.WaitForExit(500))
            {
                AppendOutputText(nsTextBox2.Text + " : Successfully Converted!\r\nThe converted file can be found in the source file directory.");
            }
            else
            {
                // MessageBox.Show("Task timed out! Are you sure its a valid file?");
                // Timed out.
            }
        }

        private void nsButton5_Click(object sender, EventArgs e)
        {
            using var filebrowser = new OpenFileDialog();
            filebrowser.InitialDirectory = Application.StartupPath;
            if (filebrowser.ShowDialog() == DialogResult.OK)
            {
                nsTextBox3.Text = filebrowser.FileName;
            }
        }

        private void nsButton7_Click(object sender, EventArgs e)
        {
            using var filebrowser = new OpenFileDialog();
            filebrowser.InitialDirectory = Application.StartupPath;
            if (filebrowser.ShowDialog() == DialogResult.OK)
            {
                nsTextBox4.Text = filebrowser.FileName;
            }
        }

        private void nsButton9_Click(object sender, EventArgs e)
        {
            using var filebrowser = new FolderBrowserDialog();
            filebrowser.InitialDirectory = Application.StartupPath;
            if (filebrowser.ShowDialog() == DialogResult.OK)
            {
                nsTextBox5.Text = filebrowser.SelectedPath;
            }
        }

        private void nsButton6_Click(object sender, EventArgs e)
        {
            process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                if (string.IsNullOrEmpty(e.Data))
                    return;

                BeginInvoke(() =>
                {
                    AppendOutputText(Environment.NewLine + e.Data);
                    //Outputbox.Refresh();
                });
            });


            process.EnableRaisingEvents = true;

            process.StartInfo.Arguments = "--merge " + nsTextBox3.Text + " " + nsTextBox4.Text + " " + nsTextBox5.Text + @"\mergedmods.zs";
            process.Start();

            process.WaitForExit();

            if (process.WaitForExit(6000))
            {
                AppendOutputText(nsTextBox3.Text + " and " + nsTextBox4.Text + " : Successfully Merged!\r\nThe converted file can be found in the selected output file directory | " + nsTextBox5.Text + @"\mergedmods.zs");
            }
            else
            {
                // MessageBox.Show("Task timed out! Are you sure its a valid file?");
                // Timed out.
            }
        }

        private void nsButton11_Click(object sender, EventArgs e)
        {
            using var filebrowser = new OpenFileDialog();
            filebrowser.InitialDirectory = Application.StartupPath;
            if (filebrowser.ShowDialog() == DialogResult.OK)
            {
                nsTextBox8.Text = filebrowser.FileName;
            }
        }

        private void nsButton10_Click(object sender, EventArgs e)
        {
            using var filebrowser = new OpenFileDialog();
            filebrowser.InitialDirectory = Application.StartupPath;
            if (filebrowser.ShowDialog() == DialogResult.OK)
            {
                nsTextBox7.Text = filebrowser.FileName;
            }
        }

        private void nsButton8_Click(object sender, EventArgs e)
        {
            using var filebrowser = new FolderBrowserDialog();
            filebrowser.InitialDirectory = Application.StartupPath;
            if (filebrowser.ShowDialog() == DialogResult.OK)
            {
                nsTextBox6.Text = filebrowser.SelectedPath;
            }
        }

        private void nsButton12_Click(object sender, EventArgs e)
        {
            process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                if (string.IsNullOrEmpty(e.Data))
                    return;

                BeginInvoke(() =>
                {
                    AppendOutputText(Environment.NewLine + e.Data);
                    //Outputbox.Refresh();
                });
            });


            process.EnableRaisingEvents = true;

            process.StartInfo.Arguments = "--patch " + nsTextBox8.Text + " " + nsTextBox7.Text + " " + nsTextBox6.Text + @"\patchedmod.zs";
            process.Start();

            process.WaitForExit();

            if (process.WaitForExit(6000))
            {
                AppendOutputText(nsTextBox8.Text + " and " + nsTextBox7.Text + " : Successfully Merged!\r\nThe converted file can be found in the selected output file directory | " + nsTextBox6.Text + @"\patchedmod.zs");
            }
            else
            {
                // MessageBox.Show("Task timed out! Are you sure its a valid file?");
                // Timed out.
            }
        }

        private void nsButton15_Click(object sender, EventArgs e)
        {
            using var filebrowser = new OpenFileDialog();
            filebrowser.InitialDirectory = Application.StartupPath;
            if (filebrowser.ShowDialog() == DialogResult.OK)
            {
                nsTextBox11.Text = filebrowser.FileName;
            }
        }

        private void nsButton14_Click(object sender, EventArgs e)
        {
            using var filebrowser = new OpenFileDialog();
            filebrowser.InitialDirectory = Application.StartupPath;
            if (filebrowser.ShowDialog() == DialogResult.OK)
            {
                nsTextBox10.Text = filebrowser.FileName;
            }
        }



        private void nsButton16_Click(object sender, EventArgs e)
        {
            process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                if (string.IsNullOrEmpty(e.Data))
                    return;

                BeginInvoke(() =>
                {
                    AppendOutputText(Environment.NewLine + e.Data);
                    //Outputbox.Refresh();
                });
            });


            process.EnableRaisingEvents = true;

            process.StartInfo.Arguments = "--makepatch " + '"' + nsTextBox11.Text + '"' + " " + '"' + nsTextBox10.Text + '"';
            process.Start();

            process.WaitForExit();

            if (process.WaitForExit(6000))
            {
                AppendOutputText(nsTextBox11.Text + " and " + nsTextBox10.Text + " : Successfully made YAML Patch!\r\nThe Patch file can be found in the same directory as the modded RSTBL file you selected | " + nsTextBox10.Text);
            }
            else
            {
                // MessageBox.Show("Task timed out! Are you sure its a valid file?");
                // Timed out.
            }
        }
       
       
    }
}

