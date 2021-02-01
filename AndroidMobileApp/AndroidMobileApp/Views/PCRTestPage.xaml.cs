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
    public partial class PCRTestPage : ContentPage
    {
        public PCRTestPage()
        {
            InitializeComponent();
            this.BindingContext = new PCRTestViewModel();
        }
    }
}