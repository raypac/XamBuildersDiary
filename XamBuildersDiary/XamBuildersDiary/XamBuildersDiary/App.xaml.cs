using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamBuildersDiary.Services;
using XamBuildersDiary.Views;

namespace XamBuildersDiary
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<BuildersDiaryDataStore>();
            MainPage = new MainPage();
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
