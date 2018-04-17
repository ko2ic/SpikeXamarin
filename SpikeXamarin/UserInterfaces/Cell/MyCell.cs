using System;
using Xamarin.Forms;

namespace SpikeXamarin.UserInterfaces.Cell
{
    public class MyCell : ViewCell
    {
        public static readonly BindableProperty NameProperty = BindableProperty.Create("Name", typeof(string), typeof(MyCell), "Name");
        public static readonly BindableProperty StarsProperty = BindableProperty.Create("Stars", typeof(int), typeof(MyCell), 0);

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public int Stars
        {
            get { return (int)GetValue(StarsProperty); }
            set { SetValue(StarsProperty, value); }
        }

        public MyCell()
        {
            var nameLabel = new Label
            {
                Style = Device.Styles.TitleStyle,
                VerticalOptions = LayoutOptions.Center,
            };
            nameLabel.SetBinding(Label.TextProperty, "Name");
            var starsLabel = new Label
            {
                TextColor = Color.Navy,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.End
            };
            starsLabel.SetBinding(Label.TextProperty, new Binding("Stars", stringFormat: "{0}"));

            View = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(32, 4, 32, 4),
                Children =
                    {
                        nameLabel,
                        starsLabel,
                    },
            };
        }

    }
}
