using KMyMoney_Thesis.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace KMyMoney_Thesis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetupPage : ContentPage
    {
        public Model.XML.KMYMONEY_FILE NewXML { get; set; }
        public Models.PersonalData PersonalData { get; set; }
        public TableSection SelectAccountsTableSelection;
        public int SelectAccountsPosition;
        public SetupPage()
        {
            InitializeComponent();            

            PersonalData = new Models.PersonalData();
            setTestData();
            //SelectAccountsPosition = SetupPageTable.Root.IndexOf(SelectAccountsTableSection);
            //SelectAccountsTableSelection = SetupPageTable.Root[SetupPageTable.Root.IndexOf(SelectAccountsTableSection)];
            //SelectAccountsFalse();
            //SetupPageTable.Root.Remove(SelectAccountsTableSection);

        }

        public void setTestData()
        {
            Entry_Name.Text = "Entry_Name";

            Entry_Street.Text = "Entry_Street";

            Entry_Town.Text = "Entry_Town";

            Entry_Country.Text = "Entry_Country";

            Entry_Postal_Code.Text = "Entry_Postal_Code";

            Entry_Telephone.Text = "Entry_Telephone";

            Entry_Email.Text = "Entry_Email";

            //Entry_Currency.PlaceholderColor = Color.Black;

            Entry_NameOfTheAccount.Text = "Entry_NameOfTheAccount";

            Entry_NumberOfTheAccount.Text = "Entry_NumberOfTheAccount";

            Entry_Street.Text = "Entry_Street";

            Entry_OpeningBalance.Text = "Entry_OpeningBalance";

            Entry_NumberOfTheInstitution.Text = "Entry_NumberOfTheInstitution";

            Entry_RoutingNumber.Text = "Entry_RoutingNumber";
        }

        void Picker_Currency2(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                PersonalData.Currency = picker.Items[selectedIndex];
            }
        }

        private async void Button_Clicked_To_SetupPage2(object sender, EventArgs e)
        {
            PersonalData.Name = Entry_Name.Text;
            PersonalData.Street = Entry_Street.Text;
            PersonalData.Town = Entry_Town.Text;
            PersonalData.Country = Entry_Country.Text;
            PersonalData.Postal_code = Entry_Postal_Code.Text;
            PersonalData.Telephone = Entry_Telephone.Text;
            PersonalData.Email = Entry_Email.Text;            
            await DisplayAlert("Alert", ""+ PersonalData, "OK");
            //Debug.WriteLine("=========================Output "+ Entry_Name.Text);
            //await Navigation.PushAsync(new SetupPage2(PersonalData));
        }

        
        //Account Switch
        private void CheckingAccountSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            //Toggle StackLayout_CheckingAccountDataMoreInfo
            if (StackLayout_CheckingAccountDataMoreInfo.IsVisible)
            {
                StackLayout_CheckingAccountDataMoreInfo.IsVisible = false;
            }
            else
            {
                StackLayout_CheckingAccountDataMoreInfo.IsVisible = true;
            }
        }

        //Currency Picker
        private void Picker_Currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                //PersonalData.Currency = picker.Items[selectedIndex];
            }
        }

        //Account type Picker
        private void Picker_Select_Account_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                //PersonalData.Currency = picker.Items[selectedIndex];
                Debug.WriteLine("->Picker_Select_Account_Type_SelectedIndexChanged: " + picker.Items[selectedIndex]);
            }
        }

        //Submit Button
        private void Button_Submit_Clicked(object sender, EventArgs e)
        {
            try
            {


                bool isEntryValid = true;
                //Check required Entry data
                //
                //Entry_Name
                if (string.IsNullOrEmpty(Entry_Name.Text) || string.IsNullOrWhiteSpace(Entry_Name.Text))
                {
                    isEntryValid = false;
                    Entry_Name.PlaceholderColor = Color.Red;
                }
                else
                {
                    PersonalData.Name = Entry_Name.Text;
                }

                //Entry_Street
                if (string.IsNullOrEmpty(Entry_Street.Text) || string.IsNullOrWhiteSpace(Entry_Street.Text))
                {
                    isEntryValid = false;
                    Entry_Street.PlaceholderColor = Color.Red;
                }
                else
                {
                    PersonalData.Street = Entry_Street.Text;
                }

                //Entry_Town
                if (string.IsNullOrEmpty(Entry_Town.Text) || string.IsNullOrWhiteSpace(Entry_Town.Text))
                {
                    isEntryValid = false;
                    Entry_Town.PlaceholderColor = Color.Red;
                }
                else
                {
                    PersonalData.Town = Entry_Town.Text;
                }

                //Entry_Country
                if (string.IsNullOrEmpty(Entry_Country.Text) || string.IsNullOrWhiteSpace(Entry_Country.Text))
                {
                    isEntryValid = false;
                    Entry_Country.PlaceholderColor = Color.Red;
                }
                else
                {
                    PersonalData.Country = Entry_Country.Text;
                }

                //Entry_Postal_code
                if (string.IsNullOrEmpty(Entry_Postal_Code.Text) || string.IsNullOrWhiteSpace(Entry_Postal_Code.Text))
                {
                    isEntryValid = false;
                    Entry_Postal_Code.PlaceholderColor = Color.Red;
                }
                else
                {
                    PersonalData.Postal_code = Entry_Postal_Code.Text;
                }

                //Entry_Telephone
                if (string.IsNullOrEmpty(Entry_Telephone.Text) || string.IsNullOrWhiteSpace(Entry_Telephone.Text))
                {
                    isEntryValid = false;
                    Entry_Telephone.PlaceholderColor = Color.Red;
                }
                else
                {
                    PersonalData.Telephone = Entry_Telephone.Text;
                }

                //Entry_Email
                if (string.IsNullOrEmpty(Entry_Email.Text) || string.IsNullOrWhiteSpace(Entry_Email.Text))
                {
                    isEntryValid = false;
                    Entry_Email.PlaceholderColor = Color.Red;
                }
                else
                {
                    PersonalData.Email = Entry_Email.Text;
                }

                //Entry_Currency
                //if (string.IsNullOrEmpty(Entry_Currency.Text) || string.IsNullOrWhiteSpace(Entry_Currency.Text))
                //{
                //    isEntryValid = false;
                //    Entry_Currency.PlaceholderColor = Color.Red;
                //}
                //else
                //{
                //    PersonalData.Currency = Entry_Currency.Text;
                //}

                //Entry_Enable_Checking_Account
                //if (string.IsNullOrEmpty(Entry_NameOfTheAccount.Text) || string.IsNullOrWhiteSpace(Entry_NameOfTheAccount.Text))
                //{
                //    isEntryValid = false;
                //    Entry_NameOfTheAccount.PlaceholderColor = Color.Red;
                //}
                //else
                //{
                //    PersonalData.Enable_Checking_Account = Entry_NameOfTheAccount.Text;
                //}

                //Entry_Name_Of_The_Account
                if (string.IsNullOrEmpty(Entry_NameOfTheAccount.Text) || string.IsNullOrWhiteSpace(Entry_NameOfTheAccount.Text))
                {
                    isEntryValid = false;
                    Entry_NameOfTheAccount.PlaceholderColor = Color.Red;
                }
                else
                {
                    PersonalData.Name_Of_The_Account = Entry_NameOfTheAccount.Text;
                }

                //Entry_Number_Of_The_Account
                if (string.IsNullOrEmpty(Entry_NumberOfTheAccount.Text) || string.IsNullOrWhiteSpace(Entry_NumberOfTheAccount.Text))
                {
                    isEntryValid = false;
                    Entry_NumberOfTheAccount.PlaceholderColor = Color.Red;
                }
                else
                {
                    PersonalData.Number_Of_The_Account = Entry_NumberOfTheAccount.Text;
                }

                //Entry_Opening_Date
                //if (string.IsNullOrEmpty(Entry_OpeningDatePicker.Text) || string.IsNullOrWhiteSpace(Entry_Street.Text))
                //{
                //    isEntryValid = false;
                //    Entry_Street.PlaceholderColor = Color.Red;
                //}
                //else
                //{
                //    PersonalData.Opening_Date = Entry_Street.Text;
                //}

                //Entry_Street
                if (string.IsNullOrEmpty(Entry_OpeningBalance.Text) || string.IsNullOrWhiteSpace(Entry_OpeningBalance.Text))
                {
                    isEntryValid = false;
                    Entry_OpeningBalance.PlaceholderColor = Color.Red;
                }
                else
                {
                    PersonalData.Opening_Balance = Entry_OpeningBalance.Text;
                }

                //Entry_Number_Of_The_Institution
                if (string.IsNullOrEmpty(Entry_NumberOfTheInstitution.Text) || string.IsNullOrWhiteSpace(Entry_NumberOfTheInstitution.Text))
                {
                    isEntryValid = false;
                    Entry_NumberOfTheInstitution.PlaceholderColor = Color.Red;
                }
                else
                {
                    PersonalData.Number_Of_The_Institution = Entry_NumberOfTheInstitution.Text;
                }

                //Entry_RoutingNumber
                if (string.IsNullOrEmpty(Entry_RoutingNumber.Text) || string.IsNullOrWhiteSpace(Entry_RoutingNumber.Text))
                {
                    isEntryValid = false;
                    Entry_RoutingNumber.PlaceholderColor = Color.Red;
                }
                else
                {
                    PersonalData.Routing_Number = Entry_RoutingNumber.Text;
                }

                //Entry_Account_Type
                //if (string.IsNullOrEmpty(Entry_RoutingNumber.Text) || string.IsNullOrWhiteSpace(Entry_RoutingNumber.Text))
                //{
                //    isEntryValid = false;
                //    Entry_RoutingNumber.PlaceholderColor = Color.Red;
                //}
                //else
                //{
                //    PersonalData.Account_Type = Entry_RoutingNumber.Text;
                //}


                //Continue above and chech is isEntryValid or not to contintue.

                if (isEntryValid)
                {
                    Debug.WriteLine("->PersonalData: " + PersonalData.Name);
                    Debug.WriteLine("->PersonalData: " + PersonalData.Street);
                    Debug.WriteLine("->PersonalData: " + PersonalData.Town);
                    Debug.WriteLine("->PersonalData: " + PersonalData.Country);
                    Debug.WriteLine("->PersonalData: " + PersonalData.Postal_code);
                    Debug.WriteLine("->PersonalData: " + PersonalData.Telephone);
                    Debug.WriteLine("->PersonalData: " + PersonalData.Email);
                    Debug.WriteLine("->PersonalData: " + PersonalData.Currency);
                    Debug.WriteLine("->PersonalData: " + PersonalData.Enable_Checking_Account);
                    Debug.WriteLine("->PersonalData: " + PersonalData.Name_Of_The_Account);
                    Debug.WriteLine("->PersonalData: " + PersonalData.Number_Of_The_Account);
                    Debug.WriteLine("->PersonalData: " + PersonalData.Opening_Date);
                    Debug.WriteLine("->PersonalData: " + PersonalData.Opening_Balance);
                    Debug.WriteLine("->PersonalData: " + PersonalData.Number_Of_The_Institution);
                    Debug.WriteLine("->PersonalData: " + PersonalData.Routing_Number);
                    Debug.WriteLine("->PersonalData: " + PersonalData.Routing_Number);

                    //Write data to xml
                    createXML(PersonalData);
                    //Uncomment bellow to continue
                    Application.Current.MainPage = new MainPage();
                }
                else
                {
                    scrollView.ScrollToAsync(0, 0, true);
                }

                //Application.Current.MainPage = new MainPage();
            }
            catch(Exception error)
            {
                Debug.WriteLine("->Error: " + error);
            }
        }

        private void makeEntriesGreen()
        {

            Entry_Name.PlaceholderColor = Color.Black;

            Entry_Street.PlaceholderColor = Color.Black;

            Entry_Town.PlaceholderColor = Color.Black;

            Entry_Country.PlaceholderColor = Color.Black;

            Entry_Postal_Code.PlaceholderColor = Color.Black;

            Entry_Telephone.PlaceholderColor = Color.Black;

            Entry_Email.PlaceholderColor = Color.Black;

            //Entry_Currency.PlaceholderColor = Color.Black;

            Entry_NameOfTheAccount.PlaceholderColor = Color.Black;

            Entry_NameOfTheAccount.PlaceholderColor = Color.Black;

            Entry_NumberOfTheAccount.PlaceholderColor = Color.Black;

            Entry_Street.PlaceholderColor = Color.Black;

            Entry_OpeningBalance.PlaceholderColor = Color.Black;

            Entry_NumberOfTheInstitution.PlaceholderColor = Color.Black;

            Entry_RoutingNumber.PlaceholderColor = Color.Black;

        }

        private void createXML(Models.PersonalData PersonalData)
        {
            //Create XML            
            XmlSerializer serializer = new XmlSerializer(typeof(Model.XML.KMYMONEY_FILE));
            TextWriter writer = new StreamWriter("test.xml");
            NewXML = new Model.XML.KMYMONEY_FILE();

            ///////////////////////////////////////////////////////////////////
            //1) Create FILEINFO
            Model.XML.FileInfo newFileInfo = new Model.XML.FileInfo();

            //1.1) Create CREATION_DATE
            Model.XML.CreationDate NewCreationDate = new Model.XML.CreationDate();
            NewCreationDate.date = DateTime.Now.ToString("MM/dd/yyyy");
            newFileInfo.CREATION_DATE = NewCreationDate;

            //1.2) Create LAST_MODIFIED_DATE
            Model.XML.LastModifiedDate NewLastModifiedDate = new Model.XML.LastModifiedDate();
            NewLastModifiedDate.date = DateTime.Now.ToString("MM/dd/yyyy");
            newFileInfo.LAST_MODIFIED_DATE = NewLastModifiedDate;

            //1.3) Create VERSION
            Model.XML.Version NewVersion = new Model.XML.Version();
            NewVersion.id = "1";
            newFileInfo.VERSION = NewVersion;

            //1.4) Create FIXVERSION
            Model.XML.FixVersion NewFixVersion = new Model.XML.FixVersion();
            NewFixVersion.id = "1";
            newFileInfo.FIXVERSION = NewFixVersion;

            NewXML.FILEINFO = newFileInfo;
            ///////////////////////////////////////////////////////////////////
            //2) Create USER
            Model.XML.User newUser = new Model.XML.User();

            //2.1) Create email
            newUser.email = PersonalData.Email;
            //2.2) Create name
            newUser.name = PersonalData.Name;
            //2.3) Create ADDRESS
            Model.XML.Address newAddress = new Model.XML.Address();
            newAddress.street = PersonalData.Street;
            newAddress.telephone = PersonalData.Telephone;
            newAddress.county = PersonalData.Country;
            newAddress.city = PersonalData.Town;
            newAddress.zipcode = PersonalData.Postal_code;
            newUser.ADDRESS = newAddress;

            NewXML.USER = newUser;
            ///////////////////////////////////////////////////////////////////
            //3) Create INSTITUTIONS
            Model.XML.Institutions newInstitutions = new Model.XML.Institutions();

            //3.1) Create count
            //newInstitutions.count = "1";

            //3.2) Create INSTITUTION
            Model.XML.Institution newInstitution = new Model.XML.Institution();
            newInstitution.manager = null;
            newInstitution.id = "I000001";
            newInstitution.name = PersonalData.Number_Of_The_Institution; //Number_Of_The_Institution
            newInstitution.sortcode = PersonalData.Routing_Number; //Routing_Number

            //3.2.1) Create ADDRESS
            Model.XML.Address2 newAddress2 = new Model.XML.Address2();
            newAddress2.street = "street1";
            newAddress2.telephone = "telephone1";
            newAddress2.city = "city1";
            newAddress2.zip = "zip1";
            newInstitution.ADDRESS = newAddress2;

            //3.2.2) Create ACCOUNTIDS
            Model.XML.ACCOUNTID newAccountId = new Model.XML.ACCOUNTID();
            newAccountId.id = "A000001";            
            //Model.XML.ACCOUNTID[] newAccountIdItems = { newAccountId , newAccountId2 };
            List<Model.XML.ACCOUNTID> newAccountIdItems = new List<Model.XML.ACCOUNTID>();
            newAccountIdItems.Add(newAccountId);
            Model.XML.ACCOUNTIDS accountidsItem = new Model.XML.ACCOUNTIDS();
            accountidsItem.ACCOUNTID = newAccountIdItems;
            newInstitution.ACCOUNTIDS = accountidsItem;

            //Model.XML.Institution[] institutionsItems = { newInstitution };
            //newInstitutions.INSTITUTION = institutionsItems;
            List<Model.XML.Institution> institutionsItemsList = new List<Model.XML.Institution>();
            institutionsItemsList.Add(newInstitution);
            institutionsItemsList.Add(newInstitution);
            newInstitutions.INSTITUTION = institutionsItemsList;
            newInstitutions.setCount(); //update count value
            NewXML.INSTITUTIONS = newInstitutions;
            ///////////////////////////////////////////////////////////////////
            //4) Create PAYEES
            Model.XML.Payees payeesItem = new Model.XML.Payees();
            payeesItem.PAYEE = null;
            payeesItem.setCount();
            NewXML.PAYEES = payeesItem;
            ///////////////////////////////////////////////////////////////////
            //...
            ///////////////////////////////////////////////////////////////////
            //9) Create KEYVALUEPAIRS
            //kmm-id
            Model.XML.Pair newPair = new Model.XML.Pair();
            newPair.key = "kmm-baseCurrency";
            newPair.Value = "EUR";
            Model.XML.Pair newPair2 = new Model.XML.Pair();
            newPair2.key = "kmm-id";
            newPair2.Value = "{" + Guid.NewGuid() + "}";
            Model.XML.KeyValuePairs keyValuePairsItems = new Model.XML.KeyValuePairs();
            List<Model.XML.Pair> pairsList = new List<Model.XML.Pair>();
            pairsList.Add(newPair);
            pairsList.Add(newPair2);
            keyValuePairsItems.PAIR = pairsList;
            NewXML.KEYVALUEPAIRS = keyValuePairsItems;
            ///////////////////////////////////////////////////////////////////
            //14) Create PRICES
            Model.XML.Prices prices = new Model.XML.Prices();
            List<Model.XML.Price> pricesItems = new List<Model.XML.Price>();
            prices.PRICE = pricesItems;
            prices.setCount();
            NewXML.PRICES = prices;
            ///////////////////////////////////////////////////////////////////
            //14) Create REPORTS
            Model.XML.Reports reports = new Model.XML.Reports();
            List<Model.XML.Report> reportsItems = new List<Model.XML.Report>();
            reports.REPORT = reportsItems;
            reports.setCount();
            NewXML.REPORTS = reports;
            ///////////////////////////////////////////////////////////////////
            //15) Create BUDGETS
            Model.XML.Budgets budgets = new Model.XML.Budgets();
            List<Model.XML.Budget> budgetsItems = new List<Model.XML.Budget>();
            budgets.BUDGET = budgetsItems;
            budgets.setCount();
            NewXML.BUDGETS = budgets;
            ///////////////////////////////////////////////////////////////////
            //16) Create ONLINEJOBS
            Model.XML.OnlineJobs onlineJobs = new Model.XML.OnlineJobs();
            List<Model.XML.OnlineJob> onlineJobItems = new List<Model.XML.OnlineJob>();
            onlineJobs.ONLINEJOB = onlineJobItems;
            onlineJobs.setCount();
            NewXML.ONLINEJOBS = onlineJobs;
            ///////////////////////////////////////////////////////////////////
            
            // Serializes the purchase order, and closes the TextWriter.
            serializer.Serialize(writer, NewXML);
            writer.Close();

            //Test print data
            XmlDocument xmlDoc = new XmlDocument();
            string filename = @"test.xml";
            xmlDoc.Load(filename);
            xmlDoc.Save(Console.Out);
            //
            //End of xml
        }
    }
}