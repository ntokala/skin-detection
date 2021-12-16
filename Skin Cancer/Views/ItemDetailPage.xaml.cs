using Skin_Cancer.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Skin_Cancer.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}