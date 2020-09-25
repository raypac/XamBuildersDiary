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

        private static BuildersDiaryService _instance;

        #endregion

        #region Properties

        public static BuildersDiaryService Instance
        {
            get
            {
                return _instance ?? (_instance = new BuildersDiaryService());
            }
        }

        #endregion

        #region Constructor

        public BuildersDiaryService()
        {

        }

        #endregion

        #region Method

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

        #endregion

    }
}
