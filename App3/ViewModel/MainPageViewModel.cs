using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App3.Base;
using App3.Command;
using App3.Models;
using Windows.UI.Xaml.Controls;

namespace App3.ViewModel
{
    public class MainPageViewModel : NotificationObject
    {
        private ObservableCollection<MenuItem> menuItems;
        private string _hamburgTitle;
        private bool isPaneOpen;
        private bool canChangedPanelState;
        public DelegateCommand HamburgButtonCommand { get; private set; }

        public bool IsPaneOpen
        {
            get { return isPaneOpen; }
            set
            {
                isPaneOpen = value;
                OnPropertyChanged();
            }
        }
        public string HamburgTitle
        {
            get { return _hamburgTitle; }
            set
            {
                _hamburgTitle = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<MenuItem> MenuItems
        {
            get
            {
                return menuItems;
            }
            set
            {
                menuItems = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel()
        {
            canChangedPanelState = true;
            MenuItems = new ObservableCollection<MenuItem>()
            {
                 new MenuItem() { Icon=Symbol.People,Text="People"},
                 new MenuItem() { Icon=Symbol.Phone,Text="Phone" },
                 new MenuItem() { Icon=Symbol.Message, Text="Message"},
                 new MenuItem() { Icon=Symbol.Mail,Text="Mail"}
            };
            HamburgTitle = "Test";
            HamburgButtonCommand = new DelegateCommand();
            HamburgButtonCommand.ExecteCommand += ChangedPanelState;
            HamburgButtonCommand.CanExecuteCommand += CanChangePanelState;

        }

        private void ChangedPanelState(object para)
        {
            IsPaneOpen = IsPaneOpen ? false : true;
        }

        private bool CanChangePanelState(object para)
        {
            return canChangedPanelState;
        }

    }
}
