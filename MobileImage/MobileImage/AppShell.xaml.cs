using MobileImage.ViewModels;
using MobileImage.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MobileImage.APIs;

namespace MobileImage
{
    public partial class AppShell : Xamarin.Forms.Shell
    {

        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {

           
            await Shell.Current.GoToAsync($"///{nameof(Views.LoginPage)}");
           
        }
        
    }
}
