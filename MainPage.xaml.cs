
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiApp1_APPHOTEL;

public partial class MainPage : ContentPage
{
    private string nomeHospede = string.Empty;
    private double quantidadeHospedes = 1;
    private DateTime dataEntrada = DateTime.Today;
    private DateTime dataSaida = DateTime.Today.AddDays(1);
    private string acomodacaoSelecionada = string.Empty;

    public MainPage()
    {
        InitializeComponent();

        TiposAcomodacao = new List<string>
        {
            "Quarto Standard",
            "Quarto Luxo",
            "Suíte Master",
            "Suíte Família"
        };

        BindingContext = this;
    }

    public List<string> TiposAcomodacao { get; }

    public string NomeHospede
    {
        get => nomeHospede;
        set
        {
            if (nomeHospede != value)
            {
                nomeHospede = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ResumoReserva));
            }
        }
    }

    public double QuantidadeHospedes
    {
        get => quantidadeHospedes;
        set
        {
            if (quantidadeHospedes != value)
            {
                quantidadeHospedes = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ResumoReserva));
            }
        }
    }

    public DateTime DataEntrada
    {
        get => dataEntrada;
        set
        {
            if (dataEntrada != value)
            {
                dataEntrada = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ResumoReserva));
            }
        }
    }

    public DateTime DataSaida
    {
        get => dataSaida;
        set
        {
            if (dataSaida != value)
            {
                dataSaida = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ResumoReserva));
            }
        }
    }

    public string AcomodacaoSelecionada
    {
        get => acomodacaoSelecionada;
        set
        {
            if (acomodacaoSelecionada != value)
            {
                acomodacaoSelecionada = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ResumoReserva));
            }
        }
    }

    public string ResumoReserva =>
        $"Hóspede: {NomeHospede}\n" +
        $"Quantidade de pessoas: {QuantidadeHospedes:0}\n" +
        $"Entrada: {DataEntrada:dd/MM/yyyy}\n" +
        $"Saída: {DataSaida:dd/MM/yyyy}\n" +
        $"Acomodação: {AcomodacaoSelecionada}";

    private async void OnConfirmarReservaClicked(
        object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NomeHospede))
        {
            await DisplayAlert(
                "Atenção",
                "Informe o nome do hóspede.",
                "OK");
            return;
        }

        if (DataSaida <= DataEntrada)
        {
            await DisplayAlert(
                "Atenção",
                "A data de saída deve ser posterior à entrada.",
                "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(AcomodacaoSelecionada))
        {
            await DisplayAlert(
                "Atenção",
                "Selecione uma acomodação.",
                "OK");
            return;
        }

        await DisplayAlert(
            "Reserva confirmada!",
            $"A reserva de {NomeHospede} foi realizada com sucesso!",
            "OK");
    }
}
