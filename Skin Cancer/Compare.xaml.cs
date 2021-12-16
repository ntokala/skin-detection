using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Skin_Cancer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Compare : ContentPage
    {
        public Compare()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await DisplayAlert("Melanoma", "Develops when melanocytes (the cells that give the skin its tan or brown color) start to grow out of control. Symptoms might include a new, unusual growth or a change in an existing mole. Melanomas can occur anywhere on the body.", "OK");
        }

        private async void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
            await DisplayAlert("Benign Keratosis-Like Lesion", "A noncancerous skin condition that appears as a waxy brown, black, or tan growth. Symptoms are these patches may appear suddenly, may vary in size, and tend to grow slowly. They may be round or oval-shaped, and vary in color from tan, yellowish-brown to black. They may be widespread over the trunk, back, and/or shoulders. ", "OK");
        }

        private async void Button_Clicked_2(System.Object sender, System.EventArgs e)
        {
            await DisplayAlert("Dermatofibroma", "Or histiocytomas, are common noncancerous (benign) skin growths. They are firm to hard, and they are skin-colored or slightly pigmented. Symptoms are they can be pink, gray, red or brown in color and may change color over the years. They are firm and often feel like a stone under the skin. When pinched from the sides, the top of the growth may dimple inward. They're usually painless but some may experience tenderness and itching. ", "OK");
        }

        private async void Button_Clicked_3(System.Object sender, System.EventArgs e)
        {
            await DisplayAlert("Basal Cell Carcinoma", "A type of skin cancer that most often develops on areas of skin exposed to the sun, such as the face. On brown and Black skin, basal cell carcinoma often looks like a bump that's brown or glossy black and has a rolled border. Symptoms are lesion, redness, loss of color, small bump, swollen blood vessels in the skin, or ulcers.", "OK");
        }

        private async void Button_Clicked_4(System.Object sender, System.EventArgs e)
        {
            await DisplayAlert("Actinic Keratosis", "A rough, scaly patch on the skin that develops from years of sun exposure. Since it can become cancerous it's usually removed as a precaution!", "OK");
        }

        private async void Button_Clicked_5(System.Object sender, System.EventArgs e)
        {
            await DisplayAlert("Vascular", "Vascular tumors of the skin may arise anywhere on the body and appear as a firm and raised lump on or under the skin. They may be red and look like a blood blister or may be the same color as the skin. Symptoms are they usually appear at or shortly after birth as faint areas of pinkish-red discoloration of the skin and then quickly undergo a period of rapid growth.", "OK");
        }

        private async void Button_Clicked_6(System.Object sender, System.EventArgs e)
        {
            await DisplayAlert("Melanocytic Nevus", "A usually noncancerous disorder of pigment-producing skin cells commonly called birth marks or moles.", "OK");
        }
    }
}
