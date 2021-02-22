using AndroidMobileApp.Services;

namespace AndroidMobileApp.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public ProfileViewModel()
        {
            Title = "Profile";
            FullName = $"{LoginManager.Instance.LoggedUser.FirstName} {LoginManager.Instance.LoggedUser.LastName}";
            FirstName = LoginManager.Instance.LoggedUser.FirstName;
            LastName = LoginManager.Instance.LoggedUser.LastName;
            Username = LoginManager.Instance.LoggedUser.Username;
            Mail = LoginManager.Instance.LoggedUser.Email;
        }

    }
}
