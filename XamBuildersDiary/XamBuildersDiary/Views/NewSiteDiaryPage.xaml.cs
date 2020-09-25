using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamBuildersDiary.ViewModels;

namespace XamBuildersDiary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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