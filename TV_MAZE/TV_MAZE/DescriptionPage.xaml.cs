using System;
using System.Threading.Tasks;
using TV_MAZE.Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TV_MAZE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DescriptionPage : ContentPage
    {        
        public Show seleccionado = new Show();

        public DescriptionPage(Show select)
        {
            InitializeComponent();
            seleccionado = select;

            ButtonVer.Clicked += ButtonVer_Click;

        }

        private async void ButtonVer_Click(object sender, EventArgs arg)
        {
            var resumen = new SummaryPage(seleccionado.summary) { Title = "Resumen" }; ;
            await Navigation.PushAsync(resumen);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            nombre.Text = seleccionado.name;
            ID.Text = seleccionado.id.ToString();
            url.Text =  seleccionado.url;
            tipo.Text =  seleccionado.type;
            languaje.Text =  seleccionado.language;
            //Resumen.Text = "Resumen: " + seleccionado.summary;

            await CargarFoto();
        }

        private async Task CargarFoto()
        {
            if (seleccionado.image != null)
            {
                if (seleccionado.image.medium != "")
                {
                    var imagen = new Uri(seleccionado.image.original);
                    Img.Source = FileImageSource.FromUri(imagen);
                }
            }
        }

    }
    
	
}