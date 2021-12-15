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
    public partial class Settings_View : ContentPage
    {
        public Settings_View()
        {
            InitializeComponent();
        }

        public Settings_View(string userID)
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
    }
}