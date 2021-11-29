using GalaSoft.MvvmLight.Command;
using ProyectoSchedule.Common.Models;
using ProyectoSchedule.UIForms.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoSchedule.UIForms.ViewModels
{
    public class MenuItemViewModel : ProyectoSchedule.Common.Models.Menu
    {
        public ICommand SelectMenuCommand
        {
            get
            {
                return new RelayCommand(SelectMenu);
            }
        }

        private async void SelectMenu()
        {
            App.Master.IsPresented = false;
            var mainViewModel = MainViewModel.GetInstance();
            switch (this.PageName)
            {
                case "ClassroomsPage":
                    await App.Navigator.PushAsync(new ClassroomsPage());
                    break;
                case "WeekdaysPage":
                    await App.Navigator.PushAsync(new WeekdaysPage());
                    break;
                case "AboutPage":
                    await App.Navigator.PushAsync(new Aboutpage());
                    break;
                case "SetupPage":
                    await App.Navigator.PushAsync(new SetupPage());
                    break;
                default:
                    MainViewModel.GetInstance().Login = new LoginViewModel();
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                    break;
            }
        }
    }
}
