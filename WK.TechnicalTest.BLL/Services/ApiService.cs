using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WK.TechnicalTest.BLL.Extensions;
using WK.TechnicalTest.BLL.Interfaces.Services;

namespace WK.TechnicalTest.BLL.Services
{
    public class ApiService : IApiService
    {
        private readonly ApiSettings _apiSettings;

        public ApiService(IOptions<ApiSettings> apiSettings)
        {
            _apiSettings = apiSettings.Value;
        }

        public async Task<IEnumerable<string>> Add(string controller, string objectJson)
        {
            IEnumerable<string> errors = Array.Empty<string>();

            using (var httpClient = new HttpClient { BaseAddress = new Uri(new Uri(_apiSettings.BaseUri), controller) })
            {
                using (var content = new StringContent(objectJson, Encoding.Default, "application/json"))
                {
                    HttpResponseMessage response = await httpClient.PostAsync($"{controller}/Create", content);
                    if(!response.IsSuccessStatusCode)
                        errors = JsonConvert.DeserializeObject<IEnumerable<string>>(await response.Content.ReadAsStringAsync());
                }
            }

            return errors;
        }

        public async Task<string> GetAll(string controller)
        {
            using (var httpClient = new HttpClient { BaseAddress = new Uri(_apiSettings.BaseUri) })
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{controller}/GetAll");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }

            return string.Empty;
        }

        public async Task<object> GetById(string controller, Type returnType, long id)
        {
            var uriBuilder = new UriBuilder(new Uri(new Uri(_apiSettings.BaseUri), $"{controller}/GetById"));
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            query["id"] = id.ToString();

            uriBuilder.Query = query.ToString();

            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(uriBuilder.Uri);
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync(), returnType);
                }
            }

            return null;
        }

        public async Task<bool> Delete(string controller, long id)
        {
            var uriBuilder = new UriBuilder(new Uri(new Uri(_apiSettings.BaseUri), $"{controller}/Delete"));
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            query["id"] = id.ToString();

            uriBuilder.Query = query.ToString();

            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.DeleteAsync(uriBuilder.Uri);

                return response.IsSuccessStatusCode;
            }
        }

        public async Task<IEnumerable<string>> Update(string controller, long id, string objectJson)
        {
            IEnumerable<string> errors = Array.Empty<string>();

            var uriBuilder = new UriBuilder(new Uri(new Uri(_apiSettings.BaseUri), $"{controller}/Update"));
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            query["id"] = id.ToString();

            uriBuilder.Query = query.ToString();

            using (var httpClient = new HttpClient())
            {
                using (var content = new StringContent(objectJson, Encoding.Default, "application/json"))
                {
                    HttpResponseMessage response = await httpClient.PutAsync(uriBuilder.Uri, content); 
                    if (!response.IsSuccessStatusCode)
                        errors = JsonConvert.DeserializeObject<IEnumerable<string>>(await response.Content.ReadAsStringAsync());
                }
            }

            return errors;
        }
    }
}
