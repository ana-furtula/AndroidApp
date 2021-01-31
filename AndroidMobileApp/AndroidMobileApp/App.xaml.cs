using AndroidMobileApp.Services;
using AndroidMobileApp.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            UserRepository.Instance.Save();
        }

        protected override void OnResume()
        {
        }
    }
}
