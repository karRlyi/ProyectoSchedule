namespace ProyectoSchedule.UIForms.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using ProyectoSchedule.Common.Models;
    using ProyectoSchedule.Common.Services;
    using ProyectoSchedule.UIForms.Views;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class ClassroomsViewModel : BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<Classroom> classrooms;
        public ObservableCollection<Classroom> Classrooms {
            get { return this.classrooms; }
            set { this.SetValue(ref this.classrooms, value); } }

        private bool isRefreshing;

        public bool IsRefreshing {
            get { return this.isRefreshing; } 
            set { this.SetValue(ref this.isRefreshing, value); } }


        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(this.LoadClassrooms);
            }
        }

        

        public ClassroomsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadClassrooms();
        }

        private async void LoadClassrooms()
        {
            this.IsRefreshing = true;
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await this.apiService.GetListAsync<Classroom>(url,
                 "/api",
                 "/Classrooms");
            //"bearer",
            //MainViewModel.GetInstance().Token.Token);
            this.IsRefreshing = false;
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error",response.Message,
                    "Aceptar");
                return;
            }
            var myClassrooms = (List<Classroom>)response.Result;
            this.Classrooms = new ObservableCollection<Classroom>(myClassrooms);
        }
    }
}
