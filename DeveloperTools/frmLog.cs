using System;
using System.Windows.Forms;


namespace DeveloperTools
{
    /// <summary>
    /// Shows optical traffic log, uses a static class to pick up events from other parts of the program
    /// </summary>
    public partial class frmLog : Form
    {

        clsKF2Logger.UpdateHandler _Target;
        string _sLastError;

        /// <summary>
        /// 
        /// </summary>
        public frmLog()
        {
            InitializeComponent();
        }

        private void UpdateLog()
        {
            Invoke((MethodInvoker)delegate
            {
                try
                {
                    int i = 0;
                    foreach (clsKF2Logger.stEventObject stEvent in clsKF2Logger.GetEvents())
                    {
                        if (GridViewLog.RowCount <= i)
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(GridViewLog);
                            row.Cells[0].Value = stEvent.Direction;
                            row.Cells[1].Value = stEvent.Data;
                            GridViewLog.Rows.Add(row);
                        }
                        i++;
                    }
                    if (i > 0)
                    {
                        GridViewLog.FirstDisplayedScrollingRowIndex = i - 1;
                    }

                    i = txtErrorLog.SelectionStart;
                    txtErrorLog.Text = clsKF2Logger.GetLog();
                    if (i > 0)
                    {
                        txtErrorLog.SelectionStart=i;
                    }
                }
                catch (Exception ex)
                {
                    _sLastError = ex.Message;
                }
            });

        }

        private void frmLog_Load(object sender, EventArgs e)
        {
            UpdateLog();
            _Target = new clsKF2Logger.UpdateHandler(UpdateLog);
            clsKF2Logger.AddEventHandler (_Target);
        }

        private void frmLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            clsKF2Logger.RemoveEventHandler(_Target);
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            clsKF2Logger.Clear();
        }
    }
}
