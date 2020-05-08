using Lucene.Net.Documents;
using Lucene.Net.Search;
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
    public partial class TabFind : TabPage
    {
        private DataTable dt = new DataTable();
        private List<MailData> lst = null;
        public TabFind()
        {
            InitializeComponent();

            RdBtnReceivedOn.Checked = true;
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("SentOn", typeof(DateTime));
            dt.Columns.Add("SenderEmailAddress", typeof(string));
            dt.Columns.Add("Subject", typeof(string));
            dt.Columns.Add("ReceivedOn", typeof(DateTime));
            bindingSource1.DataSource = dt;
            AvDataGridView1.DataSource = bindingSource1;
        }
        private bool CheckTextBoxNotNull(TextBox txt)
        {
            if (string.IsNullOrEmpty(txt.Text)) return false;
            if (string.IsNullOrEmpty(txt.Text.Trim())) return false;
            return true;
        }
        private void BtnFind_Click(object sender, EventArgs e)
        {
            int iMaxResult = 1000;
            if (CheckTextBoxNotNull(TxtMaxResult))
                Int32.TryParse(TxtMaxResult.Text, out iMaxResult);
            if (iMaxResult < 1)
                iMaxResult = 1000;
            TxtMaxResult.Text = iMaxResult.ToString();

            BooleanQuery allQuery = new BooleanQuery();

            TermRangeQuery queryFromTo = null;
            string sFrom = DateTools.DateToString(DPickerFrom.Value, DateTools.Resolution.MINUTE);
            string sTo = DateTools.DateToString(DPickerTo.Value, DateTools.Resolution.MINUTE);
            if (RdBtnSentOn.Checked) //Sent
            {
                if (DPickerFrom.Checked && DPickerTo.Checked)
                { queryFromTo = new TermRangeQuery("SentOn", sFrom, sTo, true, true); }
                else if (DPickerFrom.Checked && !DPickerTo.Checked)
                { queryFromTo = new TermRangeQuery("SentOn", sFrom, null, true, true); }
                else if (!DPickerFrom.Checked && DPickerTo.Checked)
                { queryFromTo = new TermRangeQuery("SentOn", null, sTo, true, true); }
            }
            else
            {
                if (DPickerFrom.Checked && DPickerTo.Checked)
                { queryFromTo = new TermRangeQuery("ReceivedOn", sFrom, sTo, true, true); }
                else if (DPickerFrom.Checked && !DPickerTo.Checked)
                { queryFromTo = new TermRangeQuery("ReceivedOn", sFrom, null, true, true); }
                else if (!DPickerFrom.Checked && DPickerTo.Checked)
                { queryFromTo = new TermRangeQuery("ReceivedOn", null, sTo, true, true); }
            }

            if (queryFromTo != null)
            { allQuery.Add(queryFromTo, Occur.MUST); }

            Lucene.Net.Analysis.Standard.StandardAnalyzer analyzer = MyLucene.GetAnalyzer();
            if (CheckTextBoxNotNull(TxtBody))
            {
                Query querySubject = MyLucene.GetTextQuery("Subject", TxtBody.Text, analyzer);
                if (ChkSubject.Checked)
                {
                    allQuery.Add(querySubject, Occur.MUST);
                }
                else
                {
                    BooleanQuery query2 = new BooleanQuery();
                    Query queryBody = MyLucene.GetTextQuery("Body", TxtBody.Text, analyzer);
                    query2.Add(querySubject, Occur.SHOULD);
                    query2.Add(queryBody, Occur.SHOULD);
                    allQuery.Add(query2, Occur.MUST);
                }
            }

            if (CheckTextBoxNotNull(TxtReceiver))
            {
                BooleanQuery qReceiver = new BooleanQuery();
                Query qTo = MyLucene.GetTextQuery("To", TxtReceiver.Text, analyzer);
                Query qCC = MyLucene.GetTextQuery("CC", TxtReceiver.Text, analyzer);
                qReceiver.Add(qTo, Occur.SHOULD);
                qReceiver.Add(qCC, Occur.SHOULD);
                allQuery.Add(qReceiver, Occur.MUST);
            }

            if (CheckTextBoxNotNull(TxtSender))
            {
                BooleanQuery query3 = new BooleanQuery();
                Query qSender = MyLucene.GetTextQuery("SenderName", TxtSender.Text, analyzer);
                Query qSenderEmail = MyLucene.GetTextQuery("SenderEmailAddress", TxtSender.Text, analyzer);
                query3.Add(qSender, Occur.SHOULD);
                query3.Add(qSenderEmail, Occur.SHOULD);
                allQuery.Add(query3, Occur.MUST);
            }

            if (string.IsNullOrEmpty(allQuery.ToString()))
            { MessageBox.Show("Vui lòng chọn điều kiện", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            IndexSearcher searcher = MyLucene.GetSearcher();
            lst = MyLucene.Search(searcher, allQuery, iMaxResult);
            searcher.Dispose();
            analyzer.Dispose();

            dt.Clear();
            for (int i = 0; i < lst.Count; i++)
            {
                MailData mailData = lst[i];
                object[] row = { i, mailData.DSentOn, mailData.SenderEmailAddress, mailData.Subject, mailData.DReceivedOn };
                dt.Rows.Add(row);
            }
            bindingSource1.DataSource = dt;
        }

        private void AvDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            bindingSource1.Sort = AvDataGridView1.SortString;
        }

        private void AvDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSource1.Filter = AvDataGridView1.FilterString;
        }

        private void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            TsLabelTotalRow.Text = string.Format("Total Row: {0}", bindingSource1.List.Count);
        }
        private void AvDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (lst == null) return;
            if (lst.Count == 0) return;

            if (e.ColumnIndex == 3) //subject
            {
                int Id = Convert.ToInt32(AvDataGridView1.Rows[e.RowIndex].Cells[0].Value);
                string filePath = MyConfig.GetMailFolder() + lst[Id].FullFileName;
                try
                {
                    System.Diagnostics.Process.Start(filePath);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, "Thong bao loi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
            else
            {

                int Id = Convert.ToInt32(AvDataGridView1.Rows[e.RowIndex].Cells[0].Value);
                TabMailView tabMail = new TabMailView(lst[Id]);
                tabMail.Text = "View Mail " + Id.ToString();
                TabControl tabControl = this.Parent as TabControl;
                tabControl.TabPages.Add(tabMail);
                tabControl.SelectedIndex = tabControl.TabCount - 1;

            }
        }

        private readonly int Splitter_Distance = 356;
        private bool IsShowFindPanel = true;
        public string HideFindPanel(int Form1Width)
        {
            if (IsShowFindPanel)
            {
                splitContainer1.SplitterDistance = 15;
                IsShowFindPanel = false;
                return "Show";
            }
            else
            {
                splitContainer1.SplitterDistance = Splitter_Distance;
                IsShowFindPanel = true;
                return "Hide";
            }
        }
        private void splitContainer1_Resize(object sender, EventArgs e)
        {
            if (IsShowFindPanel)
            {
                splitContainer1.SplitterDistance = Splitter_Distance;
            }
        }
    }
}
