using System;
using System.IO;
using Xamarin.Forms;
using KMyMoney_Thesis;
using KMyMoney_Thesis.Droid;
[assembly: Dependency(typeof(FileHelper))]
namespace KMyMoney_Thesis.Droid
{
    public class FileHelper : IFileReadWrite
    {
        public void WriteData(string filename, string data)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            File.WriteAllText(filePath, data);
        }
        public string ReadData(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return File.ReadAllText(filePath);
        }
    }
}
