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
    public class Worker2
    {
        public volatile Lucene.Net.Index.IndexWriter Writer;
        public volatile Stack<string> ConStackLog;
        private static object _lockObject = new object();
        public Worker2() { }
        public void DoWork(object obj) //chay Parallel.ForEach
        {
            if (obj == null) return;
            List<FileMeta> LstfileMeta = (List<FileMeta>)obj;
            if (LstfileMeta.Count == 0) return;

            string sPath = MyConfig.GetMailFolder();

            foreach (var fileMeta in LstfileMeta)
            {
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
                    }
                }
                catch (Exception ex)
                {
                    lock (_lockObject)
                    {
                        ConStackLog.Push(ex.Message + "|" + fileMeta.FullName);
                    }
                }
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
    public class WorkerThread2
    {
        public volatile Stack<string> ErrLog = new Stack<string>();
        public WorkerThreadResult RunMT(List<FileMeta> LstMsgFile, bool IsReIndex)
        {
            WorkerThreadResult result = new WorkerThreadResult();

            string indexPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "LuceneData");
            Lucene.Net.Store.Directory directory = Lucene.Net.Store.FSDirectory.Open(indexPath);
            Lucene.Net.Analysis.Standard.StandardAnalyzer analyzer = new Lucene.Net.Analysis.Standard.StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);

            Worker2 workerObject = new Worker2();
            workerObject.Writer = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED);
            workerObject.ConStackLog = ErrLog;
            workerObject.SetRAMBufferSizeMB();

            if (IsReIndex)
                workerObject.DeleteAllDocuments();
            else
            {
                //Xoa bo nhung item trung lap giua list moi tao va du lieu da index
                using (Lucene.Net.Search.IndexSearcher searcher = new Lucene.Net.Search.IndexSearcher(directory))
                {
                    for (int idx2 = LstMsgFile.Count - 1; idx2 >= 0; idx2--)
                    {
                        if (MyLucene.CheckDocExist(searcher, LstMsgFile[idx2]))
                        {
                            LstMsgFile.RemoveAt(idx2);
                            result.IncreaseNumDupFiles();
                        }
                    }
                }
            }
            //Chia list thanh cac list con
            int chunkSize = 200;
            int maxThread = 25;
            
            int totalItem = LstMsgFile.Count;
            int numThread = totalItem / chunkSize;
            if (numThread > maxThread)
            {
                numThread = maxThread;
                chunkSize = totalItem / maxThread;
            }
            if (totalItem % chunkSize != 0)
                numThread++;

            List <List<FileMeta>> lst1 = new List<List<FileMeta>>();
            for (int idx = 0; idx <totalItem; idx++)
            {
                int iMin = idx * chunkSize;
                int iMax = iMin + chunkSize;
                if (iMax > totalItem)
                    iMax = totalItem;
                List<FileMeta> lst2 = new List<FileMeta>();
                for (int j = iMin; j < iMax; j++)
                {
                    lst2.Add(LstMsgFile[j]);
                }
                if (lst2.Count != 0)
                    lst1.Add(lst2);
            }

            //Chay song song
            List<Thread> lstTask = new List<Thread>();
            foreach(var item in lst1)
            {
                Thread thread = new Thread(workerObject.DoWork);
                thread.Start(item);
                lstTask.Add(thread);
            }
            
            //Cho cho den khi cac thread chay xong moi chay tiep
            foreach(var th in lstTask)
            {
                th.Join();
            }
            
            //Luu du lieu
            workerObject.DisposeWriter();
            analyzer.Dispose();
            directory.Dispose();

            result.FileDone = LstMsgFile;

            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < ErrLog.Count; i++)
            {
                string item = ErrLog.Pop();
                sb.Append((i+1).ToString());
                sb.Append(". ");
                sb.Append(item);
                sb.Append(Environment.NewLine);
            }
            result.ErrLog = sb.ToString();
            return result;
        }
    }
}