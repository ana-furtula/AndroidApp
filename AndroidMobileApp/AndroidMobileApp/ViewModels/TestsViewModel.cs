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
            foreach(SelfExaminationTest test in tests)
            {
                SelfExaminationTests.Add(new SelfExaminationTest()
                {
                    Result = test.Result
                });
            }
        }
        public ObservableCollection<SelfExaminationTest> SelfExaminationTests { get; set; }
    }
}
