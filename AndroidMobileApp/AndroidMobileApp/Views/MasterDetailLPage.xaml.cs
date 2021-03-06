﻿using AndroidMobileApp.Services;
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
    public partial class MasterDetailLPage : MasterDetailPage
    {
        private static MasterDetailLPage _instance;
        private MasterDetailLPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new ItemsPage());
            IsPresented = false;
        }
        public static MasterDetailLPage Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MasterDetailLPage();
                }

                return _instance;
            }
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        public void SetDetailPage(Page page)
        {
            Detail = new NavigationPage(page);
            IsPresented = false;
        }

        private void About_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new AboutPage());
            IsPresented = false;
        }
        private void Tests_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ItemsPage());
            IsPresented = false;
        }
        private void Results_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new TestsPage());
            UserRepository.Instance.CheckQuickTests(LoginManager.Instance.LoggedUser);
            IsPresented = false;
        }
        private void Scheduled_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ScheduledTestingPage());
            IsPresented = false;
        }

        private async void LogOut_Clicked(object sender, EventArgs e)
        {
            UserRepository.Instance.Save();
            _instance = new MasterDetailLPage();
            LoginManager.Instance.LoggedUser = null;
            await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
        }
    }
}