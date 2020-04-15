using System;
using KMyMoney_Thesis.Model;
using SQLite;

namespace KMyMoney_Thesis
{
    public class PrintDatabase
    {
        public PrintDatabase()
        {
            //SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);

            //var accountsLIST = conn.Table<Account>().ToList();
            //var InstitutionSLIST = conn.Table<Institution>().ToList();

            //conn.Close();

            //System.Diagnostics.Debug.WriteLine("Database:");
            //System.Diagnostics.Debug.WriteLine("-Accounts:");
            //foreach (var t in accountsLIST)
            //{
            //    System.Diagnostics.Debug.WriteLine(string.Format(" id:{0} , name:{1}", t.Id, t.Name));
            //}

            //System.Diagnostics.Debug.WriteLine("-Insitutions:");
            //foreach (var t in InstitutionSLIST)
            //{
            //    System.Diagnostics.Debug.WriteLine(string.Format(" id:{0} , name:{1}", t.Id, t.Name));
            //}
        }
    }
}
