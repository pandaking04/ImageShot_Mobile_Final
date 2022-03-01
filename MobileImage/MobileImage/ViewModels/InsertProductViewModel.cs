using MobileImage.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using MobileImage.APIs;
using Xamarin.Essentials;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace MobileImage.ViewModels
{
    class InsertProductViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Home insert { get; set; }
        public Command add { get; set; }
        public Command selectpic { get; set; }
        public MediaFile mediafile
        {
            get => mymf;
            set
            {
                mymf = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("mediafile"));
            }
        }
        private MediaFile mymf;
        ApiService apiService;
        public InsertProductViewModel()
        {
            apiService = new ApiService();
            insert = new Home();
            //mediafile = new MediaFile();

            add = new Command(async() =>
            {
                insert.user_email = Preferences.Get("username", "");
                

             var response =  await apiService.AddProduct(insert);

                    await Application.Current.MainPage.DisplayAlert("Product", "Product added", "OK");

            });

            selectpic = new Command(async () =>
            {
                await CrossMedia.Current.Initialize();

                mediafile = await CrossMedia.Current.PickPhotoAsync();

                if (mediafile == null)
                    return;
                await apiService.Addpic(mediafile);
                //insert.pic = mediafile;

                //mediafile = ImageSource.FromStream

            });
        }
    }
 
}
