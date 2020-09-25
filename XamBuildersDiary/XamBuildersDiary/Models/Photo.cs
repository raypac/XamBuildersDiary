#region Copyright
// ===================================================================
//  This file is part of the XamBuilderDiary application.
//  Copyright © 2020 Martin Pulgar Construction. All rights reserved.
// ===================================================================
#endregion

using Newtonsoft.Json;

namespace XamBuildersDiary.Models
{
    /// <summary>
    /// Photo Model
    /// </summary>
    public class Photo
    {
        /// <summary>
        ///     Property for Name.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        ///     Property for Data in Base64.
        /// </summary>
        [JsonProperty("Data")]
        public string Data { get; set; }

    }
}
