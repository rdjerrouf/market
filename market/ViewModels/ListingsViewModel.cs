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
               
            };
        }
    }
}
