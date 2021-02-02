using AndroidMobileApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AndroidMobileApp.ViewModels
{
    public class ProfileViewModel
    {
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public ProfileViewModel()
        {
            FullName = $"{LoginManager.Instance.LoggedUser.FirstName} {LoginManager.Instance.LoggedUser.LastName}";
            FirstName = LoginManager.Instance.LoggedUser.FirstName;
            LastName = LoginManager.Instance.LoggedUser.LastName;
            Username = LoginManager.Instance.LoggedUser.Username;
            Mail = LoginManager.Instance.LoggedUser.Email;
        }

    }
}
