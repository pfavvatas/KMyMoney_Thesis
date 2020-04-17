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
        }

        private void ReadTheFile()
        {
            //Read Local File dat using DependencyService  
            string data = DependencyService.Get<IFileReadWrite>().ReadData(fileName);
            this.data = data;
        }

        private void UpdateTheFile(string data)
        {
            DependencyService.Get<IFileReadWrite>().WriteData(fileName, data);
        }
      
        /// <summary>
        /// Calling GetTags(), we're getting all details about tags we'd like to
        /// show to application.
        /// And we return an ObservableCollection<Tag>.
        /// </summary>
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
                TagsObs.Add(tag);
            }
            return TagsObs;
        }

        public ObservableCollection<Tag> TagsAfterDelete { get; set; }
        public void DeleteTag(string id)
        {
            ReadTheFile();
            XmlDocument doc = new XmlDocument();
            doc.Load(new StringReader(data));

            XmlNodeList deleteNodes = doc.SelectNodes("//TAG[@id='" + id + "']");
            foreach (XmlNode deleteNode in deleteNodes)
            {
                deleteNode.ParentNode.RemoveChild(deleteNode);
            }

            UpdateTheFile(doc.InnerXml);
            //return GetTags();
            
        }


        /// <summary>
        /// Calling GetTransactions(), we're retrieving all transactions.
        /// Also we return an ObservableCollection<Transaction>.
        /// </summary>
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
                _transaction.Postdate = transactionNode.Attributes["postdate"].Value;
                _transaction.Commodity = transactionNode.Attributes["commodity"].Value;
                _transaction.Memo = transactionNode.Attributes["memo"].Value;
                _transaction.Entrydate = transactionNode.Attributes["entrydate"].Value;

                ////SPLITS
                XmlNodeList splitNodes = transactionNode.SelectNodes("SPLITS/SPLIT");
                List<Split> splitLists = new List<Split>();
                foreach (XmlNode splitNode in splitNodes)
                {
                    Split _split = new Split();
                    _split.Id = splitNode.Attributes["id"].Value;
                    _split.Payee = splitNode.Attributes["payee"].Value;
                    _split.Reconcileflag = splitNode.Attributes["reconcileflag"].Value;
                    _split.Shares = splitNode.Attributes["shares"].Value;
                    _split.Reconciledate = splitNode.Attributes["reconciledate"].Value;
                    _split.Action = splitNode.Attributes["action"].Value;
                    _split.Bankid = splitNode.Attributes["bankid"].Value;
                    _split.Account = splitNode.Attributes["account"].Value;
                    _split.Number = splitNode.Attributes["number"].Value;
                    _split.Value = splitNode.Attributes["value"].Value;
                    _split.Memo = splitNode.Attributes["memo"].Value;
                    _split.AccountName = GetAccountName(doc, _split.Account);
                                       
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
                // Fill Details from tag ids and searching to tags, to retrieve the names of each id
                    string txt = "";
                    foreach (Split test2 in _transaction.Splits)
                    {
                        foreach (Tag test3 in test2.Tag)
                        {
                            //  Search with this Id the tags and return the name.
                            
                            txt += " " + GetTagName(doc,test3.Id);
                        }
                    }
                _transaction.Details = txt;
                //
                TransactionsObs.Add(_transaction);
            }
            return TransactionsObs;

        }



        public string GetTagName(XmlDocument doc,string Id)
        {
            XmlNodeList tagNodes = doc.DocumentElement.SelectNodes("/KMYMONEY-FILE/TAGS/TAG");
            foreach (XmlNode tagNode in tagNodes)
            {
                if(tagNode.Attributes["id"].Value == Id)
                {
                    return tagNode.Attributes["name"].Value;
                }
            }
            return "noname:(";
        }

        public string GetAccountName(XmlDocument doc, string Id)
        {
            XmlNodeList accountNodes = doc.DocumentElement.SelectNodes("/KMYMONEY-FILE/ACCOUNTS/ACCOUNT");
            foreach (XmlNode accountNode in accountNodes)
            {
                if (accountNode.Attributes["id"].Value == Id)
                {
                    return accountNode.Attributes["name"].Value;
                }
            }
            return "noname:(";
        }
    }
}
