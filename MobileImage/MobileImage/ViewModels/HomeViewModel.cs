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
using System.Windows.Input;
using System.Linq;

namespace MobileImage.ViewModels
{
    class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Home> MyListProduct
        {
            get
            {
                return myproducts;
            }
            set
            {
                myproducts = value;
                var args = new PropertyChangedEventArgs(nameof(MyListProduct));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public ObservableCollection<Home> myproducts;
        public ObservableCollection<Home> mySearch;
        public Command SelectCommand { get; set; }
        public Home SelectedProduct { get; set; }
        public Command BackCommand { get; }
        public Command AddCommand { get; set; }
        public Search sSearch { get; set; }
        public ICommand SearchCommand { get;}

        ApiService apiService;

        public HomeViewModel()
        {
            
            apiService = new ApiService();
            MyListProduct = new ObservableCollection<Home>();
            sSearch = new Search();

            GetProduct();

            SelectCommand = new Command(async () =>

            {
                var ttt = new { SelectedProduct, BackCommand = BackCommand, AddCommand = AddCommand };
                var ProdDetail = new ProductDetailsView
                {
                    BindingContext = ttt
                };
                await Application.Current.MainPage.Navigation.PushModalAsync(ProdDetail);
            });

            BackCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            });

            SearchCommand = new Command( () =>
            {
                MyListProduct = new ObservableCollection<Home>(mySearch.Where(x => x.Name.ToLower().Contains(sSearch.S.Trim().ToLower()) || x.Type.ToLower().Contains(sSearch.S.Trim().ToLower())));
            });

            AddCommand = new Command(async () =>
            {
                bool check = await Application.Current.MainPage.DisplayAlert("Order", "Please transfer" + SelectedProduct.Price + " Bath " + 
                    "to ImageShot Bank at XXX-XXXX-XXX", "Yes", "No");
                if(check == true) { 
                UserCollection Order = new UserCollection();
                Order.Name = SelectedProduct.Name;
                Order.picid = SelectedProduct.Pic_ID;
                Order.Price = SelectedProduct.Price;
                Order.Desc = SelectedProduct.Desc;
                Order.Size = SelectedProduct.Size;
                Order.Type = SelectedProduct.Type;
                Order.url = SelectedProduct.url;
                Order.user_email = Preferences.Get("username", "");
                var response = await apiService.AddOrder(Order);
                if (response)
                {
                    await Application.Current.MainPage.DisplayAlert("Order", "Order added", "OK");
                }
}
            });

        }
        async void GetProduct()
        {
            MyListProduct = await apiService.GetProducts();
            mySearch = myproducts;
        }

    }

}