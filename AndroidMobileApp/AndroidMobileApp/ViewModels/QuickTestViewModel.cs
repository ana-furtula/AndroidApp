using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidMobileApp.ViewModels
{
    class QuickTestViewModel : BaseViewModel
    {
        public string MinDate { get; set; }
        public string MaxDate { get; set; }
        public string SelectedDate { get; set; }
        public string SelectedTime { get; set; }
        public QuickTestViewModel()
        {
            MinDate = DateTime.Now.ToShortDateString();
            OnPropertyChanged(nameof(MinDate));
            MaxDate = (new DateTime(2021, 12, 31)).ToShortDateString();
            OnPropertyChanged(nameof(MaxDate));
            SelectedDate = MinDate;
            OnPropertyChanged(nameof(SelectedDate));
        }
    }
}
