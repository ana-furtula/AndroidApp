using AndroidMobileApp.Services;
using AndroidMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            this.BindingContext = new ProfileViewModel();
        }

        private async void ChangePassword_Clicked(object sender, EventArgs e)
        {
            string oldPassword = await DisplayPromptAsync("Password Changing", "Enter your password", maxLength: 20, keyboard: Keyboard.Default);
            if (oldPassword.Equals(LoginManager.Instance.LoggedUser.Password))
            {
                string newPassword = await DisplayPromptAsync("Password Changing", "Enter new password", maxLength: 20, keyboard: Keyboard.Default);
                if (newPassword != null)
                {
                    LoginManager.Instance.LoggedUser.Password = newPassword;
                    await DisplayAlert("Notification", "Password changed successfully", "OK");
                }
                else
                {
                    await DisplayAlert("Notification", "Try again!", "OK");
                }
            }
            else
            {
                await DisplayAlert("Notification", "Try again!", "OK");
            }
        }
    }
}