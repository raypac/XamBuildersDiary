using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamBuildersDiary.Models;
using XamBuildersDiary.ViewModels;

namespace XamBuildersDiary.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewSiteDiaryPage : ContentPage
    {
        NewSiteDiaryViewModel viewModel;

        public NewSiteDiaryPage()
        {
            InitializeComponent();
            BindingContext = this.viewModel = new NewSiteDiaryViewModel();
        }
    }
}