using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.IO;
using System.Xml;
using KMyMoney_Thesis.Models;
using System.Collections.ObjectModel;

using KMyMoney_Thesis.DataStorage;

using System.Threading.Tasks;
using Xamarin.Essentials;

namespace KMyMoney_Thesis.Views.FileViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class File : ContentPage
    {
        public string myProperty { set; get; }



        public string contents { get; }
        private ObservableCollection<Account> accountsList = new ObservableCollection<Account>();
        public ObservableCollection<Account> accountListData { get { return accountsList; } }
        public File()
        {
            InitializeComponent();

            Title = "File contents";
            //this.contents = contents;
            //LabelOutput.Text = this.contents;

            //Console.WriteLine("file path => " + fileName);
            //FileName = fileName;
            //LoadXMLData();
            //SaveToDevice();
            //myProperty = myProperty + "Reading the file... \n";
            //ReadFile();



            //BindingContext = this;


            //////
            
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //string filename = Path.Combine(path, "myfile.txt");

            //using (var streamWriter = new StreamWriter(filename, true))
            //{
            //    streamWriter.WriteLine(DateTime.UtcNow);
            //}

            //using (var streamReader = new StreamReader(filename))
            //{
            //    string content = streamReader.ReadToEnd();
            //    System.Diagnostics.Debug.WriteLine(content);
            //}
            string text = Application.Current.Properties["database"] as string;
            LabelOutput.Text = text;
            

        }

        private async void ReadFile()
        {
            Console.WriteLine("Into ReadFile()");
            //myProperty = myProperty + "Into ReadFile() \n";

            using (var stream = await FileSystem.OpenAppPackageFileAsync("kmymoneyDB.xml"))
            {
                //LabelOutput.Text = "file = " + stream + "\n";
                String p= "Can read = " + stream.CanRead + "\n";
                p += "Can write = "+ stream.CanWrite + "\n";
                //LabelOutput.Text = p;

                //myProperty = myProperty + "Into var stream \n";
                //using (var fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal)), FileMode.Create, FileAccess.Write))

                //using (var writer = new StreamWriter(stream))
                //{
                //    Console.WriteLine("Into writer");
                //    writer.Write("eeeeep");
                //}
                //using (var reader = new StreamReader(stream))
                //{
                //    Console.WriteLine("Into var reader");
                //    //myProperty = myProperty + "Into var reader \n";

                //    String r = await reader.ReadToEndAsync();
                //    Console.WriteLine(r);
                //    LabelOutput.Text = r;
                //    //myProperty += await reader.ReadToEndAsync();
                //    //BindingContext = this;

                //}

            }
        }

        private void SaveToDevice()
        {
            //String result = "";
            //// Read entire text file content in one string  
            ////string text = File.ReadAllText(FileName);
            ////Console.WriteLine(text);
            //try
            //{
            //    string test = System.IO.File.ReadAllText(FileName);
            //}catch(Exception e)
            //{
            //    LabelOutput.Text = FileName + "\n" + e.ToString();

            //}
            //myProperty = test;

            //This gets the full path for the "files" directory of your app, where you have permission to read/write.
            //var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            //Console.WriteLine("documentsPath => " + documentsPath);
            //foreach(System.Environment.SpecialFolder folder_type in Enum.GetValues(typeof(Environment.SpecialFolder)))
            //{
            //    Console.WriteLine(folder_type.ToString() + " - "+ Environment.GetFolderPath(folder_type));
            //    //String.Format("{0,-25} - %s \r\n", folder_type.ToString(), Environment.GetFolderPath(folder_type));
            //}

            //This creates the full file path to your "testfile.txt" file.
            //var filePath = System.IO.Path.Combine(documentsPath, "write.txt");
            //System.IO.File.WriteAllText(filePath, "blablabla");
            //Console.WriteLine(test);


            //Now create the file.
            //System.IO.File.Create(filePath);
            //Console.WriteLine("Exist    => " + System.IO.File.Exists(filePath));
            //result = "Exist    => " + System.IO.File.Exists(filePath) + "\n" + System.IO.File.ReadAllText(filePath);
            //Console.WriteLine("Exist    => " + System.IO.File.Exists(filePath));


            //Write to file
            //try
            //{
            //    //System.IO.File.WriteAllText(filePath, "test123....");
            //}
            //catch(Exception e)
            //{
            //    //Console.WriteLine("error    => " + e);
            //}

            //System.IO.File.WriteAllText(filePath, "test");

            //string test = documentsPath.ToString();// System.IO.File.ReadAllText(documentsPath+"/data.xml");
            //myProperty = result;
        }

        //private async void LoadXMLData()
        //{
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(FileName);

        //    Console.WriteLine("Read Accounts:");
        //    XmlNodeList element = doc.GetElementsByTagName("ACCOUNT");
        //    for (int i = 0; i < element.Count; i++)
        //    {
        //        //Console.WriteLine(element[i].Attributes["name"].Value);
        //        var tmp = new Account();
        //        tmp.Name = element[i].Attributes["name"].Value;
        //        tmp.Id = element[i].Attributes["id"].Value;
        //        tmp.Type = element[i].Attributes["type"].Value;
        //        tmp.Opened = element[i].Attributes["opened"].Value;
        //        tmp.Currency = element[i].Attributes["currency"].Value;
        //        //accountListData.Add(tmp);
        //        //Console.WriteLine(accountListData[i]);
        //        accountListData.Add(new Account() { Name = tmp.Name, Currency = tmp.Currency, Id = tmp.Id, Opened = tmp.Opened, Type = tmp.Type });
        //    }
        //    //AccountsListData.ItemsSource = accountListData;
        //    //foreach (Account acc in accountListData)
        //    //{
        //    //    Console.WriteLine(acc.ToString());
        //    //    //or print the property of your class
        //    //}
        //}
    }
}
