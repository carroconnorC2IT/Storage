using System;
using System.Collections.Generic;
using Storage.Models;
using Xamarin.Forms;

namespace Storage.Views
{
    public partial class NewBoxPage : ContentPage
    {
        public StorageBox Item { get; set; }

        public NewBoxPage()
        {
            InitializeComponent();

            Item = new StorageBox
            {
                BoxName = "Item name",
                BoxLocation = "Basement"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
