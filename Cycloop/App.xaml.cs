using Cycloop.Views;

namespace Cycloop
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            bool hasLoggedIn = Preferences.Default.Get("has_logged_in", false);

            if (hasLoggedIn)
            {
                return new Window(new AppShell());
            }
            else
            {
                return new Window(new NavigationPage(new LoginPage()));
            }
        }
    }
}