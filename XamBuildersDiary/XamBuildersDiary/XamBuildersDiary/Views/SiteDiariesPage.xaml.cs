using System;
using System.ComponentModel;
using Xamarin.Forms;

using XamBuildersDiary.Models;
using XamBuildersDiary.ViewModels;

namespace XamBuildersDiary.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class SiteDiariesPage : ContentPage
    {
        SiteDiariesViewModel viewModel;

        public SiteDiariesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new SiteDiariesViewModel();
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewSiteDiaryPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}