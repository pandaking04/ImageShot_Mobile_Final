using MobileImage.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using MobileImage.APIs;
using Xamarin.Essentials;

namespace MobileImage.ViewModels
{
    class InsertProductViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Home insert { get; set; }
        public Command add { get; set; }
        ApiService apiService;
        public InsertProductViewModel()
        {
            apiService = new ApiService();
            insert = new Home();

            add = new Command(async() =>
            {
                insert.user_email = Preferences.Get("username", "");
                

             var response =  await apiService.AddProduct(insert);

                    await Application.Current.MainPage.DisplayAlert("Product", "Product added", "OK");

            });


        }
    }
 
}
