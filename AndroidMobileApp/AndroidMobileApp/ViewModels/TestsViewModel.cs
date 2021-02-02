using AndroidMobileApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AndroidMobileApp.ViewModels
{
    public class TestsViewModel : BaseViewModel
    {
        public TestsViewModel()
        {
            SelfExaminationTests = new ObservableCollection<SelfExaminationTest>();
            List<SelfExaminationTest> tests = LoginManager.Instance.LoggedUser.SelfExaminationTests;
            foreach (SelfExaminationTest test in tests)
            {
                SelfExaminationTests.Add(new SelfExaminationTest()
                {
                    Name = "Self-examination test",
                    Result = test.Result,
                    IssueDate = test.IssueDate
                });
            }

            QuickTests = new ObservableCollection<QuickTest>();
            List<QuickTest> qtests = LoginManager.Instance.LoggedUser.QuickTests;

            foreach (QuickTest test in qtests)
            {
                if (test.IssueDate != null)
                {
                    QuickTests.Add(new QuickTest()
                    {
                        Name = "Quick test",
                        Result = test.Result,
                        IssueDate = test.IssueDate
                    });
                }
            }
        }
        public ObservableCollection<SelfExaminationTest> SelfExaminationTests { get; set; }
        public ObservableCollection<QuickTest> QuickTests { get; set; }
    }
}
