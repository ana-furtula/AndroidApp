using AndroidMobileApp.Models;
using AndroidMobileApp.ViewModels;
using AndroidMobileApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidMobileApp.Views
{
    public partial class ItemsPage : ContentPage
    {
     /*   ItemsViewModel _viewModel;*/

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = new ItemsViewModel();
        }

       

        /*protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }*/
    }
}