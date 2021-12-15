using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Skin_Cancer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindDoctor : ContentPage
    {

        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));


        public FindDoctor()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}