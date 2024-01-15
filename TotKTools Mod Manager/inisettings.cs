using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace TotKModManager
{
    public class inisettings
    {



        [DllImport("kernel32", EntryPoint = "GetPrivateProfileStringA", CharSet = CharSet.Ansi)]
        private static extern int GetPrivateProfileString(string lpApplicationName, string lpSchlüsselName, string lpDefault, string lpReturnedString, int nSize, string lpFileName);

        [DllImport("kernel32", EntryPoint = "WritePrivateProfileStringA", CharSet = CharSet.Ansi)]
        private static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);

        [DllImport("kernel32", EntryPoint = "WritePrivateProfileStringA", CharSet = CharSet.Ansi)]
        private static extern int DeletePrivateProfileSection(string Section, int NoKey, int NoSetting, string FileName);

        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileIntA", CharSet = CharSet.Ansi)]
        private static extern int GetPrivateProfileInt(string lpApplicationName, string lpKeyName, int nDefault, string lpFileName);

        private string strFilename;

        public string Path;
        private void LogMessage(string message, string logFilePath)
        {
            try
            {
                // Append the message to the log file
                System.IO.File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogError(ex);
                // Handle any exceptions that may occur while writing to the log file
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }
            public string ReadValue(string Section, string Key, string DefaultValue = "", int BufferSize = 1024)
        {
            string ReadValueRet = default;

            if (string.IsNullOrEmpty(Path))
            {
                Interaction.MsgBox("No path given" + Constants.vbNewLine + "Could not read Value", MsgBoxStyle.Critical, "No path given");
                ReadValueRet = "Error";
                return ReadValueRet;
            }

            if (System.IO.File.Exists(Path) == false)
            {
                Interaction.MsgBox("File does not exist" + Constants.vbNewLine + "Could not read Value", MsgBoxStyle.Critical, "File does not exist");
                ReadValueRet = "Error";
                return ReadValueRet;
            }

            string sTemp = Strings.Space(BufferSize);
            int Length = inisettings.GetPrivateProfileString(Section,Key,DefaultValue,sTemp, BufferSize,Path);
            return Strings.Left(sTemp, Length);

        }

        public bool GetBoolean(string Section, string Key, bool Default)
        {
            // Returns a boolean from your INI file
            return inisettings.GetPrivateProfileInt(Section,Key, Conversions.ToInteger(Default),strFilename) == 1;
        }

        public string GetPath()
        {
            return Path;
        }

        public void WriteValue(string Section, string Key, string Value, string path)
        {

            if (string.IsNullOrEmpty(Path))
            {
                //do nothing
                //Interaction.MsgBox("No path given" + Constants.vbNewLine + "Could not write Value", MsgBoxStyle.Critical, "No path given");
                return;
            }

            string Ordner;
            Ordner = System.IO.Path.GetDirectoryName(path);
            if (System.IO.Directory.Exists(Ordner) == false)
            {
                //do nothing
                //Interaction.MsgBox("File does not exist" + Constants.vbNewLine + "Could not write Value", MsgBoxStyle.Critical, "Files does not exist");
                return;
            }

            inisettings.WritePrivateProfileString(Section,Key,Value,Path);
        }

        public void DeleteKey(string Section, string Key)
        {

            if (string.IsNullOrEmpty(Path))
            {
                Interaction.MsgBox("No path given" + Constants.vbNewLine + "Could not delete Key", MsgBoxStyle.Critical, "No path given");
                return;
            }

            string Ordner;
            Ordner = System.IO.Path.GetDirectoryName(Path);
            if (System.IO.Directory.Exists(Ordner) == false)
            {
                Interaction.MsgBox("File does not exist" + Constants.vbNewLine + "Could not delete Key", MsgBoxStyle.Critical, "File does not exist");
                return;
            }

            string arglpString = null;
            inisettings.WritePrivateProfileString(Section,Key,arglpString,Path);
        }

        public void DeleteSection(string Section)
        {

            if (string.IsNullOrEmpty(Path))
            {
                Interaction.MsgBox("No path given" + Constants.vbNewLine + "Could not delete Section", MsgBoxStyle.Critical, "No path given");
                return;
            }

            if (System.IO.File.Exists(Path) == false)
            {
                Interaction.MsgBox("File does not exist (anymore)" + Constants.vbNewLine + "Could not delete Section", MsgBoxStyle.Critical, "File does not exist");
                return;
            }

            inisettings.DeletePrivateProfileSection(Section, 0, 0,Path);
        }
  //destructor
 ~inisettings()
            {
            
  }
        



    }
}