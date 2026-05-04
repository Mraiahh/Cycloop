using System.Threading.Tasks;

namespace Cycloop.Views
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnBtnRegistrarClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Ação", "Em breve: tela de registro de ciclo!", "OK");
        }

    }
}
