using AndroidMobileApp.Services;
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
        public void SetDetailPage(Page page)
        {
            Detail = new NavigationPage(page);
            IsPresented = false;
        }

        private void Button_Clicked1(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new AboutPage());
            IsPresented = false;
        }
        private void Button_Clicked2(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ItemsPage());
            IsPresented = false;
        }
        private void Button_Clicked3(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new TestsPage());
            UserRepository.Instance.CheckQuickTests(LoginManager.Instance.LoggedUser);
            IsPresented = false;
        }
        private void Button_Clicked4(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ScheduledTestingPage());
            IsPresented = false;
        }
    }
}