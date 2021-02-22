using AndroidMobileApp.Services;
using AndroidMobileApp.Views;
using System.IO;
using Xamarin.Forms;

namespace AndroidMobileApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new LoginPage();
            var filePath = $"{Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "fajl.json")}";
            if (File.Exists(filePath) == false)
                File.Create(filePath);
            UserRepository.Instance.Load();
        }
        protected override void OnSleep()
        {
            UserRepository.Instance.Save();
        }

    }
}
