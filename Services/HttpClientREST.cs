using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Test.Services
{
    public interface IHttpClientREST
    {
        Task GetAsync(string UrlAPI);
    }

    public class HttpClientREST : IHttpClientREST
    {
        public HttpClientREST() { }

        public async Task GetAsync(string UrlAPI)
        {

            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(UrlAPI);
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    string resultTask = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultTask);
                }
            }
        }
    }
}
