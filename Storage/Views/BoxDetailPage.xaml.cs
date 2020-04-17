using System;
using System.Collections.Generic;
using Storage.Models;
using Storage.ViewModels;
using Xamarin.Forms;

namespace Storage.Views
{
    public partial class BoxDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public BoxDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public BoxDetailPage()
        {
            InitializeComponent();

            List<string> freshItemsList = new List<string>();
            freshItemsList.Add("mirror");
            freshItemsList.Add("dresser");
            freshItemsList.Add("jewelry");

            var item = new StorageBox
            {
                BoxName = "Item 1",
                BoxLocation = "This is an item description.",
                //ItemsInBox = freshItemsList
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}
