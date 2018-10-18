using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TV_MAZE
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SummaryPage : ContentPage
	{
        public string res;
        public SummaryPage(string resumen)
        {
            InitializeComponent();

            res = resumen.Replace("</b>", "").Replace("<b>", "").Replace("<p>","").Replace("</p>", "");

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            resumen.Text = res;           

        }
    }
}