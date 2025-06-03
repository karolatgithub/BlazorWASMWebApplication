
using BlazorWASMWebApplication.Shared.Model;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Text.Json;

namespace BlazorWASMWebApplication.Client.Services
{
    public class ContactService : IContactService
    {
        private readonly HttpClient httpClient;
        public ContactService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<Contact> Contact(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contact>> Contacts()
        {
            return JsonSerializer.Deserialize<IEnumerable<Contact>>
                                ((await (await httpClient.GetAsync($"api/contact")).Content.ReadAsStringAsync()), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
