using System;
using TaskingoMobile.Services;
using TaskingoMobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskingoMobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AppShell), typeof(AppShell));
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
