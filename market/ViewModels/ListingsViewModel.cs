using System.Collections.ObjectModel;
using market.Models;
namespace market.ViewModels
{
    public class ListingsViewModel  // Ensure this is public
    {
        public ObservableCollection<Item> Items { get; set; }

        public ListingsViewModel()
        {
            Items = new ObservableCollection<Item>
            {
                new Item { Id = 1, Name = "Item 1", Description = "Description 1", Price = 10.0m },
                new Item { Id = 2, Name = "Item 2", Description = "Description 2", Price = 20.0m }
            };
        }
    }
}
