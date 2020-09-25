using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamBuildersDiary.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void StartDemo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NewSiteDiaryPage(), false);
        }
    }
}
