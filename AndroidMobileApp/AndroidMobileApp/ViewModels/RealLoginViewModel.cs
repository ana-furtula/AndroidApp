using AndroidMobileApp.Services;
using AndroidMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
        private bool _isActivityIndicatorActive { get; set; }
        public bool IsActivityIndicatorActive
        {
            get
            {
                return _isActivityIndicatorActive;
            }
            set
            {
                if (_isActivityIndicatorActive != value)
                {
                    _isActivityIndicatorActive = value;
                    OnPropertyChanged(nameof(IsActivityIndicatorActive));
                    OnPropertyChanged(nameof(IsActivityIndicatorInactive));
                }
            }
        }
        public bool IsActivityIndicatorInactive => !IsActivityIndicatorActive;
        public RealLoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            CancelCommand = new Command(OnCancelClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            IsActivityIndicatorActive = true;
            await Task.Delay(3000);
            if (Username!=null && Password != null)
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
            IsActivityIndicatorActive = false;
        }

        private async void OnCancelClicked(object obj)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
        }

    }
}
