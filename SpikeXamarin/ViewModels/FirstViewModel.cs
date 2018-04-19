using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using SpikeXamarin.Domains.Entities;
using SpikeXamarin.Domains;
using SpikeXamarin.Infrastructures.Repositories.Http;
using System.Collections.Generic;

namespace SpikeXamarin.ViewModels
{
    public class FirstViewModel
    {
        private ObservableCollection<RepoEntity> items;

        public ObservableCollection<RepoEntity> Items
        {
            get { return items; }
            set { items = value; }
        }

        public FirstViewModel()
        {
            Items = new ObservableCollection<RepoEntity>();
            RefreshData();
        }

        public void OnAppearing()
        {


        }

        async void RefreshData()
        {
            var result = await new FirstDomain().fetch();
            foreach (var item in result.items)
            {
                Items.Add(item);
            }
        }
    }

    public static class ViewModelLocator
    {
        static FirstViewModel firstViewModel;

        public static FirstViewModel FirstViewModel
        {
            get
            {
                if (firstViewModel == null)
                {
                    var list = Enumerable.Range(0, 100).Select(n => new RepoEntity
                    {
                        Id = n,
                        Name = "Name" + n,
                        FullName = "FullName" + n,
                        Stars = n
                    });
                    firstViewModel = new FirstViewModel();
                    foreach (var item in list)
                    {
                        firstViewModel.Items.Add(item);
                    }
                }

                return firstViewModel;

            }
        }
    }
}
