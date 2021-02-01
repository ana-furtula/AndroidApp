using AndroidMobileApp.Services;
using AndroidMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AndroidMobileApp.ViewModels
{
    class RegisterViewModel : BaseViewModel
    {
        public Command RegisterCommand { get; }
        public Command CancelCommand { get; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
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
        public RegisterViewModel()
        {
            CancelCommand = new Command(OnCancelClicked);
            RegisterCommand = new Command(OnRegisterClicked);
        }

        private async void OnCancelClicked(object obj)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
        }

        private async void OnRegisterClicked(object obj)
        {
            IsActivityIndicatorActive = true;
            await Task.Delay(3000);
            if (Username!=null && Password!=null && LastName!=null && Name!=null && Mail != null)
            {
                User user = new User();
                user.Username = Username;
                user.Password = Password;
                user.LastName = LastName;
                user.FirstName = Name;
                user.Email = Mail;
                UserRepository.Instance.Register(user);
                await Application.Current.MainPage.Navigation.PushModalAsync(MasterDetailLPage.Instance);
            }
            else
            {
                Error = "Try again!";
                OnPropertyChanged(nameof(Error));
            }
            IsActivityIndicatorActive = false;
        }

    }
}
