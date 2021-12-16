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

namespace Skin_Cancer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Upload : ContentPage
    {
        public Upload()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
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
                Console.WriteLine("test\n");
                Console.WriteLine(response.Content);
            }
        }

        async void Button_Clicked_1(object sender, EventArgs e)
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
                Console.WriteLine("test\n");
                Console.WriteLine(response.Content);
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }


    }
}