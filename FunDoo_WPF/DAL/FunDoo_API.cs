using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FunDoo_WPF.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace FunDoo_WPF.DAL
{
    internal static class FunDoo_API
    {

        private static readonly string ToDoBaseURL = "https://fundooapiapp1.azurewebsites.net";

        public static async Task<List<ToDoItemModel>> GetAllToDoItems()
        {
            string url = string.Empty;
            url = ToDoBaseURL + $"/Items";

            using (HttpClientHandler handler = new HttpClientHandler())
            {
                handler.UseDefaultCredentials = true;

                using (var apiClient = new HttpClient(handler))
                {
                    apiClient.DefaultRequestHeaders.Accept.Clear();
                    apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (HttpResponseMessage response = await apiClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string responseString = await response.Content.ReadAsStringAsync();
                            // read the response
                            return JsonConvert.DeserializeObject<List<ToDoItemModel>>(responseString);

                        }
                        else
                            throw new Exception(response.ReasonPhrase);
                    }
                }

            }

        }

        public static async void InsertItem(ToDoItemModel itemModel)
        {
            string url = string.Empty;
            url = ToDoBaseURL + $"/Items";

            using (HttpClientHandler handler = new HttpClientHandler())
            {
                handler.UseDefaultCredentials = true;

                using (var apiClient = new HttpClient(handler))
                {
                    apiClient.DefaultRequestHeaders.Accept.Clear();
                    apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var json = JsonConvert.SerializeObject(itemModel, Formatting.Indented);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    using (var responseObj = await apiClient.PostAsync(url, content))
                    {
                        if (responseObj.IsSuccessStatusCode)
                        {
                            return;
                        }
                        else
                        {
                            throw new Exception(responseObj.ReasonPhrase);
                        }
                    }
                }

            }

        }

        public static async void UpdateItem(ToDoItemModel itemModel)
        {
            string url = string.Empty;
            url = ToDoBaseURL + $"/Items";

            using (HttpClientHandler handler = new HttpClientHandler())
            {
                handler.UseDefaultCredentials = true;

                using (var apiClient = new HttpClient(handler))
                {
                    apiClient.DefaultRequestHeaders.Accept.Clear();
                    apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var json = JsonConvert.SerializeObject(itemModel, Formatting.Indented);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    using (var responseObj = await apiClient.PutAsync(url, content))
                    {
                        if (responseObj.IsSuccessStatusCode)
                        {
                            return;
                        }
                        else
                        {
                            throw new Exception(responseObj.ReasonPhrase);
                        }
                    }
                }

            }

        }
        public static async void DeleteItem(int itemId)
        {
            string url = string.Empty;
            url = ToDoBaseURL + $"/Items/{itemId}";

            using (HttpClientHandler handler = new HttpClientHandler())
            {
                handler.UseDefaultCredentials = true;

                using (var apiClient = new HttpClient(handler))
                {
                    apiClient.DefaultRequestHeaders.Accept.Clear();
                    apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var responseObj = await apiClient.DeleteAsync(url))
                    {
                        if (responseObj.IsSuccessStatusCode)
                        {
                            return;
                        }
                        else
                        {
                            throw new Exception(responseObj.ReasonPhrase);
                        }
                    }
                }

            }
        }
    }
}
