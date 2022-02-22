using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using MobileImage.Models;
using MobileImage.Views;
using System.ComponentModel;
using MobileImage.APIs;
using Xamarin.Essentials;

namespace MobileImage.ViewModels
{
    class CartViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ApiService apiService;


        
        public Command LogoutCommand { get; }

        public ObservableCollection<UserCollection> Orders
        {
            get
            {
                return myorders;
            }
            set
            {
                myorders = value;
                var args = new PropertyChangedEventArgs(nameof(Orders));
                PropertyChanged?.Invoke(this, args);
            }
        }
        ObservableCollection<UserCollection> myorders;

        public CartViewModel()
        {
            apiService = new ApiService();
            Orders = new ObservableCollection<UserCollection>();

            GetCart();


            LogoutCommand = new Command(async () =>
            {
                var response = await apiService.Logout();
                if (response)
                {
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                }
            });
        }
        async void GetCart()
        {
            Orders = await apiService.GetUserOrders();
        }

    }
}
