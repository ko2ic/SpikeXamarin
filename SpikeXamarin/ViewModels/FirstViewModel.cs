using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using SpikeXamarin.Domains.Entities;
using SpikeXamarin.Domains;
using SpikeXamarin.Infrastructures.Repositories.Http;
using System.Collections.Generic;
using System.Windows.Input;
using PropertyChanged;

namespace SpikeXamarin.ViewModels
{
    public class FirstViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ICommand search;

        public string SearchText { get; set; }
        public void OnSearchTextChanged()
        {
            System.Diagnostics.Debug.WriteLine(SearchText);
        }


        private ObservableCollection<RepoEntity> items;
        public ObservableCollection<RepoEntity> Items
        {
            get { return items; }
            set { items = value; }
        }

        public ICommand SearchCommand
        {
            get { return search; }
            set
            {
                if (search == value)
                {
                    return;
                }
                search = value;
            }
        }

        public FirstViewModel()
        {
            Items = new ObservableCollection<RepoEntity>();
            search = new Command(Search);
            RefreshData("ko2", 1);
        }

        public void Search()
        {
            RefreshData(SearchText, 1);
        }

        public void OnAppearing()
        {
        }

        async void RefreshData(string freeword, int pageNo)
        {
            var result = await new FirstDomain().fetch(freeword, 1);
            if (result != null)
            {
                Items.Clear();
                foreach (var item in result.items)
                {
                    Items.Add(item);
                }
            }
        }
    }

    // previewr用だけど動かない
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
