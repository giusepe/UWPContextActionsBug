using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace UWPContextActionsBug
{
    public class ListItemViewModel
    {
        public ListItemViewModel()
        {
            ToggleMarkAsRead = new Command(toggleIsRead, CanExecute);
            Remove = new Command(remove, CanExecute);
        }

        public string Description { get { return $"This is desc of item {Number}."; } }

        public string IsRead { get; set; } = "No";

        public int Number { get; set; }

        public Command ToggleMarkAsRead { get; set; }

        public Command Remove { get; set; }

        public bool CanExecute()
        {
            return true;
        }

        private void toggleIsRead()
        {
            IsRead = ((IsRead == "Yes") ? "No" : "Yes");
            MessagingCenter.Send<ListItemViewModel, int>(this, "update", Number);
        }

        private void remove()
        {
            MessagingCenter.Send<ListItemViewModel, ListItemViewModel>(this, "remove", this);
        }
    }
}