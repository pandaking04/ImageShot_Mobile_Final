using MobileImage.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileImage.Models;
using MobileImage.APIs;

namespace MobileImage.ViewModels
{ 
class LoginViewModels : INotifyPropertyChanged
{
    public Login MyLogin { get; set; }

        ApiService apiService;

        public event PropertyChangedEventHandler PropertyChanged;
    string result;
    public string Result
    {
        get => result;
        set
        {
            result = value;
            var args = new PropertyChangedEventArgs(nameof(Result));
            PropertyChanged?.Invoke(this, args);
        }
    }
    public Command LoginCommand { get; }
    public Command RegisterCommand { get; }

    public LoginViewModels()
    {
        apiService = new ApiService();
        MyLogin = new Login();
        LoginCommand = new Command(async() =>
        {
            var response = await apiService.Login(MyLogin);
            if (response)
            {
                Result = "Success";
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                Result = "ชื่อหรือรหัสผ่านผิดโปรดกรอกข้อมูลอีกครั้ง";
            }
        });

        RegisterCommand = new Command(async () =>
        {
           await Application.Current.MainPage.Navigation.PushModalAsync(new Views.RegisterView());
        });
    }
}
}