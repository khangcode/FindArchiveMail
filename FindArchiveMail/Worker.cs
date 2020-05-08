using Lucene.Net.Documents;
using Lucene.Net.Index;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindArchiveMail
{

    public static class MailEx
    {
        public static string EmptyIfNullEx(this string value)
        {
            if (value == null)
                return string.Empty;
            return value;
        }
        public static DateTime GetDSentOnEx(this MsgReader.Outlook.Storage.Message msg)
        {
            if (msg == null) return DateTime.MinValue;
            if (msg.SentOn != null) //msg.Type == MsgReader.Outlook.MessageType.Email
            {
                return msg.SentOn.GetValueOrDefault(DateTime.MinValue);
            }
            else //msg.Type == MsgReader.Outlook.MessageType.EmailNonDeliveryReport
            {
                return msg.CreationTime.GetValueOrDefault(DateTime.MinValue);
            }
        }
        public static string GetSentOnEx(this MsgReader.Outlook.Storage.Message msg)
        {
            DateTime date = msg.GetDSentOnEx();
            return DateTools.DateToString(date, DateTools.Resolution.MINUTE);
        }
        public static DateTime GetDReceivedOnEx(this MsgReader.Outlook.Storage.Message msg)
        {
            if (msg == null) return DateTime.MinValue;
            if (msg.ReceivedOn != null) //msg.Type == MsgReader.Outlook.MessageType.Email
            {
                return msg.ReceivedOn.GetValueOrDefault(DateTime.MinValue);
            }
            else //msg.Type == MsgReader.Outlook.MessageType.EmailNonDeliveryReport
            {
                return msg.LastModificationTime.GetValueOrDefault(DateTime.MinValue);
            }
        }
        public static string GetReceivedOnEx(this MsgReader.Outlook.Storage.Message msg)
        {
            DateTime date = msg.GetDReceivedOnEx();
            return DateTools.DateToString(date, DateTools.Resolution.MINUTE);
        }

        public static string GetEmailToEx(this MsgReader.Outlook.Storage.Message msg)
        {
            return msg.GetEmailRecipients(MsgReader.Outlook.RecipientType.To, true, false).EmptyIfNullEx();
        }
        public static string GetEmailCcEx(this MsgReader.Outlook.Storage.Message msg)
        {
            return msg.GetEmailRecipients(MsgReader.Outlook.RecipientType.To, true, false).EmptyIfNullEx();
        }
        public static string GetCategoryEx(this MsgReader.Outlook.Storage.Message msg)
        {
            if (msg.Categories == null) return string.Empty;

            StringBuilder sb = new StringBuilder();
            foreach (var item in msg.Categories)
            {
                sb.Append(item);
                sb.Append(" ");
            }
            return sb.ToString().EmptyIfNullEx();
        }
        public static string GetFlagEx(this MsgReader.Outlook.Storage.Message msg)
        {
            if (msg.Flag == null) return string.Empty;
            return msg.Flag.Request.EmptyIfNullEx();
        }
        public static string GetImportanceEx(this MsgReader.Outlook.Storage.Message msg)
        {
            if (msg.ImportanceText == null) return string.Empty;
            return msg.ImportanceText.EmptyIfNullEx();
        }
    }
    
    public class Worker
    {
        public volatile Lucene.Net.Index.IndexWriter Writer;
        public volatile System.Collections.Concurrent.ConcurrentStack<string> ConStackLog;
        public Worker() { }
        public void DoWork(object obj) //chay Parallel.ForEach
        {
            if (obj == null) return;
            FileMeta fileMeta = (FileMeta)obj;
            if (string.IsNullOrEmpty(fileMeta.FullName)) return;

            string sPath = MyConfig.GetMailFolder();

            try
            {
                using (var msg = new MsgReader.Outlook.Storage.Message(fileMeta.FullName))
                {
                    //msg.Type == MsgReader.Outlook.MessageType.Email
                    //msg.Type == MsgReader.Outlook.MessageType.AppointmentRequest
                    //msg.Type == MsgReader.Outlook.MessageType.EmailNonDeliveryReport
                    // etc
                    Document doc = new Document();

                    doc.Add(new Field("SentOn", msg.GetSentOnEx(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                    doc.Add(new Field("ReceivedOn", msg.GetReceivedOnEx(), Field.Store.YES, Field.Index.NOT_ANALYZED));

                    doc.Add(new Field("Subject", msg.Subject.EmptyIfNullEx(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("Body", msg.BodyText.EmptyIfNullEx(), Field.Store.YES, Field.Index.ANALYZED));

                    doc.Add(new Field("SenderEmailAddress", msg.Sender.Email.EmptyIfNullEx(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("SenderName", msg.Sender.DisplayName.EmptyIfNullEx(), Field.Store.YES, Field.Index.ANALYZED));

                    doc.Add(new Field("To", msg.GetEmailToEx(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("CC", msg.GetEmailCcEx(), Field.Store.YES, Field.Index.ANALYZED));

                    doc.Add(new Field("Categories", msg.GetCategoryEx(), Field.Store.YES, Field.Index.ANALYZED));

                    doc.Add(new Field("FlagRequest", msg.GetFlagEx(), Field.Store.YES, Field.Index.NOT_ANALYZED));

                    doc.Add(new Field("Importance", msg.GetImportanceEx(), Field.Store.YES, Field.Index.NOT_ANALYZED));

                    doc.Add(new Field("AttachmentNames", msg.GetAttachmentNames().EmptyIfNullEx(), Field.Store.YES, Field.Index.ANALYZED));

                    doc.Add(new Field("FullFileName", fileMeta.FileNameWithoutPath, Field.Store.YES, Field.Index.NOT_ANALYZED));
                    doc.Add(new Field("LastWriteTime", fileMeta.LastWriteTime, Field.Store.YES, Field.Index.NOT_ANALYZED));

                    Writer.AddDocument(doc);
                  //  ConStackLog.Push(msg.Subject);
                }
            }
            catch (Exception ex)
            {
                ConStackLog.Push(ex.Message + "|" + fileMeta.FullName);
            }
        }

        public void DeleteAllDocuments()
        {
            Writer.DeleteAll();
        }
        public void SetRAMBufferSizeMB()
        {
            Writer.SetRAMBufferSizeMB(64.0);
        }
        public void DisposeWriter()
        {
            Writer.Optimize();
            //Writer.Commit();
            Writer.Dispose();
        }
    }

    public class WorkerThread
    {
        public volatile ConcurrentStack<string> ErrLog = new ConcurrentStack<string>();
        public WorkerThreadResult RunMT(bW1Arg arg)
        {
            WorkerThreadResult result = new WorkerThreadResult();
            
            string indexPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "LuceneData");
            Lucene.Net.Store.Directory directory = Lucene.Net.Store.FSDirectory.Open(indexPath);
            Lucene.Net.Analysis.Standard.StandardAnalyzer analyzer = new Lucene.Net.Analysis.Standard.StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);

            Worker workerObject = new Worker();
            workerObject.Writer = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED);
            workerObject.ConStackLog = ErrLog;
            workerObject.SetRAMBufferSizeMB();

            List<FileMeta> LstMsgFile = MyIO.GetFileMsgFromTo(MyConfig.GetMailFolder(), arg.DFrom, arg.DTo);
            
            if (arg.IsReIndex)
                { workerObject.DeleteAllDocuments(); }
            else
            {
                //Xoa bo nhung item trung lap giua list moi tao va du lieu da index
                using (Lucene.Net.Search.IndexSearcher searcher = new Lucene.Net.Search.IndexSearcher(directory))
                {
                    for (int i = LstMsgFile.Count - 1; i >= 0; i--)
                    {
                        if (MyLucene.CheckDocExist(searcher, LstMsgFile[i]))
                        {
                            LstMsgFile.RemoveAt(i);
                            result.IncreaseNumDupFiles();
                        }
                    }
                }
            }

            //Chay song song
            ParallelLoopResult pResult = Parallel.ForEach(LstMsgFile, (currentFileMeta) => workerObject.DoWork(currentFileMeta));
            
            StringBuilder sb = new StringBuilder();
            if (pResult.IsCompleted)
            {
                workerObject.DisposeWriter();
                analyzer.Dispose();
                directory.Dispose();

                result.FileDone = LstMsgFile;

                int i = 0;
                foreach (var a in ErrLog)
                {
                    string item;
                    ErrLog.TryPop(out item);
                    i++;
                    sb.Append(i.ToString());
                    sb.Append(". ");
                    sb.Append(item);
                    sb.Append(Environment.NewLine);
                }
                result.ErrLog = sb.ToString();
            }
            return result;
        }
    }

    public class WorkerThreadResult
    {
        public WorkerThreadResult() { }
        public string ErrLog;
        public List<FileMeta> FileDone;
        public int NumDupFiles;
        public void IncreaseNumDupFiles()
        {
            NumDupFiles++;
        }
    }
}