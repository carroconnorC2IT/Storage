using System;
namespace Storage.Models
{
    public enum MenuItemType
    {
        Browse,
        About
    }
    public class MenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
