using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DolarCartao
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sobre : ContentPage
    {
        public Sobre()
        {
            InitializeComponent();
        }

        private void GitHub_Tapped(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://github.com/rayanralile", BrowserLaunchMode.SystemPreferred);
        }

        private void License_Tapped(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://creativecommons.org/licenses/by/4.0/", BrowserLaunchMode.SystemPreferred);
        }

        private void Icons8_Tapped(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://icons8.com/", BrowserLaunchMode.SystemPreferred);
        }

        private void Email_Tapped(object sender, EventArgs e)
        {
            Browser.OpenAsync("mailto:rayan@ralile.com.br", BrowserLaunchMode.SystemPreferred);
        }
    }
}