using AndroidMobileApp.ViewModels;
using Xamarin.Forms;

namespace AndroidMobileApp.Views
{
    public partial class ItemsPage : ContentPage
    {
        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = new ItemsViewModel();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}