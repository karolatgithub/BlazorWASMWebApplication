
using BlazorWASMWebApplication.Shared.Model;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Text.Json;

namespace BlazorWASMWebApplication.Client.Services
{
    public class ContactService : IContactService
    {
        //[Inject]
        //private readonly HttpClient httpClient;
        //public ContactService(IHttpClientFactory httpClientFactory)
        //{
          
            //this.httpClient = httpClientFactory.CreateClient();
        //}


        public async Task<Contact> Contact(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contact>> Contacts()
        {
            //Console.WriteLine("1");
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8888");
            var response = await httpClient.GetAsync($"api/contact");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            return JsonSerializer.Deserialize<IEnumerable<Contact>>
                                (responseBody, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });


        }
    }
}
