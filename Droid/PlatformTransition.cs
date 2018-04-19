using System;
using Android.Content;
using SpikeXamarin.Droid;
using SpikeXamarin.UserInterfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(PlatformTransition))]

namespace SpikeXamarin.Droid
{
    public class PlatformTransition : IPlatformTransition
    {
        public PlatformTransition()
        {
        }

        public void push()
        {
            var context = Android.App.Application.Context;
            context.StartActivity(new Intent(context, typeof(HogeActivity)));
        }
    }
}
