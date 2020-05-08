using Lucene.Net.Documents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindArchiveMail
{
    public class MailData
    {
        public DateTime DSentOn { get; set; }
        public string SentOn
        {
            get
            {
                return DateTools.DateToString(DSentOn, DateTools.Resolution.MINUTE);
            }
            set
            {
                DSentOn = DateTools.StringToDate(value);
            }
        }
        public DateTime DReceivedOn { get; set; }
        public string ReceivedOn
        {
            get
            {
                return DateTools.DateToString(DReceivedOn, DateTools.Resolution.MINUTE);
            }
            set
            {
                DReceivedOn = DateTools.StringToDate(value);
            }
        }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SenderEmailAddress { get; set; }
        public string SenderName { get; set; }
        public string To { get; set; }
        public string CC { get; set; }
       // public string Recipients { get; set; }
        public string Categories { get; set; }
        public string FlagRequest { get; set; }
        public string Importance { get; set; }
        public string AttachmentNames { get; set; }
        //Thuoc tinh cho file
        public string FullFileName { get; set; }
        public DateTime DLastWriteTime { get; set; }
        public string LastWriteTime
        {
            get
            {
                return DateTools.DateToString(DLastWriteTime, DateTools.Resolution.MINUTE);
            }
            set
            {
                DLastWriteTime = DateTools.StringToDate(value);
            }
        }
        public float Score { get; set; }
        public int ScoreDocDoc { get; set; }
        public MailData() { }
        public string ToHtml(string sPath)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<b>File Name: </b>");
            sb.Append(" <a id=\"filename\"  href=\"");
            sb.Append(sPath);
            sb.Append(FullFileName);
            sb.Append("\" >");
            sb.Append(sPath);
            sb.Append(FullFileName);
            sb.Append("</a> ");
            sb.Append("<br /><br />");

            sb.Append("<b>Saved Date: </b>");
            sb.Append(DLastWriteTime.ToString());
            sb.Append("<br /><br />");

            sb.Append("<b>Sender: </b>");
            sb.Append(SenderName);
            sb.Append(", ");
            sb.Append(SenderEmailAddress);
            sb.Append("<br /><br />");

            sb.Append("<b>To: </b>");
            sb.Append(To);
            sb.Append("<br /><br />");

            sb.Append("<b>CC: </b>");
            sb.Append(CC);
            sb.Append("<br /><br />");

            sb.Append("<b>Received on: </b>");
            sb.Append(DReceivedOn.ToString());
            sb.Append("<br /><br />");

            sb.Append("<b>Subject: </b>");
            sb.Append(Subject);
            sb.Append("<br /><br />");

            sb.Append("<b>Attachments: </b>");
            sb.Append(AttachmentNames);
            sb.Append("<br /><br />");

            sb.Append("<b>Body: </b>");
            sb.Append(Body.Replace(Environment.NewLine, "<br />"));
            sb.Append("<br /><br />");

            return sb.ToString();
        }
    }
}
