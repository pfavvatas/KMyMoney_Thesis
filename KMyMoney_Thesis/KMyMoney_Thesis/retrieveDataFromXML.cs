using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using KMyMoney_Thesis.Model;
using Xamarin.Forms;

namespace KMyMoney_Thesis
{
    public class retrieveDataFromXML
    {
        private String fileName = "MyFileXML.txt";
        private string data;
        public retrieveDataFromXML()
        {
            System.Console.WriteLine("mpike kai edw gia na kseroume.......");
        }

        private void ReadTheFile()
        {
            //Read Loal File dat using DependencyService  
            string data = DependencyService.Get<IFileReadWrite>().ReadData(fileName);
            this.data = data;
        }

        public Tag _tag { get; set; }
        public ObservableCollection<Tag> TagsObs { get; set; }
        public ObservableCollection<Tag> GetTags()
        {
            ReadTheFile();
            XmlDocument doc = new XmlDocument();
            doc.Load(new StringReader(data));

            XmlNodeList tagNodes = doc.DocumentElement.SelectNodes("/KMYMONEY-FILE/TAGS/TAG");
            List<Tag> tagList = new List<Tag>();
            TagsObs = new ObservableCollection<Tag>();
            foreach (XmlNode tagNode in tagNodes)
            {
                Tag tag = new Tag();
                tag.Tagcolor = tagNode.Attributes["tagcolor"].Value;
                tag.Notes = tagNode.Attributes["notes"] == null ? "" : tagNode.Attributes["notes"].Value;
                tag.Id = tagNode.Attributes["id"].Value;
                tag.Closed = tagNode.Attributes["closed"].Value;
                tag.Name = tagNode.Attributes["name"].Value;
                //tagList.Add(tag);
                TagsObs.Add(tag);
            }
            return TagsObs;
        }

        public ObservableCollection<Transaction> TransactionsObs { get; set; }
        public ObservableCollection<Transaction> GetTransactions()
        {
            ReadTheFile();
            XmlDocument doc = new XmlDocument();
            doc.Load(new StringReader(data));

            XmlNodeList transactionNodes = doc.DocumentElement.SelectNodes("/KMYMONEY-FILE/TRANSACTIONS/TRANSACTION");
            TransactionsObs = new ObservableCollection<Transaction>();
            foreach (XmlNode transactionNode in transactionNodes)
            {
                Transaction _transaction = new Transaction();
                _transaction.Id = transactionNode.Attributes["id"].Value;

                //Console.WriteLine("postdate= " + transactionNode.Attributes["postdate"].Value);
                //Console.WriteLine("commodity= " + transactionNode.Attributes["commodity"].Value);
                //Console.WriteLine("memo= " + transactionNode.Attributes["memo"].Value);
                //Console.WriteLine("id= " + transactionNode.Attributes["id"].Value);
                //Console.WriteLine("entrydate= " + transactionNode.Attributes["entrydate"].Value);

                ////SPLITS
                XmlNodeList splitNodes = transactionNode.SelectNodes("SPLITS/SPLIT");
                List<Split> splitLists = new List<Split>();
                foreach (XmlNode splitNode in splitNodes)
                {
                    Split _split = new Split();
                    _split.Id = splitNode.Attributes["id"].Value;
                    //_transaction.Splits.Add(_split);
                    //Console.Write("  - payee = " + splitNode.Attributes["payee"].Value);
                    //Console.WriteLine(" ,reconcileflag = " + splitNode.Attributes["reconcileflag"].Value);
                    //Console.WriteLine(" ,shares = " + splitNode.Attributes["shares"].Value);
                    //Console.WriteLine(" ,reconciledate = " + splitNode.Attributes["reconciledate"].Value);
                    //Console.WriteLine(" ,action = " + splitNode.Attributes["action"].Value);
                    //Console.WriteLine(" ,bankid = " + splitNode.Attributes["bankid"].Value);
                    //Console.WriteLine(" ,account = " + splitNode.Attributes["account"].Value);
                    //Console.WriteLine(" ,number = " + splitNode.Attributes["number"].Value);
                    //Console.WriteLine(" ,value = " + splitNode.Attributes["value"].Value);
                    //Console.WriteLine(" ,memo = " + splitNode.Attributes["memo"].Value);
                    //Console.WriteLine(" ,id = " + splitNode.Attributes["id"].Value);
                    List<Tag> tagLists = new List<Tag>();
                    try
                    {
                        //Tag into Split
                        XmlNodeList SplitTagNodes = splitNode.SelectNodes("TAG");
                        foreach (XmlNode SplitTagNode in SplitTagNodes)
                        {
                            Tag _tag = new Tag();
                            _tag.Id = SplitTagNode.Attributes["id"].Value;
                            tagLists.Add(_tag);
                            //Console.WriteLine(" TAG ID => " + SplitTagNode.Attributes["id"].Value);
                        }
                        //End
                    }
                    catch (Exception tagException)
                    {
                        System.Diagnostics.Debug.WriteLine("Tag Exception: " + tagException);
                    }
                    _split.Tag = tagLists;
                    splitLists.Add(_split);

                }
                _transaction.Splits = splitLists;
                TransactionsObs.Add(_transaction);
            }
            return TransactionsObs;

        }
    }
}
