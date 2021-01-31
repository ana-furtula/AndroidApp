using AndroidMobileApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AndroidMobileApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}