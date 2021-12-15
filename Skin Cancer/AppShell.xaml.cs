using Skin_Cancer.ViewModels;
using Skin_Cancer.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Skin_Cancer
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
