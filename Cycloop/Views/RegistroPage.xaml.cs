using Microsoft.Maui.Controls;

namespace Cycloop.Views
{
    public partial class RegistroPage : ContentPage
    {
        public RegistroPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(EntNome.Text))
            {
                Preferences.Default.Set("user_name", EntNome.Text); //salva as preferencias pra saber que ja logou
                Preferences.Default.Set("has_logged_in", true);

                await DisplayAlert("Bem-vindo!", $"Olá, {EntNome.Text}! Você foi registrado com sucesso.", "OK");

                Application.Current.MainPage = new AppShell(); //troca a rootpage para a estrutura principal do app
            }
            else
            {
                await DisplayAlert("Erro", "Por favor, digite seu nome.", "OK");
            }
        }
    }
}