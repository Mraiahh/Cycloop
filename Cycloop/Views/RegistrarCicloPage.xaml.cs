using Cycloop.Models;
using Cycloop.Data;

namespace Cycloop.Views;

public partial class RegistrarCicloPage : ContentPage
{
    private readonly DatabaseService _databaseService;

    public RegistrarCicloPage()
    {
        InitializeComponent();
        _databaseService = new DatabaseService();
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        // Validação dos campos obrigatórios
        if (string.IsNullOrWhiteSpace(EntDuracao.Text) ||
            PickerFluxo.SelectedIndex == -1 ||
            PickerColica.SelectedIndex == -1)
        {
            await DisplayAlert("Atenção", "Por favor, preencha a duração e os indicadores.", "OK");
            return;
        }

        // Mapeamento dos dados inseridos na tela para o modelo Ciclo
        var novoCiclo = new Ciclo
        {
            DataInicio = PickerData.Date,
            DuracaoDias = int.Parse(EntDuracao.Text),
            IntensidadeFluxo = PickerFluxo.SelectedItem.ToString(),
            CorSangue = PickerCor.SelectedItem?.ToString() ?? "Não informado",
            NivelColica = PickerColica.SelectedItem.ToString(),
            Sintomas = "Registrado no aplicativo"
        };

        // Salvando no banco SQLite local
        await _databaseService.SalvarCicloAsync(novoCiclo);

        await DisplayAlert("Sucesso", "Ciclo registrado com sucesso!", "OK");

        // Volta para a MainPage usando a navegação do Shell
        await Shell.Current.GoToAsync("..");
    }
}