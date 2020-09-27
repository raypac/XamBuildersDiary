#region Copyright
// ===================================================================
//  This file is part of the XamBuilderDiary application.
//  Copyright © 2020 Martin Pulgar Construction. All rights reserved.
// ===================================================================
#endregion

using System.Collections.Generic;

namespace XamBuildersDiary.Utilities
{
    /// <summary>
    /// Static Definition Static Class
    /// </summary>
    public static class StaticDefinition
    {
        /// <summary>
        ///     Area
        /// </summary>
        public static List<string> Area = new List<string>(new[] { " ", "Area 1", "Area 2", "Area 3" });

        /// <summary>
        ///     Task Category
        /// </summary>
        public static List<string> TaskCategory = new List<string>(new[] { " ", "Category 1", "Category 2", "Category 3" });

        /// <summary>
        ///     Event List
        /// </summary>
        public static List<string> EventList = new List<string>(new[] { " ", "Event 1", "Event 2", "Event 3" });

        /// <summary>
        ///     Base Api Url
        /// </summary>
        public static string BaseApiUrl { get; set; } = "https://reqres.in";

        /// <summary>
        ///     End Point
        /// </summary>
        public static string EndPoint { get; set; } = "api/users";


        /// <summary>
        ///     LocationIQ Api Url
        /// </summary>
        public static string LocationIQApiUrl { get; set; } = "https://us1.locationiq.com";

        /// <summary>
        ///     Reverse Geocoding End Point
        /// </summary>
        public static string LocationIQRGEndPoint { get; set; } = "v1/reverse.php?key=ad26309469b1c9&format=json&lat={lat}&lon={long}";
    }
}
