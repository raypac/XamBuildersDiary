using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using XamBuildersDiary.Models;
using XamBuildersDiary.Views;

namespace XamBuildersDiary.ViewModels
{
    public class SiteDiariesViewModel : BaseViewModel
    {
        public ObservableCollection<SiteDiary> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public SiteDiariesViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<SiteDiary>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}