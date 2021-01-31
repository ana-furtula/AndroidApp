using AndroidMobileApp.Services;
using AndroidMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AndroidMobileApp.ViewModels
{
    class RealLoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command CancelCommand { get; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Error { get; set; }
        public RealLoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            CancelCommand = new Command(OnCancelClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            if(Username!=null && Password != null)
            {
                LoginData loginData = new LoginData();
                loginData.Username = Username;
                loginData.Password = Password;

                var user = UserRepository.Instance.GetUserByCredentials(loginData);
                if (user != null)
                {
                    LoginManager.Instance.LoggedUser = user;
                    await Application.Current.MainPage.Navigation.PushModalAsync(MasterDetailLPage.Instance);
                }
                else
                {
                    Error = "Wrong username or password!";
                    OnPropertyChanged(nameof(Error));
                }
            }
            else
            {
                Error = "Wrong username or password!";
                OnPropertyChanged(nameof(Error));
            }
           
        }

        private async void OnCancelClicked(object obj)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
        }

    }
}
