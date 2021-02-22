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
            Title = "Test results";
            SelfExaminationTests = new ObservableCollection<SelfExaminationTest>();
            List<SelfExaminationTest> tests = LoginManager.Instance.LoggedUser.SelfExaminationTests;
            if (tests == null || tests.Count == 0)

            {
                NoSETests = "You have not done any self-examination tests yet.";
                NoSEDataImg = "noData.png";
                OnPropertyChanged(nameof(NoSEDataImg));
                OnPropertyChanged(nameof(NoSETests));
            }
            else
            {
                foreach (SelfExaminationTest test in tests)
                {
                    SelfExaminationTests.Add(new SelfExaminationTest()
                    {
                        Name = "Self-examination test",
                        Result = test.Result,
                        IssueDate = test.IssueDate
                    });
                }
            }

            QuickTests = new ObservableCollection<QuickTest>();
            List<QuickTest> qtests = LoginManager.Instance.LoggedUser.QuickTests;
            int signal = 0;
            foreach (QuickTest test in qtests)
            {
                if (test.IssueDate != null)
                {
                    signal = 1;
                    QuickTests.Add(new QuickTest()
                    {
                        Name = "Quick test",
                        Result = test.Result,
                        IssueDate = test.IssueDate
                    });
                }
            }
            if (signal == 0)
            {
                NoQTests = "You have not done any quick tests yet.";
                OnPropertyChanged(nameof(NoQTests));
                NoQDataImg = "noData.png";
                OnPropertyChanged(nameof(NoQDataImg));
            }

        }
        public ObservableCollection<SelfExaminationTest> SelfExaminationTests { get; set; }
        public ObservableCollection<QuickTest> QuickTests { get; set; }
        public string NoSETests { get; set; }
        public string NoQTests { get; set; }
        public string NoSEDataImg { get; set; }
        public string NoQDataImg { get; set; }
        public string SEEndingLineImg { get; set; }
        public string QEndingLineImg { get; set; }
    }
}
