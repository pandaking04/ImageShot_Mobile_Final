using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileImage.Models;
using System.Collections.ObjectModel;
using MobileImage.ViewModels;

namespace MobileImage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        public Command SelectCommand { get; set; }
        

        //ObservableCollection<Home> myList;
        public HomeView()
        {
            InitializeComponent();
            
            
            //myList = new ObservableCollection<Home>
            //{
            //    new Home{Name="Iphone 12", Desc="u1",Price=100,url= new Uri("https://i.pinimg.com/736x/1c/a2/97/1ca297d63ed578653047bf8c344cefe4.jpg")},
            //    new Home{Name="Iphone 13", Desc="Background",Price=150,url= new Uri("https://i.pinimg.com/564x/59/41/9b/59419bd00a08bb511975f28c752ba1cc.jpg")},
            //    new Home{Name="y2", Desc="y2",Price=200,url= new Uri("https://i.pinimg.com/736x/59/b8/56/59b856f036f4b85209fe91bfd89e2061.jpg")},
            //    new Home{Name="z3", Desc="z3",Price=300,url= new Uri("https://i.pinimg.com/564x/36/79/53/36795332e68e076818b18769bad53c6a.jpg")}
            //};
            //Coill.ItemsSource = myList;
        }



        //private void MainListView_Refreshing(object sender, EventArgs e)
        //{

        //}

        //private void Search1_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    var searchresult = myList.Where(c => c.Name.ToLower().Contains(Search1.Text.ToLower()));
        //    Coill.ItemsSource = searchresult;
        //}
    }
}