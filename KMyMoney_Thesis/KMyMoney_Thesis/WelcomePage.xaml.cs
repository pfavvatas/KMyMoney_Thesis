using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Diagnostics;
using KMyMoney_Thesis.Views;

using Plugin.FilePicker;

using System.IO;
using Xamarin.Essentials;
using System.Xml;
using System.Xml.Serialization;
using KMyMoney_Thesis.Model;
using SQLite;
using System.Xml.Linq;


using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace KMyMoney_Thesis
{
   

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public string myProperty { set; get; }

        public WelcomePage()
        {
            InitializeComponent();
            //Post post = new Post()
            //{
            //    Test1 = DateTime.Now + "\n"
            //};

            

            //SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            //conn.CreateTable<Post>();
            //var i = conn.Insert(post);
            //if (i > 0)
            //{
            //    System.Diagnostics.Debug.WriteLine("mpikan dedomena");

            //}
            //else
            //{
            //    System.Diagnostics.Debug.WriteLine("den mpikan dedomena");

            //}
            //var testd = conn.Table<Post>().ToList();
            //conn.Close();

            //String datatxt = "";
            //foreach (var t in testd)
            //{
            //    System.Diagnostics.Debug.WriteLine("DATA => "+t.Test1);
            //    datatxt += t.Test1;
            //}
            //msg1.Text = datatxt;
            //msg1.Text += testd.ToArray();
            //if (!Application.Current.Properties.ContainsKey("database"))
            //{
            //    try
            //    {
            //        string s = "empty...";
            //        msg1.Text = s;

            //    }
            //    catch (Exception e)
            //    {
            //        msg1.Text = e+"";
            //        System.Diagnostics.Debug.WriteLine(e);
            //    }
            //}
            //else
            //{
            //    string text = Application.Current.Properties["database"] as string;
            //    //App.kmmdb.Add(new DataStorage.kmymoneyDB(text));
            //    msg1.Text = text;
            //}
            //BindingContext = this;

        }

        

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new NavigationPage(new SetupPage());

            //Application.Current.MainPage = new SetupPage();
            Application.Current.MainPage = new MainPage();
            
        }

        private async void Button_ClickedFile(object sender, EventArgs e)
        {
            
            var file = await CrossFilePicker.Current.PickFile();
            if(file != null)
            {
                string contents = System.Text.Encoding.UTF8.GetString(file.DataArray);
                Application.Current.Properties["database"] = contents;




                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                //try to add contents to a file

                //File name
                string fileName = "MyFileXML.txt";

                //Write data to Loal File using DependencyService  
                DependencyService.Get<IFileReadWrite>().WriteData(fileName, contents);

                //Read Loal File dat using DependencyService  
                //string data = DependencyService.Get<IFileReadWrite>().ReadData("MyFileXML.txt");

                //Print data
                //System.Diagnostics.Debug.WriteLine(data);

                /////////////////////////////////////////////////////////////////////////////////////////////////////////




                //App.kmmdb.Add(new DataStorage.kmymoneyDB(contents));

                //XmlSerializer ser = new XmlSerializer(typeof(KMyMoney_Thesis.DataStorage.KMYMONEYFILE));
                //KMyMoney_Thesis.DataStorage.KMYMONEYFILE ap;
                //XmlReaderSettings settings = new XmlReaderSettings();
                //settings.DtdProcessing = DtdProcessing.Parse;
                //using (var stream1 = new StringReader(contents))
                //using (XmlReader reader1 = XmlReader.Create(stream1, settings))
                //{
                //     ap = ser.Serialize<KMyMoney_Thesis.DataStorage.KMYMONEYFILE>(ap);

                //}

                // Set the validation settings.
                //XmlReaderSettings settings = new XmlReaderSettings();
                //settings.DtdProcessing = DtdProcessing.Parse;
                //XmlSerializer xmlSerializer = new XmlSerializer(typeof(KMyMoney_Thesis.DataStorage.KMYMONEY_FILE));
                //XmlDocument xmlDocument = new XmlDocument();
                //xmlDocument.Load(new StringReader(contents));
                //string xmlString = xmlDocument.OuterXml.ToString();
                //byte[] buffer = ASCIIEncoding.UTF8.GetBytes(xmlString);
                //MemoryStream ms = new MemoryStream(buffer);
                //using(XmlReader reader1 = XmlReader.Create(ms, settings))
                //{
                //    App.kmmf = (KMyMoney_Thesis.DataStorage.KMYMONEY_FILE)xmlSerializer.Deserialize(reader1);
                //}

                //PropertyMapping result = null;
                //List<KMyMoney_Thesis.DataStorage.ACCOUNT> kmm = null;

                //using (var stream1 = new StringReader(contents))
                //{
                //    using (var reader1 = XmlReader.Create(stream1, settings))
                //    {
                //        //System.Diagnostics.Debug.WriteLine(reader1);
                //        XmlSerializer serializer = new XmlSerializer(typeof(List<KMyMoney_Thesis.DataStorage.ACCOUNT>),
                //        new XmlRootAttribute("ACCOUNTS"));

                //        try
                //        {
                //            kmm = (List<KMyMoney_Thesis.DataStorage.ACCOUNT>)serializer.Deserialize(reader1);
                //        } catch (Exception e2)
                //        {
                //            System.Diagnostics.Debug.WriteLine(e2);

                //        }
                //        //result = (PropertyMapping)serializer.Deserialize(reader1);
                //    }
                //}

                //foreach(var i in kmm)
                //{
                //    System.Diagnostics.Debug.WriteLine(i.name);
                //}
                //System.Diagnostics.Debug.WriteLine("KMYMONEY_FILE => " + kmm);


                //SQLite
                SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
                //Account Table
                conn.DropTable<Account>();
                conn.CreateTable<Account>();

                //Institution
                conn.DropTable<Institution>();
                conn.CreateTable<Institution>();

                //Tag
                conn.DropTable<Tag>();
                conn.CreateTable<Tag>();

                //Set the validation settings.
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Parse;
                //settings.ValidationType = ValidationType.DTD;



                // Create the XmlReader object.
                XmlReader reader = XmlReader.Create(new StringReader(contents), settings);

                // Parse the file. 
                //while (reader.Read())
                //{
                //    if (reader.IsStartElement())
                //    {
                //        //System.Diagnostics.Debug.WriteLine(reader.Name.ToString());
                //        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ACCOUNTS"))
                //        {
                //            if (reader.HasAttributes)
                //                System.Diagnostics.Debug.WriteLine("Count= " + reader.GetAttribute("count"));
                //        }

                //        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "INSTITUTION"))
                //        {
                //            if (reader.HasAttributes)
                //            {
                                
                //                //Institution inst = new Institution()
                //                //{
                //                //    Id = reader.GetAttribute("id"),
                //                //    Name = reader.GetAttribute("name")
                //                //};
                //                ////System.Diagnostics.Debug.WriteLine("Institution ID: " + reader.GetAttribute("id"));
                //                //try
                //                //{
                //                //    conn.Insert(inst);
                //                //    //System.Diagnostics.Debug.WriteLine("mpike sti basi");

                //                //}
                //                //catch (SQLiteException sqle)
                //                //{
                //                //    System.Diagnostics.Debug.WriteLine("SQL Exception: " + sqle);

                //                //}

                //            }


                            
                //            //System.Diagnostics.Debug.WriteLine(" next: " + reader);

                //            //if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ACCOUNTID"))
                //            //{
                //            //    System.Diagnostics.Debug.WriteLine("-ACCOUNTS ID : " + reader.GetAttribute("id"));

                //            //}



                //            //System.Diagnostics.Debug.WriteLine("Institution : " + reader);


                //        }

                //        //Get Accounts
                //        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ACCOUNT"))
                //        {
                //            if (reader.HasAttributes)
                //            {
                //                //System.Diagnostics.Debug.WriteLine(reader.GetAttribute("currency") + ": " + reader.GetAttribute("name"));
                //                Account acc = new Account()
                //                {
                //                    Id = reader.GetAttribute("id"),
                //                    Name = reader.GetAttribute("name")
                //                };
                //                //System.Diagnostics.Debug.WriteLine("ID: "+ reader.GetAttribute("id"));
                //                try
                //                {
                //                    conn.Insert(acc);
                //                    //System.Diagnostics.Debug.WriteLine("mpike sti basi");
                                    
                //                }catch(SQLiteException sqle)
                //                {
                //                    System.Diagnostics.Debug.WriteLine("SQL Exception: "+ sqle);

                //                }

                //            }
                //        }
                //    }
                //}


                //test 2
                try
                {

                    //StringBuilder result = new StringBuilder();

                    //XElement xdoc = XElement.Parse(contents);

                    //var KMM_XML = from KMYMONEY_FILE in xdoc.Descendants("KMYMONEY-FILE")
                    //              select new
                    //              {
                    //                  FILEINFO_CREATION_DATE = KMYMONEY_FILE.Element("FILEINFO").Element("CREATION_DATE").Attribute("date").Value,
                    //                  FILEINFO_LAST_MODIFIED_DATE = KMYMONEY_FILE.Element("FILEINFO").Element("LAST_MODIFIED_DATE").Attribute("date").Value,
                    //                  FILEINFO_VERSION = KMYMONEY_FILE.Element("FILEINFO").Element("VERSION").Attribute("id").Value,
                    //                  FILEINFO_FIXVERSION = KMYMONEY_FILE.Element("FILEINFO").Element("FIXVERSION").Attribute("id").Value
                    //              };

                    //foreach (var KMYMONEY_FILE in KMM_XML){
                    //    //result.AppendLine(KMYMONEY_FILE.FILEINFO_CREATION_DATE);
                    //    Console.WriteLine("test...");
                    //}

                    //StringBuilder result = new StringBuilder();
                    //foreach (XElement level1Element in XElement.Load(reader).Elements("INSTITUTION"))
                    //{
                    //    result.AppendLine(level1Element.Attribute("id").Value);
                    //    foreach (XElement level2Element in level1Element.Elements("ACCOUNTID"))
                    //    {
                    //        result.AppendLine("  " + level2Element.Attribute("id").Value);
                    //    }
                    //}
                    //Console.WriteLine(result.ToString());

                    XmlDocument doc = new XmlDocument();
                    doc.Load(new StringReader(contents));

                    //INSTITUTIONS
                    Console.WriteLine("-----INSTITUTIONS-----");
                    XmlNodeList nodes = doc.DocumentElement.SelectNodes("/KMYMONEY-FILE/INSTITUTIONS/INSTITUTION");
                    List<Institution> insts = new List<Institution>();
                    foreach (XmlNode node in nodes)
                    {
                        Institution inst = new Institution();

                        //inst.Id = node.SelectSingleNode("author").InnerText;
                        //inst.Name = node.SelectSingleNode("title").InnerText;
                        inst.Id = node.Attributes["id"].Value;
                        inst.Name = node.Attributes["name"].Value;


                        insts.Add(inst);

                        try
                        {
                            conn.Insert(inst);
                        }
                        catch (SQLiteException sqle)
                        {
                            System.Diagnostics.Debug.WriteLine("SQL Exception: " + sqle);
                        }

                        Console.WriteLine("Id= " + node.Attributes["id"].Value + " ,Name= " + node.Attributes["name"].Value + " ,Manager= " + node.Attributes["manager"].Value + " ,Sortcode= " + node.Attributes["sortcode"].Value);

                        //ADDRESS
                        XmlNodeList addressNodes = node.SelectNodes("ADDRESS");
                        foreach (XmlNode addressNode in addressNodes)
                        {
                            Console.Write("  - street = " + addressNode.Attributes["street"].Value);
                            Console.Write(" ,telephone = " + addressNode.Attributes["telephone"].Value);
                            Console.Write(" ,zip = " + addressNode.Attributes["zip"].Value);
                            Console.WriteLine(" ,city = " + addressNode.Attributes["city"].Value);
                        }

                        //ACCOUNTSIDS
                        XmlNodeList nodesAccountIds = node.SelectNodes("ACCOUNTIDS/ACCOUNTID");
                        foreach (XmlNode accountIdsNode in nodesAccountIds)
                        {
                            Console.WriteLine("  - id = " + accountIdsNode.Attributes["id"].Value);
                        }


                        //KEYVALUEPAIRS
                        XmlNodeList keyValuePairsNodes = node.SelectNodes("KEYVALUEPAIRS/PAIR");
                        foreach (XmlNode keyValuePairsNode in keyValuePairsNodes)
                        {
                            Console.Write("  - key = " + keyValuePairsNode.Attributes["key"].Value);
                            Console.WriteLine(" ,value = " + keyValuePairsNode.Attributes["value"].Value);

                        }


                    }
                    //INSTITUTIONS END



                    //PAYEES
                    Console.WriteLine("-----PAYEES-----");
                    XmlNodeList payeesNodes = doc.DocumentElement.SelectNodes("/KMYMONEY-FILE/PAYEES/PAYEE");
                    foreach (XmlNode payeesNode in payeesNodes)
                    {
                        Console.WriteLine("Id= " + payeesNode.Attributes["id"].Value
                            + " ,Name= " + payeesNode.Attributes["name"].Value
                            + " ,Matchingenabled= " + payeesNode.Attributes["matchingenabled"].Value
                            + " ,Email= " + payeesNode.Attributes["email"].Value + " ,Reference= "
                            + payeesNode.Attributes["reference"].Value);
                    }
                    //PAYEES END


                    //TAGS
                    Console.WriteLine("-----TAGS-----");
                    XmlNodeList tagNodes = doc.DocumentElement.SelectNodes("/KMYMONEY-FILE/TAGS/TAG");
                    List<Tag> tagList = new List<Tag>();
                    foreach (XmlNode tagNode in tagNodes)
                    {
                        Tag tag = new Tag();
                        tag.Tagcolor = tagNode.Attributes["tagcolor"].Value;
                        tag.Notes = tagNode.Attributes["notes"] == null ? "" : tagNode.Attributes["notes"].Value;
                        tag.Id = tagNode.Attributes["id"].Value;
                        tag.Closed = tagNode.Attributes["closed"].Value;
                        tag.Name = tagNode.Attributes["name"].Value;
                        conn.Insert(tag);
                        tagList.Add(tag);
                        Console.WriteLine("tagcolor= " + tagNode.Attributes["tagcolor"].Value
                            + " ,notes= " + tag.Notes
                            + " ,id= " + tagNode.Attributes["id"].Value
                            + " ,closed= " + tagNode.Attributes["closed"].Value
                            + " ,name= " + tagNode.Attributes["name"].Value);
                    }
                    //TAGS END

                    //FILEINFO
                    Console.WriteLine("-----FILEINFO-----");
                    XmlNodeList fileInfoNodes = doc.DocumentElement.SelectNodes("/KMYMONEY-FILE/FILEINFO");
                    foreach (XmlNode fileInfoNode in fileInfoNodes)
                    {
                        Console.WriteLine(fileInfoNode.SelectSingleNode("CREATION_DATE").Attributes["date"].Value);
                        Console.WriteLine(fileInfoNode.SelectSingleNode("LAST_MODIFIED_DATE").Attributes["date"].Value);
                        Console.WriteLine(fileInfoNode.SelectSingleNode("VERSION").Attributes["id"].Value);
                        Console.WriteLine(fileInfoNode.SelectSingleNode("FIXVERSION").Attributes["id"].Value);                        
                    }
                    //FILEINFO END

                    //USER
                    Console.WriteLine("-----USER-----");
                    XmlNodeList userNodes = doc.DocumentElement.SelectNodes("/KMYMONEY-FILE/USER");
                    foreach (XmlNode userNode in userNodes)
                    {
                        Console.WriteLine("email= "+userNode.Attributes["email"].Value);
                        Console.WriteLine("name= " + userNode.Attributes["name"].Value);
                        Console.WriteLine("street= " + userNode.SelectSingleNode("ADDRESS").Attributes["street"].Value);
                        Console.WriteLine("telephone= " + userNode.SelectSingleNode("ADDRESS").Attributes["telephone"].Value);
                        Console.WriteLine("county= " + userNode.SelectSingleNode("ADDRESS").Attributes["county"].Value);
                        Console.WriteLine("city= " + userNode.SelectSingleNode("ADDRESS").Attributes["city"].Value);
                        Console.WriteLine("zipcode= " + userNode.SelectSingleNode("ADDRESS").Attributes["zipcode"].Value);


                    }
                    //USER END

                    //ACCOUNTS
                    Console.WriteLine("-----ACCOUNTS----- results= " + doc.DocumentElement.SelectSingleNode("/KMYMONEY-FILE/ACCOUNTS").Attributes["count"].Value);
                    XmlNodeList accountNodes = doc.DocumentElement.SelectNodes("/KMYMONEY-FILE/ACCOUNTS/ACCOUNT");
                    foreach (XmlNode accountNode in accountNodes)
                    {
                        Console.WriteLine("currency= " + accountNode.Attributes["currency"].Value);
                        Console.WriteLine("description= " + accountNode.Attributes["description"].Value);
                        Console.WriteLine("parentaccount= " + accountNode.Attributes["parentaccount"].Value);
                        Console.WriteLine("opened= " + accountNode.Attributes["opened"].Value);
                        Console.WriteLine("number= " + accountNode.Attributes["number"].Value);
                        Console.WriteLine("lastmodified= " + accountNode.Attributes["lastmodified"].Value);
                        Console.WriteLine("type= " + accountNode.Attributes["type"].Value);
                        Console.WriteLine("id= " + accountNode.Attributes["id"].Value);
                        Console.WriteLine("lastreconciled= " + accountNode.Attributes["lastreconciled"].Value);
                        Console.WriteLine("institution= " + accountNode.Attributes["institution"].Value);
                        Console.WriteLine("name= " + accountNode.Attributes["name"].Value);


                        //SUBACCOUNTS
                        XmlNodeList subaccountNodes = accountNode.SelectNodes("SUBACCOUNTS/SUBACCOUNT");
                        foreach (XmlNode subaccountNode in subaccountNodes)
                        {
                            Console.WriteLine("  - id = " + subaccountNode.Attributes["id"].Value);
                        }


                        //KEYVALUEPAIRS
                        XmlNodeList keyValuePairsNodes = accountNode.SelectNodes("KEYVALUEPAIRS/PAIR");
                        foreach (XmlNode keyValuePairsNode in keyValuePairsNodes)
                        {
                            Console.Write("  - key = " + keyValuePairsNode.Attributes["key"].Value);
                            Console.WriteLine(" ,value = " + keyValuePairsNode.Attributes["value"].Value);

                        }

                    }
                    //ACCOUNTS END

                    //TRANSACTIONS
                    Console.WriteLine("-----TRANSACTIONS----- results= " + doc.DocumentElement.SelectSingleNode("/KMYMONEY-FILE/TRANSACTIONS").Attributes["count"].Value);
                    XmlNodeList transactionNodes = doc.DocumentElement.SelectNodes("/KMYMONEY-FILE/TRANSACTIONS/TRANSACTION");
                    //TransactionsXML(transactionNodes);
                    foreach (XmlNode transactionNode in transactionNodes)
                    {
                        Console.WriteLine("postdate= " + transactionNode.Attributes["postdate"].Value);
                        Console.WriteLine("commodity= " + transactionNode.Attributes["commodity"].Value);
                        Console.WriteLine("memo= " + transactionNode.Attributes["memo"].Value);
                        Console.WriteLine("id= " + transactionNode.Attributes["id"].Value);
                        Console.WriteLine("entrydate= " + transactionNode.Attributes["entrydate"].Value);

                        //SPLITS
                        XmlNodeList splitNodes = transactionNode.SelectNodes("SPLITS/SPLIT");
                        foreach (XmlNode splitNode in splitNodes)
                        {
                            Console.Write("  - payee = " + splitNode.Attributes["payee"].Value);
                            Console.WriteLine(" ,reconcileflag = " + splitNode.Attributes["reconcileflag"].Value);
                            Console.WriteLine(" ,shares = " + splitNode.Attributes["shares"].Value);
                            Console.WriteLine(" ,reconciledate = " + splitNode.Attributes["reconciledate"].Value);
                            Console.WriteLine(" ,action = " + splitNode.Attributes["action"].Value);
                            Console.WriteLine(" ,bankid = " + splitNode.Attributes["bankid"].Value);
                            Console.WriteLine(" ,account = " + splitNode.Attributes["account"].Value);
                            Console.WriteLine(" ,number = " + splitNode.Attributes["number"].Value);
                            Console.WriteLine(" ,value = " + splitNode.Attributes["value"].Value);
                            Console.WriteLine(" ,memo = " + splitNode.Attributes["memo"].Value);
                            Console.WriteLine(" ,id = " + splitNode.Attributes["id"].Value);

                            try
                            {
                                //Tag into Split
                                XmlNodeList SplitTagNodes = splitNode.SelectNodes("TAG");
                                foreach (XmlNode SplitTagNode in SplitTagNodes)
                                {
                                    Console.WriteLine(" TAG ID => " + SplitTagNode.Attributes["id"].Value);
                                }
                                //End
                            }
                            catch (Exception tagException)
                            {
                                System.Diagnostics.Debug.WriteLine("Tag Exception: " + tagException);
                            }
                        }

                    }
                    //TRANSACTIONS END


                    //KEYVALUEPAIRS
                    Console.WriteLine("-----KEYVALUEPAIRS-----");
                    XmlNodeList keyValuePairNodes = doc.DocumentElement.SelectNodes("/KMYMONEY-FILE/KEYVALUEPAIRS/PAIR");
                    foreach (XmlNode keyValuePairNode in keyValuePairNodes)
                    {
                        Console.Write("  - key = " + keyValuePairNode.Attributes["key"].Value);
                        Console.WriteLine(" ,value = " + keyValuePairNode.Attributes["value"].Value);

                    }
                    //KEYVALUEPAIRS END

                    //SCHEDULES
                    Console.WriteLine("-----SCHEDULES----- results= " + doc.DocumentElement.SelectSingleNode("/KMYMONEY-FILE/SCHEDULES").Attributes["count"].Value);
                    XmlNodeList scheduleNodes = doc.DocumentElement.SelectNodes("/KMYMONEY-FILE/SCHEDULES/SCHEDULED_TX");
                    foreach (XmlNode scheduleNode in scheduleNodes)
                    {
                        Console.Write("  - paymentType = " + scheduleNode.Attributes["paymentType"].Value);
                        Console.WriteLine(" ,autoEnter = " + scheduleNode.Attributes["autoEnter"].Value);
                        Console.WriteLine(" ,occurenceMultiplier = " + scheduleNode.Attributes["occurenceMultiplier"].Value);
                        Console.WriteLine(" ,startDate = " + scheduleNode.Attributes["startDate"].Value);
                        Console.WriteLine(" ,lastDayInMonth = " + scheduleNode.Attributes["lastDayInMonth"].Value);
                        Console.WriteLine(" ,lastPayment = " + scheduleNode.Attributes["lastPayment"].Value);
                        Console.WriteLine(" ,occurence = " + scheduleNode.Attributes["occurence"].Value);
                        Console.WriteLine(" ,weekendOption = " + scheduleNode.Attributes["weekendOption"].Value);
                        Console.WriteLine(" ,id = " + scheduleNode.Attributes["id"].Value);
                        Console.WriteLine(" ,name = " + scheduleNode.Attributes["name"].Value);
                        Console.WriteLine(" ,endDate = " + scheduleNode.Attributes["endDate"].Value);
                        Console.WriteLine(" ,fixed = " + scheduleNode.Attributes["fixed"].Value);

                        //TRANSACTIONS
                        TransactionsXML(scheduleNode.SelectNodes("TRANSACTION"));
                        //TRANSACTIONS END


                    }
                    //SCHEDULES END


                    //CURRENCIES
                    Console.WriteLine("-----CURRENCIES----- results= " + doc.DocumentElement.SelectSingleNode("/KMYMONEY-FILE/CURRENCIES").Attributes["count"].Value);
                    XmlNodeList currencyNodes = doc.DocumentElement.SelectNodes("/KMYMONEY-FILE/CURRENCIES/CURRENCY");
                    foreach (XmlNode currencyNode in currencyNodes)
                    {
                        Console.Write("  - saf = " + currencyNode.Attributes["saf"].Value);
                        Console.WriteLine(" ,symbol = " + currencyNode.Attributes["symbol"].Value);
                        Console.WriteLine(" ,type = " + currencyNode.Attributes["type"].Value);
                        Console.WriteLine(" ,id = " + currencyNode.Attributes["id"].Value);
                        Console.WriteLine(" ,name = " + currencyNode.Attributes["name"].Value);
                        Console.WriteLine(" ,ppu = " + currencyNode.Attributes["ppu"].Value);
                        Console.WriteLine(" ,scf = " + currencyNode.Attributes["scf"].Value);
                    }
                    //CURRENCIES END



                    //PRICES
                    Console.WriteLine("-----PRICES----- results= " + doc.DocumentElement.SelectSingleNode("/KMYMONEY-FILE/PRICES").Attributes["count"].Value);
                    XmlNodeList pricePairNodes = doc.DocumentElement.SelectNodes("/KMYMONEY-FILE/PRICES/PRICEPAIR");
                    foreach (XmlNode pricePairNode in pricePairNodes)
                    {
                        Console.Write("  - from = " + pricePairNode.Attributes["from"].Value);
                        Console.WriteLine(" ,to = " + pricePairNode.Attributes["to"].Value);
                        Console.WriteLine("  -> price = " + pricePairNode.SelectSingleNode("PRICE").Attributes["price"].Value);
                        Console.WriteLine("     source = " + pricePairNode.SelectSingleNode("PRICE").Attributes["source"].Value);
                        Console.WriteLine("     date = " + pricePairNode.SelectSingleNode("PRICE").Attributes["date"].Value);
                    }
                    //PRICES END

                }
                catch (Exception EE)
                {
                    Console.WriteLine(EE);

                }

                //var accountsLIST = conn.Table<Account>().ToList();
                //var InstitutionSLIST = conn.Table<Institution>().ToList();

                conn.Close();

                //foreach (var t in accountsLIST)
                //{
                //    System.Diagnostics.Debug.WriteLine(string.Format("Account id:{0} , name:{1}", t.Id, t.Name));
                //}
                //foreach (var t in InstitutionSLIST)
                //{
                //    System.Diagnostics.Debug.WriteLine(string.Format("Insitution id:{0} , name:{1}",t.Id,t.Name));
                //}


                //await DisplayAlert("Alert", "Database has been stored", "OK");


                //await Navigation.PushModalAsync(new Views.FileViews.File());

                //Application.Current.MainPage = new NavigationPage(new Views.FileViews.File(fileNamePath));
            }
        }

        

        protected override void OnAppearing()
        {
            Console.WriteLine("mpike onAppearing");

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            Console.WriteLine("mpike onDisapperaing ");

            base.OnDisappearing();
        }


        ////
        private void TransactionsXML(XmlNodeList nodes)
        {
            foreach (XmlNode transactionNode in nodes)
            {
                Console.WriteLine("postdate= " + transactionNode.Attributes["postdate"].Value);
                Console.WriteLine("commodity= " + transactionNode.Attributes["commodity"].Value);
                Console.WriteLine("memo= " + transactionNode.Attributes["memo"].Value);
                Console.WriteLine("id= " + transactionNode.Attributes["id"].Value);
                Console.WriteLine("entrydate= " + transactionNode.Attributes["entrydate"].Value);

                //SPLITS
                XmlNodeList splitNodes = transactionNode.SelectNodes("SPLITS/SPLIT");
                foreach (XmlNode splitNode in splitNodes)
                {
                    Console.Write("  - payee = " + splitNode.Attributes["payee"].Value);
                    Console.WriteLine(" ,reconcileflag = " + splitNode.Attributes["reconcileflag"].Value);
                    Console.WriteLine(" ,shares = " + splitNode.Attributes["shares"].Value);
                    Console.WriteLine(" ,reconciledate = " + splitNode.Attributes["reconciledate"].Value);
                    Console.WriteLine(" ,action = " + splitNode.Attributes["action"].Value);
                    Console.WriteLine(" ,bankid = " + splitNode.Attributes["bankid"].Value);
                    Console.WriteLine(" ,account = " + splitNode.Attributes["account"].Value);
                    Console.WriteLine(" ,number = " + splitNode.Attributes["number"].Value);
                    Console.WriteLine(" ,value = " + splitNode.Attributes["value"].Value);
                    Console.WriteLine(" ,memo = " + splitNode.Attributes["memo"].Value);
                    Console.WriteLine(" ,id = " + splitNode.Attributes["id"].Value);
                }

            }
        }
    }
}