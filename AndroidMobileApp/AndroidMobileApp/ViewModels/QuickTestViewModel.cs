using AndroidMobileApp.Services;
using AndroidMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AndroidMobileApp.ViewModels
{
    class QuickTestViewModel : BaseViewModel
    {
        public Command CheckCommand { get; }
        public string MinDate { get; set; }
        public string MaxDate { get; set; }
        public string SelectedDate { get; set; }
        public TimeSpan SelectedTime { get; set; }
        public string Unavailable { get; set; }
        public string Available { get; set; }
        public QuickTestViewModel()
        {
            Title = "Quick test scheduling";
            MinDate = DateTime.Now.ToShortDateString();
            OnPropertyChanged(nameof(MinDate));
            MaxDate = (new DateTime(2021, 12, 31)).ToShortDateString();
            OnPropertyChanged(nameof(MaxDate));
            SelectedDate = MinDate;
            OnPropertyChanged(nameof(SelectedDate));
            CheckCommand = new Command(OnCheckClicked);
            SelectedTime = new TimeSpan(12, 0, 0);
        }
        private void OnCheckClicked(object obj)
        {
            DateTime enteredDate = DateTime.Parse(SelectedDate);
            TimeSpan enteredTime = SelectedTime;
            if (UserRepository.Instance.IsTerminAvailable(enteredDate, enteredTime))
            {
                Unavailable = " ";
                OnPropertyChanged(nameof(Unavailable));
                Available = "Done! Check Sheduled tests";
                OnPropertyChanged(nameof(Available));
                QuickTest test = new QuickTest();
                test.CheckedDate = enteredDate;
                test.CheckedTime = enteredTime;
                test.IssueDate = null;
                test.Result = QuickTestResult.Unknown;
                test.UserID = LoginManager.Instance.LoggedUser.ID;
                LoginManager.Instance.LoggedUser.QuickTests.Add(test);
                UserRepository.Instance.Save();
            }
            else
            {
                Available = " ";
                OnPropertyChanged(nameof(Available));
                Unavailable = "Unavailable! Try again!";
                OnPropertyChanged(nameof(Unavailable));
            }
            
        }
    }
}
