using AndroidMobileApp.Views;
using Xamarin.Forms;

namespace AndroidMobileApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public Command QuickTestClicked_Command { get; }
        public Command SETestClicked_Command { get; }
        public Command PCRTestClicked_Command { get; }
        public Command ProfileClicked_Command { get; }
        public ItemsViewModel()
        {
            QuickTestClicked_Command = new Command(QuickTestClicked);
            SETestClicked_Command = new Command(SETestClicked);
            PCRTestClicked_Command = new Command(PCRTestClicked);
            ProfileClicked_Command = new Command(ProfileClicked);
         
        }

        private void QuickTestClicked(object obj)
        {
            MasterDetailLPage.Instance.SetDetailPage(new QuickTestPage());
        }
        private void SETestClicked(object obj)
        {
            MasterDetailLPage.Instance.SetDetailPage(new SelfExaminationTestPage());
        }
        private void PCRTestClicked(object obj)
        {
            MasterDetailLPage.Instance.SetDetailPage(new PCRTestPage());
        }
        private void ProfileClicked(object obj)
        {
            MasterDetailLPage.Instance.SetDetailPage(new ProfilePage());
        }
    }
}
