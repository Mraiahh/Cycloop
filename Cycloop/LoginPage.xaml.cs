namespace Cycloop;

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
}