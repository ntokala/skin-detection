using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Skin_Cancer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartHome : ContentPage
    {
        public StartHome()
        {
            InitializeComponent();
        }

        public StartHome(string userID)
        {
            InitializeComponent();
            currentUserID.Text = userID;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page1());
        }
    }
}