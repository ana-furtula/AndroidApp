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
            SelfExaminationTests.Add(new SelfExaminationTest()
            {
                Name = "Self-examination test"
            });
            foreach (SelfExaminationTest test in tests)
            {
                SelfExaminationTests.Add(new SelfExaminationTest()
                {
                    Result = test.Result,
                    IssueDate = test.IssueDate
                });
            }
        }
        public ObservableCollection<SelfExaminationTest> SelfExaminationTests { get; set; }
    }
}
