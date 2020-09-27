#region Copyright
// ===================================================================
//  This file is part of the XamBuilderDiary application.
//  Copyright © 2020 Martin Pulgar Construction. All rights reserved.
// ===================================================================
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamBuildersDiary.Models;
using XamBuildersDiary.Services;
using XamBuildersDiary.Utilities;
using Xamarin.Essentials;

namespace XamBuildersDiary.ViewModels
{
    /// <summary>
    /// New Site Diary View Model
    /// </summary>
    public class NewSiteDiaryViewModel : BaseViewModel
    {
        #region Fields

        /// <summary>
        ///     Private Property for location.
        /// </summary>
        private string location;

        /// <summary>
        ///     Private Property for List of Photo
        /// </summary>
        private List<Photo> photos;

        /// <summary>
        ///    Private Property for Include In Photo Gallery.
        /// </summary>
        private bool includeInPhotoGallery;

        /// <summary>
        ///    Private Property for Comments.
        /// </summary>
        private string comments;

        /// <summary>
        ///    Private Property for Date.
        /// </summary>
        private DateTime date;

        /// <summary>
        ///    Private Property for Area.
        /// </summary>
        private string area;

        /// <summary>
        ///    Private Property for Task Category.
        /// </summary>
        private string taskCategory;

        /// <summary>
        ///    Private Property for Tags.
        /// </summary>
        private string tags;

        /// <summary>
        ///    Private Property for Link to existing Event.
        /// </summary>
        private bool isLinkedToExistingEvent;

        /// <summary>
        ///    Private Property for Event.
        /// </summary>
        private string linkedEvent;

        /// <summary>
        ///     Private Property for Area List.
        /// </summary>
        private List<string> areaList;

        /// <summary>
        ///     Private Property Task Category List.
        /// </summary>
        private List<string> taskCategoryList;

        /// <summary>
        ///     Private Property Event List.
        /// </summary>
        private List<string> eventList;

        /// <summary>
        ///    Next Command.
        /// </summary>
        public Command NextCommand { get; set; }

        /// <summary>
        ///     Browse Photo Command.
        /// </summary>
        public Command BrowsePhotoCommand { get; set; }

        #endregion

        #region Properties

        /// <summary>
        ///     Public Property for Location.
        /// </summary>
        public string Location
        {
            get { return location; }
            set { SetProperty(ref location, value); }
        }

        /// <summary>
        ///     Public Property for Photos.
        /// </summary>
        public List<Photo> Photos
        {
            get { return photos; }
            set { SetProperty(ref photos, value); }
        }

        /// <summary>
        ///     Public Property for Include In Photo Gallery.
        /// </summary>
        public bool IncludeInPhotoGallery
        {
            get { return includeInPhotoGallery; }
            set { SetProperty(ref includeInPhotoGallery, value); }
        }

        /// <summary>
        ///     Public Property for Comments.
        /// </summary>
        public string Comments
        {
            get { return comments; }
            set { SetProperty(ref comments, value); }
        }

        /// <summary>
        ///     Public Property for Date.
        /// </summary>
        public DateTime Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }

        /// <summary>
        ///     Public Property for Area.
        /// </summary>
        public string Area
        {
            get { return area; }
            set { SetProperty(ref area, value); }
        }

        /// <summary>
        ///     Public Property for Task Category.
        /// </summary>
        public string TaskCategory
        {
            get { return taskCategory; }
            set { SetProperty(ref taskCategory, value); }
        }

        /// <summary>
        ///     Public Property for Tags.
        /// </summary>
        public string Tags
        {
            get { return tags; }
            set { SetProperty(ref tags, value); }
        }

        /// <summary>
        ///     Public Property for Is Linked To Existing Event.
        /// </summary>
        public bool IsLinkedToExistingEvent
        {
            get { return isLinkedToExistingEvent; }
            set { SetProperty(ref isLinkedToExistingEvent, value); }
        }

        /// <summary>
        ///     Public Property for Linked Event.
        /// </summary>
        public string LinkedEvent
        {
            get { return linkedEvent; }
            set { SetProperty(ref linkedEvent, value); }
        }

        /// <summary>
        ///     Public Property for Area.
        /// </summary>
        public List<string> AreaList
        {
            get { return areaList; }
            set { SetProperty(ref areaList, value); }
        }

        /// <summary>
        ///     Public Property for Task Category.
        /// </summary>
        public List<string> TaskCategoryList
        {
            get { return taskCategoryList; }
            set { SetProperty(ref taskCategoryList, value); }
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
            Title = "New Diary";

            //Todo: For revision
            AreaList = StaticDefinition.Area;
            TaskCategoryList = StaticDefinition.TaskCategory;
            EventList = StaticDefinition.EventList;

            Photos = new List<Photo>();

            Task.Run( async () => {
                Location = await GeolocationRequest();
            });

            NextCommand = new Command(async () => await ExecuteNextCommand());
            BrowsePhotoCommand = new Command(async () => await ExecuteBrowsePhotoCommand());

        }

        #endregion

        #region Method

        // <summary>
        //     Execute Next Command
        // </summary>
        private async Task ExecuteNextCommand()
        {
            var siteDiary = new SiteDiary();
            siteDiary.Location = location;
            siteDiary.Photos = photos;
            siteDiary.IncludeInPhotoGallery = includeInPhotoGallery;
            siteDiary.Comments = comments;
            siteDiary.Date = date;
            siteDiary.Area = area;
            siteDiary.Tags = tags;
            siteDiary.IsLinkedToExistingEvent = isLinkedToExistingEvent;
            siteDiary.Event = linkedEvent;

            await BuildersDiaryService.Instance.PostSiteDiaryAsync(siteDiary);
        }

        // <summary>
        //     Execute Browse Photo Command
        // </summary>
        private async Task ExecuteBrowsePhotoCommand()
        {
            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    Photos.Add(new Photo
                    {
                        Name = Guid.NewGuid().ToString(),
                        Data = Convert.ToBase64String(ms.ToArray())
                    });
                }
            }
        }

        // <summary>
        //     Geo Location Request
        // </summary>
        private async Task<string> GeolocationRequest()
        {
            var result = "Location not available";

            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    var reverseGeoCodingResult = await BuildersDiaryService.Instance.GetReverseGeoCoding(location.Latitude, location.Longitude);

                    if (reverseGeoCodingResult.DidSucceed)
                    {
                        var reverseGeoCoding = reverseGeoCodingResult.ResponseObject as ReverseGeocodingResponse;
                        result = $"{reverseGeoCoding.PlaceId} | {reverseGeoCoding.DisplayName}";
                    }
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            return result;
        }

        #endregion
    }
}
