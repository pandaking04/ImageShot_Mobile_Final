using MobileImage.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MobileImage.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}