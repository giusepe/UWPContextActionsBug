using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace UWPContextActionsBug
{
    public class MainPageViewModel
    {
        private const int initialItems = 3;
        private int newItemNumber = 1;

        public MainPageViewModel()
        {
            MessagingCenter.Subscribe<ListItemViewModel, int>(this, "update", (sender, arg) => updateAnItem(arg));
            MessagingCenter.Subscribe<ListItemViewModel, ListItemViewModel>(this, "remove", (sender, arg) => removeAnItem(arg));

            AddListItemCommand = new Command(addListItem);
            for (int i = 0; i < initialItems; i++)
            {
                ItemCollection.Add(new ListItemViewModel() { Number = newItemNumber });
                newItemNumber++;
            }
        }

        public ObservableCollection<ListItemViewModel> ItemCollection { get; set; } = new ObservableCollection<ListItemViewModel>();
        public Command AddListItemCommand { get; set; }

        private void updateAnItem(int number)
        {
            var currVm = ItemCollection.FirstOrDefault(vm => vm.Number == number);
            var indexOfVM = ItemCollection.IndexOf(currVm);
            ItemCollection[indexOfVM] = new ListItemViewModel
            {
                Number = currVm.Number,
                IsRead = currVm.IsRead
            };
        }

        private void removeAnItem(ListItemViewModel item)
        {
            ItemCollection.Remove(item);
        }

        private void addListItem()
        {
            var newItem = new ListItemViewModel() { Number = newItemNumber };
            newItemNumber++;
            ItemCollection.Add(newItem);
        }
    }
}
