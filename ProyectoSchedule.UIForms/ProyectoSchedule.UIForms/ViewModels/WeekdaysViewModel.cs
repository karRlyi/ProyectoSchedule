using ProyectoSchedule.Common.Models;
using ProyectoSchedule.Common.Services;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;

namespace ProyectoSchedule.UIForms.ViewModels
{
    public class WeekdaysViewModel : BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<Weekday> weekdays;
        public ObservableCollection<Weekday> Weekdays
        {
            get { return this.weekdays; }
            set { this.SetValue(ref this.weekdays, value); }
        }

        private bool isRefreshing;

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }


        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(this.LoadClassrooms);
            }
        }



        public WeekdaysViewModel()
        {
            this.apiService = new ApiService();
            this.LoadClassrooms();
        }

        private async void LoadClassrooms()
        {
            this.IsRefreshing = true;
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await this.apiService.GetListAsync<Weekday>(
                url,
                "/api",
                "/Weekdays",
                "bearer",
                MainViewModel.GetInstance().Token.Token);
            this.IsRefreshing = false;
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }
            var myWeekdays = (List<Weekday>)response.Result;
            this.Weekdays = new ObservableCollection<Weekday>(myWeekdays);
        }
    }
}
