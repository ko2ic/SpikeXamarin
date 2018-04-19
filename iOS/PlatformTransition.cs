using System;
using SpikeXamarin.iOS;
using SpikeXamarin.UserInterfaces;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PlatformTransition))]

namespace SpikeXamarin.iOS
{
    public class PlatformTransition : IPlatformTransition
    {
        public PlatformTransition()
        {
        }

        public void push()
        {
            var storyboard = UIStoryboard.FromName("Storyboard", null);
            var viewControlelr = storyboard.InstantiateInitialViewController();
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(viewControlelr, true, null);
        }
    }
}
