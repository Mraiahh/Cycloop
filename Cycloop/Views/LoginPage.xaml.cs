using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage; // IMPORTANTE: Adicionado para gerenciar o Preferences sem erros

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
        // 1. Verifica se a chave de cadastro existe no celular
        bool usuarioJaCadastrado = Preferences.Default.Get("has_logged_in", false);

        if (!usuarioJaCadastrado)
        {
            // Se não tiver a chave, barra a entrada e avisa o usuário
            await DisplayAlert("Acesso Negado", "Você ainda não possui um cadastro no Cycloop. Por favor, clique em 'Criar uma conta' primeiro.", "OK");
            return;
        }

        // 2. Se ele já tiver o cadastro, valida o preenchimento dos campos de login normais
        if (string.IsNullOrWhiteSpace(EntEmail.Text) || string.IsNullOrWhiteSpace(EntSenha.Text))
        {
            await DisplayAlert("Erro", "Por favor, preencha todos os campos de login.", "OK");
            return;
        }

        // Fluxo correto: Permite a entrada para a estrutura principal do App mudando a MainPage para o Shell
        Application.Current.MainPage = new AppShell();
    }

    private bool AutenticarUsuario(string email, string senha)
    {
        return !string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(senha);
    }
}