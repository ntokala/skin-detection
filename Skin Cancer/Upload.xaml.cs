using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using RestSharp;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Skin_Cancer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Upload : ContentPage
    {
        public Upload()
        {
            InitializeComponent();

        }

        public async void Button_Clicked(object sender, EventArgs e)
        {
            var photo = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Choose Image"
            });
            if (photo != null)
            {
                // Save file to device so there is a path
                var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                var client = new RestClient("http://ntntntnt.pythonanywhere.com/classifier");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddFile("image", newFile);
                IRestResponse response = client.Execute(request);

                var diffs = JsonConvert.DeserializeObject<Dictionary<string, int>>(response.Content);
                var maxKeyOnValue = diffs.Where(c => c.Value.Equals("val1")).Select(x => x.Key).Min();
                var maxK = diffs.FirstOrDefault(x => x.Value == diffs.Values.Min()).Key;

                Dictionary<string, string> com = new Dictionary<string, string>();
                com.Add("akiec", "Actinic Keratoses and Intraepithelial Carcinoma / Bowen's Disease");
                com.Add("bcc", "Basal Cell Carcinoma");
                com.Add("blk", "Benign Keratosis-Like Lesions");
                com.Add("df", "Dermatofibroma");
                com.Add("mel", "Melanoma");
                com.Add("nv", "Melanocytic Nevi");
                com.Add("vasc", "Vascular");

                string diagnosis = com[maxK];

                string report = String.Format(@"Our image processing model has determined that you case is closest to the {0} skin cancer type. It is important to understand that all diagnosis may not be exact. It is vital to consult with a doctor about any worries of possible skin cancer cases.To further understand the symptoms and general information about your disgnosis, visit the Confirmed Cases tab.", diagnosis);

                Application.Current.MainPage.DisplayAlert("Report", report, "Cancel");

                Console.WriteLine("test\n");
                Console.WriteLine(report);


            }
        }

        public async void Button_Clicked_1(object sender, EventArgs e)
        {
            var photo = await MediaPicker.CapturePhotoAsync();

            if (photo != null)
            {
                // Save file to device so there is a path
                var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                var client = new RestClient("http://ntntntnt.pythonanywhere.com/classifier");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddFile("image", newFile);
                IRestResponse response = client.Execute(request);

                var diffs = JsonConvert.DeserializeObject<Dictionary<string, int>>(response.Content);
                var maxKeyOnValue = diffs.Where(c => c.Value.Equals("val1")).Select(x => x.Key).Min();
                var maxK = diffs.FirstOrDefault(x => x.Value == diffs.Values.Min()).Key;

                Dictionary<string, string> com = new Dictionary<string, string>();
                com.Add("akiec", "Actinic Keratoses and Intraepithelial Carcinoma / Bowen's Disease");
                com.Add("bcc", "Basal Cell Carcinoma");
                com.Add("blk", "Benign Keratosis-Like Lesions");
                com.Add("df", "Dermatofibroma");
                com.Add("mel", "Melanoma");
                com.Add("nv", "Melanocytic Nevi");
                com.Add("vasc", "Vascular");

                string diagnosis = com[maxK];


                string report = String.Format(@"Our image processing model has determined that you case is closest to the {0} skin cancer type. It is important to understand that all diagnosis may not be exact. It is vital to consult with a doctor about any worries of possible skin cancer cases.To further understand the symptoms and general information about your disgnosis, visit the Confirmed Cases tab.", diagnosis);


            

                Application.Current.MainPage.DisplayAlert("Report", report, "Cancel");

                Console.WriteLine("test\n");
                Console.WriteLine(report);

                
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }


    }
}
