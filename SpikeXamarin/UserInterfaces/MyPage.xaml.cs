using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using SpikeXamarin.Domains.Entities;

namespace SpikeXamarin.UserInterfaces
{
    public partial class MyPage : ContentPage
    {

        ObservableCollection<RepoEntity> Items = new ObservableCollection<RepoEntity>();

        public MyPage()
        {
            InitializeComponent();

            this.listView.ItemsSource = Items;
        }

        protected override void OnAppearing(){
            var list = Enumerable.Range(0, 100).Select(n => new RepoEntity
            {
                Id = n,
                Name = "Name" + n,
                FullName = "FullName" + n,
                Stars = n
            });

            foreach (var item in list)
            {
                Items.Add(item);
            }
        }
    }
}
