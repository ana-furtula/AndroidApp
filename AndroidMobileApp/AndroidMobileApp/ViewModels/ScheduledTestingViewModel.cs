using AndroidMobileApp.Services;
using AndroidMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace AndroidMobileApp.ViewModels
{
    public class ScheduledTestingViewModel : BaseViewModel
    {
        public ObservableCollection<QuickTest> QuicksScheduled { get; set; }
        public string NoData { get; set; }
        public string NoDataImg { get; set; }
        public string IsNoDataImgVisible { get; set; }
        public ScheduledTestingViewModel()
        {
            IsNoDataImgVisible = "false";
            OnPropertyChanged(nameof(IsNoDataImgVisible));
            Title = "Scheduled tests";
            QuicksScheduled = new ObservableCollection<QuickTest>();
            List<QuickTest> qtests = LoginManager.Instance.LoggedUser.QuickTests;
            int signal = 0;
            foreach (QuickTest test in qtests)
            {
                if (test.IssueDate == null)
                {
                    signal = 1;
                    QuicksScheduled.Add(new QuickTest()
                    {
                        Name = "Quick test",
                        CheckedDate = test.CheckedDate.Date,
                        CheckedTime = test.CheckedTime
                    });
                }
            }
            if (signal == 0)
            {
                NoData = "You have not scheduled any tests.";
                OnPropertyChanged(nameof(NoData));
                IsNoDataImgVisible = "true";
                OnPropertyChanged(nameof(IsNoDataImgVisible));
            }
        }
    }
}
