namespace ProyectoSchedule.UIForms.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using ProyectoSchedule.UIForms.Views;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand { 
        get
            {
                return new RelayCommand(Login);
            }
        }
        public LoginViewModel()
        {
            this.Email = "karla.ramos@gmail.com";
            this.Password = "123456";
        }
        private async void Login()
        {
            if(string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                    "Debes introducir un Email",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                    "Debes introducir un contraseña",
                    "Aceptar");
                return;
            }
            if(!this.Email.Equals("karla.ramos@gmail.com")||!this.Password.Equals("123456"))
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                    "Email o Contraseña incorrecto",
                    "Aceptar");
                return;
            }
            //await Application.Current.MainPage.DisplayAlert("OK", "Listo", "Aceptar");
            //return;
            MainViewModel.GetInstance().Classrooms = new ClassroomsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ClassroomsPage());

            MainViewModel.GetInstance().Weekdays = new WeekdaysViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new WeekdaysPage());
        }
    }
}