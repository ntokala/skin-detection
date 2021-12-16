using Skin_Cancer.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Skin_Cancer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);

            var myquery = db.Table<RegUserTable>().Where(u => u.UserName.Equals(txtUsername.Text) && u.Password.Equals(txtPassword.Text)).FirstOrDefault();

            if (myquery != null)
            {
                App.Current.MainPage = new NavigationPage(new Home(myquery.UserID.ToString()));
            }
            else {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Sorry", "Username or Password Incorrect", "Try Again", "Cancel");

                    if (result)
                        await Navigation.PopToRootAsync();
                    else
                    {
                        await Navigation.PopToRootAsync();
                    }
                });
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registration());
        }
    }
}