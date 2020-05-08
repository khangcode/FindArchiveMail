using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindArchiveMail
{
    public class FileMeta
    {
        private string _MailFolder;
        public FileMeta(string MailFolder) 
        {
            _MailFolder = MailFolder;
        }
        public DateTime DLastWriteTime { get; set; }
        public string FullName { get; set; }
        public string FileNameWithoutPath
        {
            get
            {
                return FullName.Substring(_MailFolder.Length).EmptyIfNullEx();
            }
        }
        public string LastWriteTime
        {
            get
            {
                return Lucene.Net.Documents.DateTools.DateToString(DLastWriteTime, Lucene.Net.Documents.DateTools.Resolution.MINUTE);
            }
        }
    }

    public static class MyIO
    {
        public static List<FileMeta> GetFileMsg(string sPath)
        {
            List<FileMeta> lst = new List<FileMeta>();
            try
            {
                string[] fileNames = System.IO.Directory.GetFiles(sPath, "*.*", SearchOption.AllDirectories);
                foreach (var fileName in fileNames)
                {
                    if (System.IO.Path.GetExtension(fileName).ToUpper() == ".MSG")
                    {
                        FileMeta item = new FileMeta(sPath);
                        item.FullName = fileName;
                        item.DLastWriteTime = System.IO.File.GetLastWriteTime(fileName);
                        lst.Add(item);
                    }
                }
            } 
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thong bao", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return lst;
        }
        public static List<FileMeta> GetFileMsgFromTo(string sPath, DateTime? fromDate, DateTime? toDate)
        {
            List<FileMeta> lst = GetFileMsg(sPath);
            List<FileMeta> lstResult = new List<FileMeta>();
            if (fromDate == null)
            {
                if (toDate == null)
                {
                    return lst;
                }
                else
                {
                    var toDate1 = toDate.GetValueOrDefault(DateTime.Now);
                    foreach (var item in lst)
                    {
                        if (item.DLastWriteTime < toDate1)
                            lstResult.Add(item);
                    }
                    return lstResult;
                }
            }
            else
            {
                if (toDate == null)
                {
                    var fromDate1 = fromDate.GetValueOrDefault(DateTime.MinValue);
                    foreach (var item in lst)
                    {
                        if (item.DLastWriteTime > fromDate1)
                            lstResult.Add(item);
                    }
                    return lstResult;
                }
                else
                {
                    var toDate1 = toDate.GetValueOrDefault(DateTime.Now);
                    var fromDate1 = fromDate.GetValueOrDefault(DateTime.MinValue);
                    foreach (var item in lst)
                    {
                        if (item.DLastWriteTime > fromDate1 && item.DLastWriteTime < toDate1)
                            lstResult.Add(item);
                    }
                    return lstResult;
                }
            }
        }
    }
}
