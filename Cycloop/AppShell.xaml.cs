namespace Cycloop
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.RegistrarCicloPage), typeof(Views.RegistrarCicloPage));
        }
    }
}
