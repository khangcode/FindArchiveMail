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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TsBtnCloseAll_Click(object sender, EventArgs e)
        {
            for (int i = tabControl1.TabPages.Count - 1; i >= 0; i--)
            {
                if (tabControl1.TabPages[i].GetType() != typeof(TabFind))
                {
                    tabControl1.TabPages.RemoveAt(i);
                }
            }
        }

        private void TsBtnClose_Click(object sender, EventArgs e)
        {
            int i = tabControl1.SelectedIndex;
            if (tabControl1.TabPages[i].GetType() != typeof(TabFind))
            {
                tabControl1.TabPages.RemoveAt(i);
            }
            tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
        }

        private void TsBtnShowFindPanel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                if (tabControl1.TabPages[i].GetType() == typeof(TabFind))
                {
                    TsBtnShowFindPanel.Text = (tabControl1.TabPages[i] as TabFind).HideFindPanel(this.Width);
                    tabControl1.SelectedIndex = i;
                    return;
                }
            }
        }


        private void TsIndex_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                if (tabControl1.TabPages[i].GetType() == typeof(TabIndex))
                {
                    tabControl1.SelectedIndex = i;
                    return;
                }
            }
            TabIndex indexTab = new TabIndex();
            tabControl1.TabPages.Add(indexTab);
            tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
        }

        private void TsBtnAbout_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                if (tabControl1.TabPages[i].GetType() == typeof(TabAbout))
                {
                    tabControl1.SelectedIndex = i;
                    return;
                }
            }
            TabAbout tab = new TabAbout();
            tabControl1.TabPages.Add(tab);
            tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
        }
    }
}
