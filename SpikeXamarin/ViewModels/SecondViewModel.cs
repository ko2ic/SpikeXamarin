using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SpikeXamarin.ViewModels
{
    public class SecondViewModel
    {
        Action transitionDelegate;

        ICommand toPlattformTransition;
        public ICommand ToPlattformTransitionCommand
        {
            get { return toPlattformTransition; }
            set
            {
                if (toPlattformTransition == value)
                {
                    return;
                }
                toPlattformTransition = value;
            }
        }

        public SecondViewModel(Action transitionDelegate)
        {
            this.transitionDelegate = transitionDelegate;
            toPlattformTransition = new Command(ToPlattformTransition);
        }

        void ToPlattformTransition()
        {
            System.Diagnostics.Debug.WriteLine("ToPlattformTransition");
            transitionDelegate.Invoke();
        }
    }
}
