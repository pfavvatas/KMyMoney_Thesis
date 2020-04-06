using System;
using Xamarin.Forms;

namespace KMyMoney_Thesis
{
    public interface IFileReadWrite
    {
        void WriteData(string fileName, string data);
        string ReadData(string filename);
    }
}
