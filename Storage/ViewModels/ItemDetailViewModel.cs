using System;
using Storage.Models;

namespace Storage.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public StorageBox Item { get; set; }
        public ItemDetailViewModel(StorageBox item = null)
        {
            Title = item?.BoxName;
            Item = item;
        }
    }
}
