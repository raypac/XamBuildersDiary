#region Copyright
// ===================================================================
//  This file is part of the XamBuilderDiary application.
//  Copyright © 2020 Martin Pulgar Construction. All rights reserved.
// ===================================================================
#endregion
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamBuildersDiary.Models;
using XamBuildersDiary.Utilities;

namespace XamBuildersDiary.ViewModels
{
    /// <summary>
    /// New Site Diary View Model
    /// </summary>
    public class NewSiteDiaryViewModel : BaseViewModel
    {
        #region Fields

        public Command NextCommand { get; set; }

        /// <summary>
        ///     Private Property for Site Diary.
        /// </summary>
        private SiteDiary siteDiary;

        /// <summary>
        ///     Private Property for Area.
        /// </summary>
        private List<string> area;

        /// <summary>
        ///     Private Property Task Category.
        /// </summary>
        private List<string> taskCategory;

        /// <summary>
        ///     Private Property Event List.
        /// </summary>
        private List<string> eventList;

        #endregion

        #region Properties

        /// <summary>
        ///     Public Property for Site Diary.
        /// </summary>
        public SiteDiary SiteDiary
        {
            get { return siteDiary; }
            set { SetProperty(ref siteDiary, value); }
        }

        /// <summary>
        ///     Public Property for Area.
        /// </summary>
        public List<string> Area
        {
            get { return area; }
            set { SetProperty(ref area, value); }
        }

        /// <summary>
        ///     Public Property for Task Category.
        /// </summary>
        public List<string> TaskCategory
        {
            get { return taskCategory; }
            set { SetProperty(ref taskCategory, value); }
        }

        /// <summary>
        ///     Public Property for Task Category.
        /// </summary>
        public List<string> EventList
        {
            get { return eventList; }
            set { SetProperty(ref eventList, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        ///     New Site Diary View Model Constructor that accept SiteDiary Object
        /// </summary>
        public NewSiteDiaryViewModel()
        {
            siteDiary = new SiteDiary();

            //Todo: For revision
            Area = StaticDefinition.Area;
            TaskCategory = StaticDefinition.TaskCategory;
            EventList = StaticDefinition.EventList;

            NextCommand = new Command(async () => await ExecuteNextCommand());

        }

        #endregion

        #region Method

        /// <summary>
        ///     Execute Next Command
        /// </summary>
        private async Task ExecuteNextCommand()
        {
            await DataStore.AddItemAsync(siteDiary);
        }

        #endregion
    }
}
