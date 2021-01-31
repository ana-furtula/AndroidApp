using AndroidMobileApp.Services;
using AndroidMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AndroidMobileApp.ViewModels
{
    class SelfExaminationTestViewModel : BaseViewModel
    {

        public Command SubmitClicked_Command { get; }
        public bool FirstYes { get; set; }
        public bool FirstNo { get; set; }
        public bool SecondYes { get; set; }
        public bool SecondNo { get; set; }
        public bool ThirdYes { get; set; }
        public bool ThirdNo { get; set; }
        public bool FourthYes { get; set; }
        public bool FourthNo { get; set; }
        public bool FifthYes { get; set; }
        public bool FifthNo { get; set; }

        public SelfExaminationTestViewModel()
        {
            SubmitClicked_Command = new Command(OnSubmitClicked);
        }

        private void OnSubmitClicked(object obj)
        {
            SelfExaminationTest test = new SelfExaminationTest();
            int brojac = 0;
            if (FirstYes == true)
            {
                test.BeingInContactWithInfected = true;
                brojac++;
            }
            else
            {
                test.BeingInContactWithInfected = false;
            }
            if (SecondYes == true)
            {
                test.LossOfSenseOfSmellOrTaste = true;
                brojac++;
            }
            else
            {
                test.LossOfSenseOfSmellOrTaste = false;
            }
            if (ThirdYes == true)
            {
                test.Fever = true;
                brojac++;
            }
            else
            {
                test.Fever = false;
            }
            if (FourthYes == true)
            {
                test.Cough = true;
                brojac++;
            }
            else
            {
                test.Cough = false;
            }
            if (FifthYes == true)
            {
                test.GeneralWeakness = true;
                brojac++;
            }
            else
            {
                test.GeneralWeakness = false;
            }
            test.IssueDate = new DateTime();
            test.UserID = LoginManager.Instance.LoggedUser.ID;
            if (brojac >= 2) { test.Result = TestResult.Positive; }
            else { test.Result = TestResult.Negative; }
            LoginManager.Instance.LoggedUser.SelfExaminationTests.Add(test);
            UserRepository.Instance.Save();
            MasterDetailLPage.Instance.SetDetailPage(new ItemsPage());

        }

    }
}
