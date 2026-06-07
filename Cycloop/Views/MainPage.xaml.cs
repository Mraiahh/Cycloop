using System.Threading.Tasks;
using Cycloop.Data; // IMPORTANTE: Adicionado para encontrar o DatabaseService
using Cycloop.Models;

namespace Cycloop.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnBtnRegistrarClicked(object sender, EventArgs e)
        {
            // Ajustado para usar a navegação do Shell de forma limpa
            await Shell.Current.GoToAsync(nameof(RegistrarCicloPage));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CarregarCalendarioAsync();
        }

        private async Task CarregarCalendarioAsync()
        {
            var databaseService = new DatabaseService();
            var codigosCiclo = await databaseService.GetCiclosAsync();
            var ultimoCiclo = codigosCiclo.LastOrDefault();

            var listaDias = new List<DiaCalendario>();
            DateTime hoje = DateTime.Now;
            int diasNoMes = DateTime.DaysInMonth(hoje.Year, hoje.Month);

            // Garante que o app não quebre se o componente visual falhar no ciclo de vida
            if (LblMesAno != null)
            {
                LblMesAno.Text = hoje.ToString("MMMM 'de' yyyy");
            }

            for (int i = 1; i <= diasNoMes; i++)
            {
                DateTime dataAtual = new DateTime(hoje.Year, hoje.Month, i);
                string fundo = "#FFFFFF";
                string texto = "#333333";

                if (ultimoCiclo != null)
                {
                    DateTime dataFimMenstruacao = ultimoCiclo.DataInicio.AddDays(ultimoCiclo.DuracaoDias);

                    if (dataAtual >= ultimoCiclo.DataInicio && dataAtual < dataFimMenstruacao)
                    {
                        fundo = "#D81B40";
                        texto = "#FFFFFF";
                    }
                }

                listaDias.Add(new DiaCalendario
                {
                    NumeroDia = i.ToString(),
                    CorFundo = fundo,
                    CorTexto = texto
                });
            }

            if (GridCalendario != null)
            {
                GridCalendario.ItemsSource = listaDias;
            }
        }
    }

    // Movido para fora da classe MainPage para evitar problemas de escopo
    public class DiaCalendario
    {
        public string NumeroDia { get; set; }
        public string CorFundo { get; set; }
        public string CorTexto { get; set; }
    }
}