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
    public partial class TabAbout : TabPage
    {
        public TabAbout()
        {
            InitializeComponent();
            LblVersion.Text = string.Format("version {0}, @2020.04", MyConfig.GetVersion());
        }
    }
}
