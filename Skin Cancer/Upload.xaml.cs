using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Choose Image"
            });
            if (result != null)
            {
                var stream = await result.OpenReadAsync();

                resultImage.Source = ImageSource.FromStream(() => stream);

                

                var psi = new ProcessStartInfo();
                //psi.FileName = @"C:\Users\kendr\anaconda3\python.exe";

                var script = @"C:\Users\kendr\OneDrive\Desktop\skinny.py";
                var argv = new List<Image>();
                argv.Add(resultImage);

                psi.Arguments = $"\"{script}\"\"{argv}\"";

                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;

                var errors = "";
                var results = "";

                using (var process = Process.Start(psi))
                {
                    errors = process.StandardError.ReadToEnd();
                    results = process.StandardOutput.ReadToEnd();
                }


                Console.WriteLine("ERROS:");
                Console.WriteLine(errors);
                Console.WriteLine();
                Console.WriteLine("Results:");
                Console.WriteLine(results);



            }
        }

        async void Button_Clicked_1(object sender, EventArgs e)
        {
            var result = await MediaPicker.CapturePhotoAsync();

            if (result != null)
            {
                var stream = await result.OpenReadAsync();

                resultImage.Source = ImageSource.FromStream(() => stream);

                var psi = new ProcessStartInfo();
                psi.FileName = @"C:\Users\kendr\anaconda3\python.exe";

                var script = @"C:\Users\kendr\OneDrive\Desktop\skinny.py";
                var argv = new List<Image>();
                argv.Add(resultImage);

                psi.Arguments = $"\"{script}\"\"{argv}\"";

                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;

                var errors = "";
                var results = "";

                using (var process = Process.Start(psi))
                {
                    errors = process.StandardError.ReadToEnd();
                    results = process.StandardOutput.ReadToEnd();
                }


                Console.WriteLine("ERROS:");
                Console.WriteLine(errors);
                Console.WriteLine();
                Console.WriteLine("Results:");
                Console.WriteLine(results);
            }

        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }
    }
}