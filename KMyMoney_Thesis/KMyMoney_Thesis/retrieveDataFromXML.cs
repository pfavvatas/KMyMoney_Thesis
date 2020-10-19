using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
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
        /// </summary
        public ObservableCollection<Tag> TagListCollection { get; set; }
        public ObservableCollection<Tag> GetTags()
        {
            ReadTheFile();

            XmlDocument doc = new XmlDocument();
            doc.Load(new StringReader(data));
            XmlNodeList tagNodes = doc.DocumentElement.SelectNodes("/KMYMONEY-FILE/TAGS/TAG");
            List<Tag> tagList = new List<Tag>();
            TagListCollection = new ObservableCollection<Tag>();
            foreach (XmlNode tagNode in tagNodes)
            {
                Tag tag = new Tag();
                tag.Tagcolor = tagNode.Attributes["tagcolor"] == null ? "" : tagNode.Attributes["tagcolor"].Value;
                tag.Notes = tagNode.Attributes["notes"] == null ? "" : tagNode.Attributes["notes"].Value;
                tag.Id = tagNode.Attributes["id"] == null ? "" : tagNode.Attributes["id"].Value;
                tag.Closed = tagNode.Attributes["closed"] == null ? "" : tagNode.Attributes["closed"].Value;
                tag.Name = tagNode.Attributes["name"] == null ? "" : tagNode.Attributes["name"].Value;
                TagListCollection.Add(tag);
            }
            return TagListCollection;

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
            System.Console.WriteLine(doc.InnerXml);

            UpdateTheFile(doc.InnerXml);
        }

        public void AddNewTag(String name)
        {
            ReadTheFile();
            XmlDocument doc = new XmlDocument();
            doc.Load(new StringReader(data));

            XmlNodeList findNodes = doc.SelectNodes("//TAGS/TAG");

            //Create new Tag
            XmlNode newTag = doc.CreateNode(XmlNodeType.Element, "TAG", null);

            XmlAttribute newTagName = doc.CreateAttribute("name");
            XmlAttribute newTagId = doc.CreateAttribute("id");
            XmlAttribute newTagColor = doc.CreateAttribute("tagcolor");
            XmlAttribute newTagClosed = doc.CreateAttribute("closed");
            XmlAttribute newTagNotes = doc.CreateAttribute("notes");

            newTagName.Value = name;
            newTagId.Value = String.Format("G{0:000000}", int.Parse(findNodes[findNodes.Count - 1].Attributes["id"].Value.Replace("G", "0")) + 1); //Create the Id format.
            newTagColor.Value = "#000000";
            newTagClosed.Value = "0";
            newTagNotes.Value = "";

            newTag.Attributes.Append(newTagName);
            newTag.Attributes.Append(newTagId);
            newTag.Attributes.Append(newTagColor);
            newTag.Attributes.Append(newTagClosed);
            newTag.Attributes.Append(newTagNotes);

            XmlNode toAdd = doc.SelectSingleNode("//TAGS");
            toAdd.AppendChild(newTag);
            UpdateTheFile(doc.InnerXml);
        }

        public void UpdateTag(Tag tag)
        {
            ReadTheFile();
            XmlDocument doc = new XmlDocument();
            doc.Load(new StringReader(data));

            XmlNode updateNode = doc.SelectSingleNode("//TAGS/TAG[@id='" + tag.Id + "']");
            updateNode.Attributes["name"].Value = tag.Name;
            if (updateNode.Attributes["notes"] != null)
            {
                updateNode.Attributes["notes"].Value = tag.Notes;
            }
            else if (tag.Notes != null)
            {
                XmlAttribute newTagNotes = doc.CreateAttribute("notes");
                newTagNotes.Value = tag.Notes;
                updateNode.Attributes.Append(newTagNotes);
            }
            updateNode.Attributes["closed"].Value = tag.Closed;

            UpdateTheFile(doc.InnerXml);
        }

        public ObservableCollection<Payee> PayeesObs { get; set; }
        public ObservableCollection<Payee> GetPayees()
        {
            ReadTheFile();
            XmlDocument doc = new XmlDocument();
            doc.Load(new StringReader(data));

            XmlNodeList payeeNodes = doc.DocumentElement.SelectNodes("/KMYMONEY-FILE/PAYEES/PAYEE");
            List<Payee> payeeList = new List<Payee>();
            PayeesObs = new ObservableCollection<Payee>();
            foreach (XmlNode payeeNode in payeeNodes)
            {
                Payee payee = new Payee();
                payee.Id = payeeNode.Attributes["id"] == null ? "" : payeeNode.Attributes["id"].Value;
                payee.Name = payeeNode.Attributes["name"] == null ? "" : payeeNode.Attributes["name"].Value;
                payee.Matchingenabled = payeeNode.Attributes["matchingenabled"] == null ? "" : payeeNode.Attributes["matchingenabled"].Value;
                payee.Email = payeeNode.Attributes["email"] == null ? "" : payeeNode.Attributes["email"].Value;
                payee.Reference = payeeNode.Attributes["reference"] == null ? "" : payeeNode.Attributes["reference"].Value;
                payee.Notes = payeeNode.Attributes["notes"] == null ? "" : payeeNode.Attributes["notes"].Value;
                payee.AddressInfo = GetAddress(payeeNode);
                PayeesObs.Add(payee);
            }
            return PayeesObs;
        }

        public void DeletePayee(string id,string newid)
        {
            ReadTheFile();

            XmlDocument doc = new XmlDocument();
            doc.Load(new StringReader(data));

            XmlNodeList deleteNodes = doc.SelectNodes("//PAYEE[@id='" + id + "']");
            foreach (XmlNode deleteNode in deleteNodes)
            {
                deleteNode.ParentNode.RemoveChild(deleteNode);
            }
            
            //Set new Payee 
            XmlNodeList xnList = doc.SelectNodes("//SCHEDULES/SCHEDULED_TX/TRANSACTION/SPLITS/SPLIT[@payee='P000001']");
            foreach (XmlNode xn in xnList)
            {
                xn.Attributes["payee"].Value = newid;
                //Console.WriteLine("//SCHEDULES/SCHEDULED_TX/TRANSACTION/SPLITS/SPLIT[@payee='P000001'] = ", xn.InnerText);
            }
            XmlNodeList xnList2 = doc.SelectNodes("//TRANSACTIONS/TRANSACTION/SPLITS/SPLIT[@payee='P000001']");
            foreach (XmlNode xn in xnList2)
            {
                xn.Attributes["payee"].Value = newid;
                //Console.WriteLine("//TRANSACTIONS/TRANSACTION/SPLITS/SPLIT[@payee='P000001'] = ", xn.InnerText);
            }

            System.Console.WriteLine(doc.InnerXml);
            UpdateTheFile(doc.InnerXml);
        }

        public void UpdatePayee(Tag tag)
        {
            //ReadTheFile();
            //XmlDocument doc = new XmlDocument();
            //doc.Load(new StringReader(data));

            //XmlNode updateNode = doc.SelectSingleNode("//PAYESS/PAYEE[@id='" + tag.Id + "']");
            //updateNode.Attributes["name"].Value = tag.Name;
            //if (updateNode.Attributes["notes"] != null)
            //{
            //    updateNode.Attributes["notes"].Value = tag.Notes;
            //}
            //else if (tag.Notes != null)
            //{
            //    XmlAttribute newTagNotes = doc.CreateAttribute("notes");
            //    newTagNotes.Value = tag.Notes;
            //    updateNode.Attributes.Append(newTagNotes);
            //}
            //updateNode.Attributes["closed"].Value = tag.Closed;

            //UpdateTheFile(doc.InnerXml);
        }

        public Address GetAddress(XmlNode node)
        {
            Address address = new Address();
            XmlNode addressNode = node.SelectSingleNode("ADDRESS");
            address.Street = addressNode.Attributes["street"] == null ? "" : addressNode.Attributes["street"].Value;
            address.Telephone = addressNode.Attributes["telephone"] == null ? "" : addressNode.Attributes["telephone"].Value;
            address.Country = addressNode.Attributes["country"] == null ? "" : addressNode.Attributes["country"].Value;
            address.City = addressNode.Attributes["city"] == null ? "" : addressNode.Attributes["city"].Value;
            address.Zip = addressNode.Attributes["zip"] == null ? "" : addressNode.Attributes["zip"].Value;
            address.Zipcode = addressNode.Attributes["zipcode"] == null ? "" : addressNode.Attributes["zipcode"].Value;
            address.Postcode = addressNode.Attributes["postcode"] == null ? "" : addressNode.Attributes["postcode"].Value;
            address.State = addressNode.Attributes["state"] == null ? "" : addressNode.Attributes["state"].Value;
            return address;
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

                        txt += " " + GetTagName(doc, test3.Id);
                    }
                }
                _transaction.Details = txt;
                //
                TransactionsObs.Add(_transaction);
            }
            return TransactionsObs;

        }



        public string GetTagName(XmlDocument doc, string Id)
        {
            XmlNodeList tagNodes = doc.DocumentElement.SelectNodes("/KMYMONEY-FILE/TAGS/TAG");
            foreach (XmlNode tagNode in tagNodes)
            {
                if (tagNode.Attributes["id"].Value == Id)
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
