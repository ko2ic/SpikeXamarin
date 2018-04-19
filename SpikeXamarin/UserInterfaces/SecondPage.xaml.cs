using System;
using System.Collections.Generic;

using Xamarin.Forms;

using SpikeXamarin.ViewModels;

namespace SpikeXamarin.UserInterfaces
{
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();

            BindingContext = new SecondViewModel(() =>
            {
                //Navigation.PushAsync(new FirstPage());
                var platform = DependencyService.Get<IPlatformTransition>();
                platform.push();
            });
        }
    }
}
