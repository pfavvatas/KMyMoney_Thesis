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


                //Set the validation settings.
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Parse;
                //settings.ValidationType = ValidationType.DTD;



                // Create the XmlReader object.
                XmlReader reader = XmlReader.Create(new StringReader(contents), settings);

                // Parse the file. 
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        //System.Diagnostics.Debug.WriteLine(reader.Name.ToString());
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ACCOUNTS"))
                        {
                            if (reader.HasAttributes)
                                System.Diagnostics.Debug.WriteLine("Count= " + reader.GetAttribute("count"));
                        }

                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "INSTITUTION"))
                        {

                            if (reader.HasAttributes)
                            {
                                
                                //System.Diagnostics.Debug.WriteLine(reader.GetAttribute("currency") + ": " + reader.GetAttribute("name"));
                                Institution inst = new Institution()
                                {
                                    Id = reader.GetAttribute("id"),
                                    Name = reader.GetAttribute("name")
                                };
                                //System.Diagnostics.Debug.WriteLine("Institution ID: " + reader.GetAttribute("id"));
                                try
                                {
                                    conn.Insert(inst);
                                    //System.Diagnostics.Debug.WriteLine("mpike sti basi");

                                }
                                catch (SQLiteException sqle)
                                {
                                    System.Diagnostics.Debug.WriteLine("SQL Exception: " + sqle);

                                }

                            }
                        }

                        //Get Accounts
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ACCOUNT"))
                        {
                            if (reader.HasAttributes)
                            {
                                //System.Diagnostics.Debug.WriteLine(reader.GetAttribute("currency") + ": " + reader.GetAttribute("name"));
                                Account acc = new Account()
                                {
                                    Id = reader.GetAttribute("id"),
                                    Name = reader.GetAttribute("name")
                                };
                                //System.Diagnostics.Debug.WriteLine("ID: "+ reader.GetAttribute("id"));
                                try
                                {
                                    conn.Insert(acc);
                                    //System.Diagnostics.Debug.WriteLine("mpike sti basi");
                                    
                                }catch(SQLiteException sqle)
                                {
                                    System.Diagnostics.Debug.WriteLine("SQL Exception: "+ sqle);

                                }

                            }
                        }
                    }
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
    }
}