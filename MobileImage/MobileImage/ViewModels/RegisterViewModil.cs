using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using MobileImage.Models;

namespace MobileImage.ViewModels
{
    class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Register Register { get; set; }
        public Command RegisterCommand { get; }
        public Command BackCommand { get; }
        public RegisterViewModel()
        {
            BackCommand = new Command( () => {
                 Application.Current.MainPage = new Views.LoginPage();
            });
        }
    }
}
