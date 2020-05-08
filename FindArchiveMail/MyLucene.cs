using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace FindArchiveMail
{
    public static class MyLucene
    {
        public static Directory GetDirectory()
        {
            string indexPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "LuceneData");
            return FSDirectory.Open(indexPath);
        }
        public static StandardAnalyzer GetAnalyzer()
        {
            return new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
        }
        public static bool CheckDocExist(IndexSearcher searcher, FileMeta fileMeta)
        {
            TopDocs top = null;
            try
            {
                Query query1 = new TermQuery(new Term("FullFileName", fileMeta.FileNameWithoutPath));
                Query query2 = new TermQuery(new Term("LastWriteTime", fileMeta.LastWriteTime));
                BooleanQuery query3 = new BooleanQuery();
                query3.Add(query1, Occur.MUST);
                query3.Add(query2, Occur.MUST);
                top = searcher.Search(query3, 1);
            }
            catch (Exception)
            {
                return false;
            }
            if (top.TotalHits == 0) return false;
            return true;
        }
                
        public static Query GetTextQuery(string sField, string sValue, Analyzer analyzer)
        {
            Query query = null;
            try
            {
                QueryParser parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, sField, analyzer);
                query = parser.Parse(sValue);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Can not parse: " + sValue);
            }
            return query;
        }
        public static IndexSearcher GetSearcher()
        {
            return new IndexSearcher(GetDirectory());
        }
        public static List<MailData> Search(IndexSearcher searcher, Query query, int maxResult)
        {
            List<MailData> results = new List<MailData>();

            ScoreDoc[] hitsFound = searcher.Search(query, maxResult).ScoreDocs;
            MailData mail = null;

            foreach (var hit in hitsFound)
            {
                mail = new MailData();
                Document doc = searcher.Doc(hit.Doc);

                mail.SentOn = doc.Get("SentOn");
                mail.ReceivedOn = doc.Get("ReceivedOn");
                mail.Subject = doc.Get("Subject");
                mail.Body = doc.Get("Body");
                mail.SenderEmailAddress = doc.Get("SenderEmailAddress");
                mail.SenderName = doc.Get("SenderName");
                mail.To = doc.Get("To");
                mail.CC = doc.Get("CC");
                mail.Categories = doc.Get("Categories");
                mail.FlagRequest = doc.Get("FlagRequest");
                mail.Importance = doc.Get("Importance");
                mail.AttachmentNames = doc.Get("AttachmentNames");
                mail.FullFileName = doc.Get("FullFileName");
                mail.LastWriteTime = doc.Get("LastWriteTime");

                float score = hit.Score;
                mail.Score = score;
                mail.ScoreDocDoc = hit.Doc; //vi tri co the xoa document (IndexReader)

                results.Add(mail);
            }
            return results;
        }
    }
}