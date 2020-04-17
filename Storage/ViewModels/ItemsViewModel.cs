using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Storage.Models;
using Storage.Views;
using Xamarin.Forms;

namespace Storage.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<StorageBox> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<StorageBox>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewBoxPage, StorageBox>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as StorageBox;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);

                var test = Items;
                var breakpoint = 1;
            });

            
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

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
