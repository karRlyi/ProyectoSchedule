namespace ProyectoSchedule.UIForms.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using ProyectoSchedule.Common.Models;
    using ProyectoSchedule.UIForms.Views;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
   

    public class MainViewModel
    {
        private static MainViewModel instance;

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
        public TokenResponse Token { get; set; }
        public LoginViewModel Login { get; set; }
        public ClassroomsViewModel Classrooms { get; set; }

        public WeekdaysViewModel Weekdays { get; set; }
        public ICommand KarlaCommand => new RelayCommand(this.LoadKarla);
        public ICommand AdbCommand => new RelayCommand(this.LoadKarla);
        public ICommand AddCommand => new RelayCommand(this.LoadKarla);
        public MainViewModel()
        {
            instance = this;
            this.LoadMenus();
        }
       

        private async void LoadKarla()
        {
            await App.Navigator.PushAsync(new Aboutpage());
            
        }

        private void LoadMenus()
        {
            var menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "ic_watch_later",
                    PageName = "ClassroomsPage",
                    Title = "Classrooms"
                },
                new Menu
                {
                    Icon = "ic_perm_device_information",
                    PageName = "WeekdaysPage",
                    Title = "Weekdays"
                },

                new Menu
                {
                    Icon = "ic_phonelink_setup",
                    PageName = "SetupPage",
                    Title = "Setup"
                },
                new Menu
                {
                    Icon = "ic_perm_device_information",
                    PageName = "AboutPage",
                    Title = "About"
                },
                new Menu
                {
                    Icon = "ic_exit_to_app",
                    PageName = "LoginPage",
                    Title = "Close session"
                }
            };
            this.Menus = new ObservableCollection<MenuItemViewModel>(menus.Select(m => new MenuItemViewModel
            {
                Icon = m.Icon,
                PageName = m.PageName,
                Title = m.Title
            }).ToList());
        }

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
    }
}