using ProyectoSchedule.Common.Models;
using ProyectoSchedule.Common.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ProyectoSchedule.UIForms.ViewModels
{
    public class WeekdaysViewModel : BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<Weekday> weekdays;
        public ObservableCollection<Weekday> Weekdays {
            get { return this.weekdays; }
            set { this.SetValue(ref this.weekdays, value); } }
        public WeekdaysViewModel()
        {
            this.apiService = new ApiService();
            this.LoadWeekdays();
        }

        private async void LoadWeekdays()
        {
            var response = await this.apiService.GetListAsync<Weekday>("https://proyectoscheduleweb20211013123107.azurewebsites.net","/api","/WeekDays");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message,
                    "Aceptar");
                return;
            }
            var myWeekdays = (List<Weekday>)response.Result;
            this.Weekdays = new ObservableCollection<Weekday>(myWeekdays);
        }
    }
}
