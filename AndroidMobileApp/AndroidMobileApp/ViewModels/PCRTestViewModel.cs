using AndroidMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AndroidMobileApp.ViewModels
{
    class PCRTestViewModel : BaseViewModel
    {
        public string SelectedTitle { get; set; }
        public Command ContinueCommand { get; }
        public string FirstLabel { get; set; }
        public string SecondLabel { get; set; }
        public string ThirdLabel { get; set; }
        public string FirstPicture { get; set; }
        public string SecondPicture { get; set; }
        public string SEClick { get; set; }
        public string QuickClick { get; set; }
        public Command SEClickCommand { get; }
        public Command QuickClickCommand { get; }
        public PCRTestViewModel()
        {
            Title = "PCR tests";
            ContinueCommand = new Command(OnContinueClicked);
            SEClickCommand = new Command(OnSEOptionClicked);
            QuickClickCommand = new Command(OnQuickOptionClicked);
        }

        private void OnContinueClicked(object obj)
        {
            if (SelectedTitle != null && SelectedTitle.Equals("About PCR tests"))
            {
                FirstLabel = "At the moment the majority of the current Covid-19 tests that all the reports are coming from are using PCR,” says University of Sussex senior lecturer in microbiology Dr Edward Wright. “They detect the genetic information of the virus, the RNA. That’s only possible if the virus is there and someone is actively infected. PCR tests are used to directly detect the presence of an antigen, rather than the presence of the body’s immune response, or antibodies. By detecting viral RNA, which will be present in the body before antibodies form or symptoms of the disease are present, the tests can tell whether or not someone has the virus very early on.PCR gives us a good indication of who is infected.They can be isolated and get in contact with people they’ve been in touch with so they can be quarantined too, just in case. That’s the true advantage of the current major diagnostic tests, you can break that transmission chain and get a clearer picture of what’s happening,” says Wright. By scaling PCR testing to screen vast swathes of nasopharyngeal swab samples from within a population, public health officials can get a clearer picture of the spread of a disease like Covid-19 within a population. It’s worth noting that PCR tests can be very labour intensive, with several stages at which errors may occur between sampling and analysis.False negatives can occur up to 30% of the time with different PCR tests, meaning they’re more useful for confirming the presence of an infection than giving a patient the all-clear.";
                SecondLabel = "";
                ThirdLabel = "";
                FirstPicture = "";
                SecondPicture = "";
                SEClick = "";
                QuickClick = "";
                OnPropertyChanged(nameof(FirstLabel));
                OnPropertyChanged(nameof(SecondLabel));
                OnPropertyChanged(nameof(ThirdLabel));
                OnPropertyChanged(nameof(FirstPicture));
                OnPropertyChanged(nameof(SecondPicture));
                OnPropertyChanged(nameof(SEClick));
                OnPropertyChanged(nameof(QuickClick));
            }
            if (SelectedTitle != null && SelectedTitle.Equals("Methods of PCR testing"))
            {
                FirstLabel = "";
                SecondLabel = "Sample of mucus can be taken from your nose";
                ThirdLabel = "Also, sample of mucus can be taken from your throat";
                FirstPicture = "nose.png";
                SecondPicture = "mouth.png";
                SEClick = "";
                QuickClick = "";
                OnPropertyChanged(nameof(FirstLabel));
                OnPropertyChanged(nameof(SecondLabel));
                OnPropertyChanged(nameof(ThirdLabel));
                OnPropertyChanged(nameof(FirstPicture));
                OnPropertyChanged(nameof(SecondPicture));
                OnPropertyChanged(nameof(SEClick));
                OnPropertyChanged(nameof(QuickClick));
            }
            if (SelectedTitle != null && SelectedTitle.Equals("Need for PCR test"))
            {
                FirstLabel = "";
                SecondLabel = "If your self-examination test or quick test is positive you should probably do PCR test.";
                ThirdLabel = "Also, make sure you have negative PCR test if you are travelling outside your country.";
                FirstPicture = "";
                SecondPicture = "";
                SEClick = "Click here to do self-examinination test";
                QuickClick = "Click here to schedule quick testing";
                OnPropertyChanged(nameof(FirstLabel));
                OnPropertyChanged(nameof(SecondLabel));
                OnPropertyChanged(nameof(ThirdLabel));
                OnPropertyChanged(nameof(FirstPicture));
                OnPropertyChanged(nameof(SecondPicture));
                OnPropertyChanged(nameof(SEClick));
                OnPropertyChanged(nameof(QuickClick));

            }
        }

        private void OnSEOptionClicked()
        {
            MasterDetailLPage.Instance.SetDetailPage(new SelfExaminationTestPage());
        }
        private void OnQuickOptionClicked()
        {
            MasterDetailLPage.Instance.SetDetailPage(new QuickTestPage());
        }

    }
}
