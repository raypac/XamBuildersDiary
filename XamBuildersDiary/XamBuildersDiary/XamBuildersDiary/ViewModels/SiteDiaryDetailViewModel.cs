using System;

using XamBuildersDiary.Models;

namespace XamBuildersDiary.ViewModels
{
    public class SiteDiaryDetailViewModel : BaseViewModel
    {
        public SiteDiary Item { get; set; }
        public SiteDiaryDetailViewModel(SiteDiary item = null)
        {
            Item = item;
        }
    }
}
