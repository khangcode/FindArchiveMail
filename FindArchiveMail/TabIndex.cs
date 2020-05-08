using Lucene.Net.Index;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindArchiveMail
{
    public partial class TabIndex : TabPage
    {
        public TabIndex()
        {
            InitializeComponent();
            TxtPath.Text = MyConfig.GetMailFolder();
        }

        private System.ComponentModel.BackgroundWorker bW1;
        private void InitBackgroundWorker()
        {
            bW1 = new System.ComponentModel.BackgroundWorker();
            bW1.DoWork += new System.ComponentModel.DoWorkEventHandler(bW1_DoWork);
            //bW1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(bW1_ProgressChanged);
            bW1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bW1_RunWorkerCompleted);
            //bW1.WorkerReportsProgress = true;
        }
        private void BtnReIndexAll_Click(object sender, EventArgs e)
        {
            InitBackgroundWorker();

            bW1Arg arg = new bW1Arg(true);
            TxtStatus.Clear();
            TxtStatus.Text = "Program is running. It is very time consuming, Please wait ...";
            bW1.RunWorkerAsync(arg);
        }

        private void BtnFromTo_Click(object sender, EventArgs e)
        {
            InitBackgroundWorker();
            bW1Arg arg = new bW1Arg(DPickerFrom, DPickerTo);

            TxtStatus.Clear();
            TxtStatus.Text = "Program is running. It is very time consuming, Please wait ...";
            bW1.RunWorkerAsync(arg);
        }

        private void bW1_DoWork(object sender, DoWorkEventArgs e)
        {
            bW1Arg dArg = e.Argument as bW1Arg;

            List<FileMeta> lst = MyIO.GetFileMsgFromTo(dArg.MailFolder, dArg.DFrom, dArg.DTo);
            WorkerThread2 workerThread = new WorkerThread2();
            e.Result = workerThread.RunMT(lst, dArg.IsReIndex);
        }

        //private void bW1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    TxtStatus.Text += (string) e.UserState;
        //    TxtStatus.Text += Environment.NewLine;
        //}

        private void bW1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            WorkerThreadResult result = e.Result as WorkerThreadResult;
            TxtStatus.Clear();
            TxtStatus.AppendText("Total processed files: " + result.FileDone.Count.ToString());
            TxtStatus.AppendText(Environment.NewLine);
            TxtStatus.AppendText("Total duplicate files: " + result.NumDupFiles.ToString());
            TxtStatus.AppendText(Environment.NewLine);
            if (!string.IsNullOrEmpty(result.ErrLog))
            {
                TxtStatus.AppendText("Error: ");
                TxtStatus.AppendText(Environment.NewLine);
                TxtStatus.AppendText(result.ErrLog);
            }
        }

        private void BtnMonthIndex_Click(object sender, EventArgs e)
        {
            DPickerFrom.Checked = true;
            DPickerTo.Checked = true;
            DPickerFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddSeconds(-1);
            DPickerTo.Value = DateTime.Now;
            BtnFromTo.PerformClick();
        }

        private void BtnPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            MyConfig.SaveSetting("MailFolder", folderBrowserDialog.SelectedPath);
            TxtPath.Text = MyConfig.GetMailFolder();
        }
    }
}
