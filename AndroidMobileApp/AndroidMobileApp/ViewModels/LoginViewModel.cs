using AndroidMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.IO;

namespace AndroidMobileApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new RealLoginPage());
        }

        private async void OnRegisterClicked(object obj)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new RegisterPage());
        }
    }
}
