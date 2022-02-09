using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using MobileImage.Models;
namespace MobileImage.ViewModels
{
    class HomeViewModel
    {
        public ObservableCollection<Home> MyListProduct { get; }
        public Command SelectCommand { get; set; }
        public Home SelectedProduct { get; set; }
        public Command BackCommand { get; }
        public HomeViewModel()
        {
            

            MyListProduct = new ObservableCollection<Home>();
            MyListProduct.Add(new Home
            {
                ID = 1,
                Name = "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops",
                Description = "Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday",
                Price = 100,
                Url = new Uri("https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg")
            });

            MyListProduct.Add(new Home
            {
                ID = 2,
                Name = "Mens Casual Premium Slim Fit T-Shirts",
                Description = "Slim-fitting style, contrast raglan long sleeve, three-button henley placket",
                Price = 200,
                Url = new Uri("https://fakestoreapi.com/img/71-3HjGNDUL._AC_SY879._SX._UX._SY._UY_.jpg")
            });

            MyListProduct.Add(new Home
            {
                ID = 3,
                Name = "Mens Cotton Jacket",
                Description = "great outerwear jackets for Spring/Autumn/Winter, suitable for many occasions, such as working, hiking, camping",
                Price = 300,
                Url = new Uri("https://fakestoreapi.com/img/71li-ujtlUL._AC_UX679_.jpg")
            });

            SelectCommand = new Command(async () =>

            {
                var ttt = new { SelectedProduct, BackCommand = BackCommand };
                var ProdDetail = new Views.ProductDetailsView
                {
                    BindingContext = new { SelectedProduct, BackCommand = BackCommand }
                };
                await Application.Current.MainPage.Navigation.PushModalAsync(ProdDetail);
            });

            BackCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            });

            

        }
        private void Search1_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

    }

}