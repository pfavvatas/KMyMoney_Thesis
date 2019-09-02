using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KMyMoney_Thesis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetupPage4 : ContentPage
    {
        public Models.PersonalData PersonalData { get; set; }

        public SetupPage4(Models.PersonalData PersonalData)
        {
            this.PersonalData = PersonalData;

            InitializeComponent();
        }

        private async void Button_Clicked_To_SetupPage4(object sender, EventArgs e)
        {
            

        }
    }
}