namespace Cycloop.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void OnCriarContaClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new RegistroPage());
    }

	private async void OnLoginClicked(object sender, EventArgs e)
	{
		string email = EmailEntry.Text;
		string senha = SenhaEntry.Text;
		// Aqui você pode adicionar a lógica de autenticação, como verificar as credenciais do usuário
		// Por exemplo, você pode consultar um banco de dados ou usar um serviço de autenticação
		bool autenticado = AutenticarUsuario(email, senha);
		if (autenticado)
		{
			await DisplayAlert("Sucesso", "Login realizado com sucesso!", "OK");
			// Navegar para a próxima página ou realizar outras ações após o login bem-sucedido
		}
		else
		{
			await DisplayAlert("Erro", "Email ou senha incorretos. Tente novamente.", "OK");
		}
    }

	private bool AutenticarUsuario(string email, string senha)
	{
		return !string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(senha);
    }
}