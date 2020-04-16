using System;
using System.Collections.Generic;
using Storage.Models;
using Xamarin.Forms;

namespace Storage.Views
{
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<Models.MenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<Models.MenuItem>
            {
                new Models.MenuItem {Id = MenuItemType.Browse, Title="Browse" },
                new Models.MenuItem {Id = MenuItemType.About, Title="About" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((Models.MenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}
