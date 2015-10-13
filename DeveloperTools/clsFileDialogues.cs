using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace DeveloperTools
{
    /// <summary>
    /// Provides some simple interfaces to load a common dialogue
    /// </summary>
    public class clsFileDialogues
    {
        /// <summary>
        /// provides a save file dialogue
        /// </summary>
        /// <param name="defaultFileName">the file name presented when the dialogue is first opened</param>
        /// <param name="filter">the filter pattern e.g. 'all files|*.*'</param>
        /// <returns>the file name selected</returns>
        static public string GetSaveFileName(string defaultFileName, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = defaultFileName;
            dlg.Filter = filter;
            dlg.AddExtension = true;
            dlg.CheckPathExists = true;
            dlg.OverwritePrompt = true;
            var dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                //  save the settings into the file
                return dlg.FileName;
            }
            return "";
        }

        /// <summary>
        /// Provides a load any file name dialogue
        /// </summary>
        /// <param name="FileName">output parameter containing the path and name</param>
        /// <returns>true when a file has been selected</returns>
        static public bool ShowLoadAllDialogue(out string FileName, string value)
        {
            FileName = "";
            try
            {
                OpenFileDialog dlgOpen = new OpenFileDialog();

                dlgOpen.Filter = "All Files|*.*";

                //Utilities.GetSetting("AllOpenDirectory", out value);
                dlgOpen.InitialDirectory = value;

                if (value.Length <= 0)
                    dlgOpen.InitialDirectory = Environment.CurrentDirectory;

                if (dlgOpen.ShowDialog() == DialogResult.OK)
                {
                    FileName = dlgOpen.FileName;
                    string initialDirectory = System.IO.Path.GetDirectoryName(dlgOpen.FileName);
                    //Utilities.SetSetting("AllOpenDirectory", initialDirectory);
                    return true;
                }
                return false;
            }
            catch 
            {
                //Utilities.GenericErrorMessage(ex.Message);
            }
            return false;
        }
    }
}
