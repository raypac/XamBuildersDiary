using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamBuildersDiary.Models;
using XamBuildersDiary.Utilities;

namespace XamBuildersDiary.Services
{
    public class BuildersDiaryDataStore : IDataStore<SiteDiary>
    {
        readonly List<SiteDiary> items;

        public BuildersDiaryDataStore()
        {
            items = new List<SiteDiary>()
            {
                //new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                //new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                //new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                //new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                //new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                //new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(SiteDiary item)
        {
            var result = false;

            try
            {
                using (var client = new HttpClient())
                {
                    var apiUri = $"{StaticDefinition.BaseApiUrl}/{StaticDefinition.EndPoint}";

                    client.BaseAddress = new Uri(apiUri);

                    var request = new HttpRequestMessage(new HttpMethod("POST"), apiUri);

                    request.Content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");

                    using (var resp = await client.SendAsync(request))
                    {
                        if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            items.Add(item);
                            result = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<SiteDiary>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}