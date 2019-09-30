using System;

using Xamarin.Forms;

namespace KMyMoney_Thesis.Models
{
    public class TestBinding2 
    {
        public string Date { set; get; }
        public string Detais { set; get; }
        public string Balance { set; get; }

        public string EchoTogether {
            get {
                return string.Format("{0} | {1} | +/- ${2}", Date, Detais, Balance);
            }
        }
    }
}

