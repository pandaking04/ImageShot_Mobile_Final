using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using MobileImage.Models;
using MobileImage.APIs;

namespace MobileImage.ViewModels
{
    class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Register Register { get; set; }
        public Command RegisterCommand { get; }
        public Command BackCommand { get; }

        ApiService apiService;

        public RegisterViewModel()
        {
            apiService = new ApiService();
            Register = new Register();

            BackCommand = new Command(async () => {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            });

            RegisterCommand = new Command(async () =>
            {
                var response = await apiService.Register(Register);
                if (response)
                {
                    await Application.Current.MainPage.DisplayAlert("Register", "Register Success", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Register", "Register fail", "OK");
                }
            });
        }
    }
}
