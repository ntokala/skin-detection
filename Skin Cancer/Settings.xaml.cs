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
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        public Settings(string userID)
        {
            InitializeComponent();
            currentUserID.Text = userID;


            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);

            var myquery = db.Table<RegUserTable>().Where(u => u.UserID.Equals(currentUserID.Text)).FirstOrDefault();

            if (myquery != null)
            {
                userName.Text = myquery.UserName;
                password.Text = myquery.Password;
                email.Text = myquery.Email;
                phoneNumber.Text = myquery.PhoneNumber;
            }

        }

        private void Update_Information_Button(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);

            var myquery = db.Table<RegUserTable>().Where(u => u.UserID.Equals(currentUserID.Text)).FirstOrDefault();

            if ((myquery.UserName == userName.Text) && (myquery.Password == password.Text) && (myquery.Email == email.Text) && (myquery.PhoneNumber == phoneNumber.Text))
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Error", "No information was updated.", "Try Again", "Cancel");
                });
            }
            else
            {
                if (myquery.UserName != userName.Text) { db.Execute("UPDATE RegUserTable SET UserName = ? WHERE UserID = ?", userName.Text, currentUserID.Text); }
                if (myquery.Password != password.Text) { db.Execute("UPDATE RegUserTable SET Password = ? WHERE UserID = ?", password.Text, currentUserID.Text); }
                if (myquery.Email != email.Text) { db.Execute("UPDATE RegUserTable SET Email = ? WHERE UserID = ?", email.Text, currentUserID.Text); }
                if (myquery.PhoneNumber != phoneNumber.Text) { db.Execute("UPDATE RegUserTable SET PhoneNumber = ? WHERE UserID = ?", phoneNumber.Text, currentUserID.Text); }

                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Success", "Your account information was updated successfully.", "Return to homepage", " ");

                    if (result)
                        await Navigation.PopAsync();
                    else
                    {
                        await Navigation.PopAsync();
                        //await Navigation.PushAsync(new Home());
                    }
                });
            }
        }
    }
}