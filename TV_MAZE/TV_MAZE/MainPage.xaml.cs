using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TV_MAZE.Modelo;
using Xamarin.Forms;

namespace TV_MAZE
{
	public partial class MainPage : ContentPage
	{
        public ObservableCollection<object> Items { get; set; } = new ObservableCollection<object> { };
        public Command BuscarComando { get; set; }
        public Command LlenarComando { get; set; }

        public RootObject[] lista = new RootObject[5];

        public MainPage()
        {
            InitializeComponent();

            BuscarComando = new Command(async () => await CargarItems(Criterio.Text));

            ButtonBuscar.Clicked += ButtonBuscar_Click;
            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await CargarItems(Criterio.Text);

        }

        public void cargarlista()
        {
            string url = "http://www.tvmaze.com/shows/15299/the-boys";
            string type="Scripted";
            string language = "English";

            RootObject objeto1 = new RootObject();
            Show uno = new Show();
            uno.id = 1;
            uno.name = "Prueba1";
            uno.url = "http://static.tvmaze.com/uploads/images/original_untouched/60/151357.jpg";
            uno.type = type;
            uno.language = language;
            uno.summary = "Comedy Bigmouths</b> is a topical stand-up comedy and sketch show recorded live in front of a studio audience a few days before transmission, taking the pulse of the nation as comedians explore the world of current affairs and news from the last seven days";
            objeto1.score = 1200;
            objeto1.show = uno;
            lista[0] = objeto1;

            RootObject objeto2 = new RootObject();
            Show dos = new Show();
            dos.id = 2;
            dos.name = "Prueba2";
            dos.url = url;
            dos.type = type;
            dos.language = language;
            dos.summary = "The History of Comedy</b> explores what makes people laugh – from the Ancient Greeks, to Shakespeare, Vaudeville, to the biggest contemporary comedians, movies and TV shows. It digs deep into topics like political humor and slapstick, featuring the voices that have made us laugh over the generations. Using archival footage, original comedic material, interviews with comedy legends and luminaries, the series showcase how the art form has evolved over the years";
            objeto2.score = 3200;
            objeto2.show = dos;

            Modelo.Image foto = new Modelo.Image();
            foto.original = "http://static.tvmaze.com/uploads/images/original_untouched/169/424458.jpg";

            uno.image = foto;
            lista[1] = objeto2;

            RootObject objeto3 = new RootObject();
            Show tres = new Show();
            tres.id = 3;
            tres.name = "Prueba3";
            tres.url = url;
            tres.type = type;
            tres.language = language;
            tres.summary = "Comedy Bigmouths</b> is a topical stand-up comedy and sketch show recorded live in front of a studio audience a few days before transmission, taking the pulse of the nation as comedians explore the world of current affairs and news from the last seven days";
            objeto3.score = 1200;
            objeto3.show = tres;
            lista[2] = objeto3;

            RootObject objeto4 = new RootObject();
            Show cuatro = new Show();
            cuatro.id = 4;
            cuatro.name = "Prueba4";
            cuatro.url = url;
            cuatro.type = type;
            cuatro.language = language;
            cuatro.summary = "The History of Comedy</b> explores what makes people laugh – from the Ancient Greeks, to Shakespeare, Vaudeville, to the biggest contemporary comedians, movies and TV shows. It digs deep into topics like political humor and slapstick, featuring the voices that have made us laugh over the generations. Using archival footage, original comedic material, interviews with comedy legends and luminaries, the series showcase how the art form has evolved over the years";
            objeto4.score = 3200;
            objeto4.show = cuatro;
            lista[3] = objeto4;

            RootObject objeto5 = new RootObject();
            Show cinco = new Show();
            cinco.id = 5;
            cinco.name = "Prueba5";
            cinco.url = url;
            cinco.type = type;
            cinco.language = language;
            cinco.summary = "Comedy Bigmouths</b> is a topical stand-up comedy and sketch show recorded live in front of a studio audience a few days before transmission, taking the pulse of the nation as comedians explore the world of current affairs and news from the last seven days";
            objeto5.score = 1200;
            objeto5.show = cinco;
            lista[4] = objeto5;

        }


        private async void ButtonBuscar_Click(object sender, EventArgs arg)
        {
            await CargarItems(Criterio.Text);
        }

        private async Task CargarItems(string criteriobusqueda)
        {
            Items.Clear();

            //para Web Service
            var shows = await CargarShows(criteriobusqueda);

            foreach (var item in shows)
            {
                Items.Add(item.show);
            }


            // para datos quemados 
            //cargarlista();

            //foreach (var item in lista)
            //{
            //    Items.Add(item.show);
            //}

        }

        private async Task<RootObject[]> CargarShows(string criteriobusqueda)
        {
            try
            {
                var cliente = new HttpClient();

                cliente.BaseAddress = new Uri(App.WebServiceUrl);
                var json = await cliente.GetStringAsync("?q=" + criteriobusqueda);

                Console.WriteLine(json);

                var resultado = JsonConvert.DeserializeObject<RootObject[]>(json);

                return resultado;

            }
            catch (Exception ex)
            {
                // Log 
                return new RootObject[0];
            }
        }
        private async void  ListShows_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemselect = e.SelectedItem as Show;
            if (itemselect != null)
            {
                var seleccionado = new DescriptionPage(itemselect) { Title = "Descripción" };
                await Navigation.PushAsync(seleccionado);
            }
        }
    }
}
