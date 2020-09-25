#region Copyright
// ===================================================================
//  This file is part of the XamBuilderDiary application.
//  Copyright © 2020 Martin Pulgar Construction. All rights reserved.
// ===================================================================
#endregion
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XamBuildersDiary.Models
{
    /// <summary>
    /// Diary Model
    /// </summary>
    public class SiteDiary
    {
        /// <summary>
        ///     Property for Location.
        /// </summary>
        [JsonProperty("Location")]
        public string Location { get; set; }

        /// <summary>
        ///     Property for List of Photo
        /// </summary>
        [JsonProperty("Photos")]
        public List<Photo> Photos { get; set; }

        /// <summary>
        ///     Property for Include In Photo Gallery.
        /// </summary>
        [JsonProperty("InclueInPhotoGallery")]
        public bool InclueInPhotoGallery { get; set; }

        /// <summary>
        ///     Property for Comments.
        /// </summary>
        [JsonProperty("Comments")]
        public string Comments { get; set; }

        /// <summary>
        ///     Property for Date.
        /// </summary>
        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        /// <summary>
        ///     Property for Area.
        /// </summary>
        [JsonProperty("Area")]
        public string Area { get; set; }

        /// <summary>
        ///     Property for Task Category.
        /// </summary>
        [JsonProperty("TaskCategory")]
        public string TaskCategory { get; set; }

        /// <summary>
        ///     Property for Tags.
        /// </summary>
        [JsonProperty("Tags")]
        public string Tags { get; set; }

        /// <summary>
        ///     Property for Link to existing Event.
        /// </summary>
        [JsonProperty("IsLinkedToExistingEvent")]
        public bool IsLinkedToExistingEvent { get; set; }

        /// <summary>
        ///     Property for Event.
        /// </summary>
        [JsonProperty("Event")]
        public string Event { get; set; }

        /// <summary>
        ///     Site Diary Constructor
        /// </summary>
        public SiteDiary()
        {
            this.Photos = new List<Photo>();
        }
    }
}
