using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using SQLite;
using Skin_Cancer.Tables;

namespace Skin_Cancer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : TabbedPage
    {
        public Home()
        {
            InitializeComponent();
        }

        public Home(string userID)
        {
            
            InitializeComponent();

            currentUserID_1.Text = userID;
            currentUserID_2.Text = userID;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            currentUserID_1.Text = null;
            currentUserID_2.Text = null;
            Page current = this;
            Navigation.InsertPageBefore(new Page1(), current);
            Navigation.RemovePage(current);
        }

        private void Settings_Button(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Settings(currentUserID_2.Text));
        }

        private void Settings_View_Button(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Settings_View(currentUserID_2.Text));
        }
    }
}