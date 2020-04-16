using System;
using System.Collections.Generic;
using Storage.Models;
using Storage.ViewModels;
using Xamarin.Forms;

namespace Storage.Views
{
    public partial class BoxesPage : ContentPage
    {
        ItemsViewModel viewModel;

        public BoxesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as StorageBox;
            if (item == null)
                return;

            await Navigation.PushAsync(new BoxDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewBoxPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
