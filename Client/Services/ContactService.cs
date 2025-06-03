
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

        public async Task<IEnumerable<Category>> Categories()
        {
            return JsonSerializer.Deserialize<IEnumerable<Category>>
                               ((await (await httpClient.GetAsync($"api/contacts/categories")).Content.ReadAsStringAsync()), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Category> Category(int id)
        {
            return JsonSerializer.Deserialize<Category>
                                ((await (await httpClient.GetAsync($"api/contacts/category/{id}")).Content.ReadAsStringAsync()), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Contact> Contact(int id)
        {
            return JsonSerializer.Deserialize<Contact>
                                ((await (await httpClient.GetAsync($"api/contacts/contact/{id}")).Content.ReadAsStringAsync()), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<Contact>> Contacts()
        {
            return JsonSerializer.Deserialize<IEnumerable<Contact>>
                                ((await (await httpClient.GetAsync($"api/contacts/contacts")).Content.ReadAsStringAsync()), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<SubCategory>> SubCategories()
        {
            return JsonSerializer.Deserialize<IEnumerable<SubCategory>>
                               ((await (await httpClient.GetAsync($"api/contacts/subcategories")).Content.ReadAsStringAsync()), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<SubCategory> SubCategory(int id, string name)
        {
            return JsonSerializer.Deserialize<SubCategory>
                                ((await (await httpClient.GetAsync($"api/contacts/subcategory/{id}/{name}")).Content.ReadAsStringAsync()), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
