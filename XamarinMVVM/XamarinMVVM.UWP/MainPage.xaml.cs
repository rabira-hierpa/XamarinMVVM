namespace XamarinMVVM.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new XamarinMVVM.App());
        }
    }
}
