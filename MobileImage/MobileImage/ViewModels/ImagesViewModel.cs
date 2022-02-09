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
 [ContentProperty(nameof(Source))]
class ImagesViewModel : IMarkupExtension
{
    public string Source { get; set; }

    public object ProvideValue(IServiceProvider serviceProvider)
    {

        if (Source == null)
        {
            return null;
        }
        var imageSource = ImageSource.FromResource(Source, typeof(LoginViewModels).GetTypeInfo().Assembly);

        return imageSource;
    }
}
}
