using Skin_Cancer.Tables;
using Skin_Cancer.Views;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Skin_Cancer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);

            db.CreateTable<RegUserTable>();

            var item = new RegUserTable()
            {
                UserName = EntryUserName.Text,
                Password = EntryUserPassword.Text,
                Email = EntryUserEmail.Text,
                PhoneNumber = EntryUserPhoneNumber.Text
            };

            db.Insert(item);
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Congrats", "Registration Complete", "Contiune", "Cancel");

                if (result)
                    await Navigation.PopToRootAsync();
            });

        }

        
    }
}