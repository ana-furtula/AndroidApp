using AndroidMobileApp.Services;
using AndroidMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
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
            if(Username!=null && Password!=null && LastName!=null && Name!=null && Mail != null)
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
        }

    }
}
