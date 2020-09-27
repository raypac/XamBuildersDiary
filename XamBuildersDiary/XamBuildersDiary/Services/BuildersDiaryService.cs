#region Copyright
// ===================================================================
//  This file is part of the XamBuilderDiary application.
//  Copyright © 2020 Martin Pulgar Construction. All rights reserved.
// ===================================================================
#endregion
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamBuildersDiary.Models;
using XamBuildersDiary.Utilities;

namespace XamBuildersDiary.Services
{
    /// <summary>
    /// Builders Diary Service
    /// </summary>
    public class BuildersDiaryService
    {
        #region Fields

        /// <summary>
        /// Private static property for Builders Diary Service Instance
        /// </summary>
        private static BuildersDiaryService _instance;

        #endregion

        #region Properties

        /// <summary>
        /// Public Property for Builders Diary Service Instance
        /// </summary>
        public static BuildersDiaryService Instance
        {
            get
            {
                return _instance ?? (_instance = new BuildersDiaryService());
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor Builders Diary Service
        /// </summary>
        public BuildersDiaryService()
        {

        }

        #endregion

        #region Method

        /// <summary>
        /// Post Site Diary Async
        /// </summary>
        /// <returns>The Post Site Diary Async Result.</returns>
        /// <param name="siteDiary">SiteDiary Model</param>
        public async Task<Result> PostSiteDiaryAsync(SiteDiary siteDiary)
        {
            var result = new Result() { DidSucceed = false };

            try
            {
                using (var client = new HttpClient())
                {
                    var apiUri = $"{StaticDefinition.BaseApiUrl}/{StaticDefinition.EndPoint}";

                    client.BaseAddress = new Uri(apiUri);

                    var request = new HttpRequestMessage(new HttpMethod("POST"), apiUri);

                    request.Content = new StringContent(JsonConvert.SerializeObject(siteDiary), Encoding.UTF8, "application/json");

                    using (var resp = await client.SendAsync(request))
                    {
                        if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            result.DidSucceed = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

            return result;
        }

        /// <summary>
        /// Post Site Diary Async
        /// </summary>
        /// <returns>The Reverse Geocoding Response Result.</returns>
        /// <param name="latitude">Longitude</param>
        /// <param name="longitude">Longitude</param>
        public async Task<Result> GetReverseGeoCoding(double latitude, double longitude)
        {
            var result = new Result() { DidSucceed = false };

            try
            {
                using (var client = new HttpClient())
                {
                    var apiUri = $"{StaticDefinition.LocationIQApiUrl}/{StaticDefinition.LocationIQRGEndPoint.Replace("{lat}", latitude.ToString()).Replace("{long}", longitude.ToString())}";

                    client.BaseAddress = new Uri(apiUri);

                    var request = new HttpRequestMessage(HttpMethod.Get, apiUri);

                    using (var resp = await client.SendAsync(request))
                    {
                        if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            using (var content = resp.Content)
                            {
                                var jsonResult = content.ReadAsStringAsync().Result;
                                var reverseGeocoding = JsonConvert.DeserializeObject<ReverseGeocodingResponse>(jsonResult);
                                result.DidSucceed = true;
                                result.ResponseObject = reverseGeocoding;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        #endregion

    }
}
