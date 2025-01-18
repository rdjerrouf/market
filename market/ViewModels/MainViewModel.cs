using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace market.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            Items = new ObservableCollection<Item>(GetAllItems());
            SearchCommand = new RelayCommand<string>(SearchItems);
        }

        public ObservableCollection<Item> Items { get; }

        [ObservableProperty]
        private string searchQuery;

        public IRelayCommand<string> SearchCommand { get; }

        private void SearchItems(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                Items.Clear();
                foreach (var item in GetAllItems())
                {
                    Items.Add(item);
                }
            }
            else
            {
                var filteredItems = GetAllItems().Where(item => item.Name.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
                Items.Clear();
                foreach (var item in filteredItems)
                {
                    Items.Add(item);
                }
            }
        }

        private List<Item> GetAllItems()
        {
            // Replace this with your actual data fetching logic
            return new List<Item>
            {
                new Item { Name = "Item 1" },
                new Item { Name = "Item 2" },
                new Item { Name = "Item 3" },
                // Add more items here
            };
        }

        [RelayCommand]
        private void ForSale()
        {
            // Implement For Sale logic
        }

        [RelayCommand]
        private void Jobs()
        {
            // Implement Jobs logic
        }

        [RelayCommand]
        private void Services()
        {
            // Implement Services logic
        }

        [RelayCommand]
        private void Rentals()
        {
            // Implement Rentals logic
        }

        [RelayCommand]
        private void Home()
        {
            // Implement Home logic
        }

        [RelayCommand]
        private void Inbox()
        {
            // Implement Inbox logic
        }

        [RelayCommand]
        private void Post()
        {
            // Implement Post logic
        }

        [RelayCommand]
        private void MyListings()
        {
            // Implement My Listings logic
        }
    }

    public class Item
    {
        public string Name { get; set; }
    }
}
