using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DolarCartao
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Converter : ContentPage
    {
        private const string Url = "https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/CotacaoDolarDia(dataCotacao=@dataCotacao)?";
        private const string Spread = "https://ralile.com.br/spread.txt";
        private const string IOF = "https://ralile.com.br/iof.txt";

        private string _content;
        private double _spread;
        private double _iof;
        private double _cotacaoPTAX;
        private DateTime _dataPTAX = DateTime.Now.AddDays(-1);
        private HttpClient _client = new HttpClient();
        public Converter()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            
            _spread = double.Parse(await _client.GetStringAsync(Spread), CultureInfo.InvariantCulture);
            _iof = double.Parse(await _client.GetStringAsync(IOF), CultureInfo.InvariantCulture);
            await GetPTAX(_dataPTAX);

            tf_dataUtil.Text = $"Data do último dia útil: {_dataPTAX.ToShortDateString()}";
            tf_dollarPTAX.Text = $"Cotação dólar PTAX ({DiaDaSemana(_dataPTAX)}): 1 Dólar = {_cotacaoPTAX} Reais";
            tf_spread.Text = $"Spread bancário: {Math.Round((_spread - 1)*100,4)}%";
            tf_iof.Text = $"Valor do IOF: {Math.Round(((_iof - 1) * 100),4)}%";

            base.OnAppearing();
        }
        private async Task GetPTAX(DateTime dateTime)
        {
            //string UrlBB = Url + "@dataCotacao='06-28-2020'&$top=1&$skip=0&$format=xml&$select=cotacaoVenda";
            string UrlBB = Url + GetAddUrlPTAX(dateTime);
            _content = await _client.GetStringAsync(UrlBB);
            int tamanho = _content.Length;
            if(tamanho <= 450)
            {
                _dataPTAX = _dataPTAX.AddDays(-1);
                await GetPTAX(_dataPTAX);
                return;
            }
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(_content);
            XmlNodeList elemList = doc.GetElementsByTagName("d:cotacaoVenda");
            _cotacaoPTAX = double.Parse(elemList[0].InnerXml, CultureInfo.InvariantCulture);
        }
        private string GetAddUrlPTAX(DateTime dateTime)
        {
            int day = dateTime.Day;
            int month = dateTime.Month;
            int year = dateTime.Year;
            return $"@dataCotacao='{month}-{day}-{year}'&$top=1&$skip=0&$format=xml&$select=cotacaoVenda";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string dollarText = tf_dollar.Text;
            if (String.IsNullOrWhiteSpace(dollarText))
            {
                DisplayAlert("Digite um valor", "Você deve preencher o campo Dólar USD para converter", "Ok");
                return;
            }
         //   DisplayAlert("Antes conv", dollarText, "OK");
         //   dollarText = dollarText.Replace(",", ".");
         //   DisplayAlert("Depois conv", dollarText, "OK");
            double dollar = double.Parse(dollarText);
            double cotacaoNubank = (dollar * (_cotacaoPTAX * _spread)) * _iof;
            tf_real.Text = Math.Round(cotacaoNubank, 2).ToString("0.00");
            tf_dollar.Text = Math.Round(dollar, 2).ToString("0.00");
            tf_obs.Text = "*O valor final pode variar do resultado exibido";
        }
        private string DiaDaSemana (DateTime dateTime)
        {
            int dia = Convert.ToInt32(dateTime.DayOfWeek);
            switch (dia)
            {
                case 0: return "Domingo";
                case 1: return "Segunda-feira";
                case 2: return "Terça-feira";
                case 3: return "Quarta-feira";
                case 4: return "Quinta-feira";
                case 5: return "Sexta-feira";
                case 6: return "Sábado";
                default:
                    return "Erro";
            }
        }
    }
}