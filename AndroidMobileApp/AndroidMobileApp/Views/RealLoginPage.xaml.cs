﻿using AndroidMobileApp.ViewModels;
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
    public partial class RealLoginPage : ContentPage
    {
        public RealLoginPage()
        {
            InitializeComponent();
            this.BindingContext = new RealLoginViewModel();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}