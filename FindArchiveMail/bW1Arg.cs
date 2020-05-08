using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindArchiveMail
{
    public class bW1Arg
    {
        public string MailFolder;
        public bW1Arg() { }
        public bW1Arg(System.Windows.Forms.DateTimePicker DPickerFrom, System.Windows.Forms.DateTimePicker DPickerTo)
        {
            IsReIndex = false;
            DFromNaN = DPickerFrom.Value;
            DFromChecked = DPickerFrom.Checked;
            DToNaN = DPickerTo.Value;
            DToChecked = DPickerTo.Checked;
            MailFolder = MyConfig.GetMailFolder();
        }
        public bW1Arg(bool bReIndex)
        {
            IsReIndex = bReIndex;
            MailFolder = MyConfig.GetMailFolder();
        }
        public bool IsReIndex { get; set; }
        public bool DFromChecked { get; set; }
        public DateTime DFromNaN { get; set; }
        public bool DToChecked { get; set; }
        public DateTime DToNaN { get; set; }

        public DateTime? DFrom
        {
            get
            {
                if (DFromChecked) return DFromNaN;
                else return null;
            }
        }
        public DateTime? DTo
        {
            get
            {
                if (DToChecked) return DToNaN;
                else return null;
            }
        }
    }
}
