using AndroidMobileApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AndroidMobileApp.ViewModels
{
    public class ScheduledTestingViewModel : BaseViewModel
    {
        public ObservableCollection<QuickTest> QuicksScheduled { get; set; }
        public ScheduledTestingViewModel()
        {
            QuicksScheduled = new ObservableCollection<QuickTest>();
            List<QuickTest> qtests = LoginManager.Instance.LoggedUser.QuickTests;
            QuicksScheduled.Add(new QuickTest()
            {
                Name = "Quick test"
            });
            foreach (QuickTest test in qtests)
            {
                if (test.IssueDate == null)
                {
                    QuicksScheduled.Add(new QuickTest()
                    {
                        CheckedDate = test.CheckedDate.Date,
                        CheckedTime = test.CheckedTime
                    }); 
                }
            }
        }
    }
}
