using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace TV_MAZE
{
	public partial class App : Application
	{
        public const string WebServiceUrl = "http://api.tvmaze.com/search/shows";

        public App()
        {
            //InitializeComponent();
            //MainPage = new MainPage();
            var mainPage = new MainPage() { Title = "TV MAZE"};

            MainPage = new NavigationPage(mainPage)
            {
                BarTextColor = Color.FromRgb(69, 179, 157),
                BarBackgroundColor = Color.Black                
            };

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
