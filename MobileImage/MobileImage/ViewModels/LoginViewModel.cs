using MobileImage.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileImage.Models;

namespace MobileImage.ViewModels
{ 
class LoginViewModels : INotifyPropertyChanged
{
    public Login MyLogin { get; set; }

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
        MyLogin = new Login();
        LoginCommand = new Command(() =>
        {
            if (MyLogin.Email == "s@s.com" && MyLogin.Password == "1234")
            {
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                Result = "ชื่อหรือรหัสผ่านผิดโปรดกรอกข้อมูลอีกครั้ง";
            }
        });

        RegisterCommand = new Command( () =>
        {
            Application.Current.MainPage = new Views.RegisterView();
        });
    }
}
}