using BlazorWASMWebApplication.Client.Services;
using BlazorWASMWebApplication.Shared.Model;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorWASMWebApplication.Client.Pages
{
    public partial class ContactsView
    {
        public IEnumerable<Contact> Contacts { get; set; }

        //[Inject]
        //private HttpClient httpClient { get; set; }
        [Inject]
        public IContactService ContactService { get; set; }

        public static IEnumerable<Contact> INITIALIZE_CONTACTS()
        {
            var c1 = new Contact
            {

                Id = 1,
                Name = "Karol",
                Surname = "Kowalczyk",
                BirthDate = new DateOnly(),
                CategoryId = 1,
                Email = "k@wp.pl",
                SubCategory = "inny",
                Password = "1234",
                Phone = "123123123"

            };

            var c2 = new Contact
            {

                Id = 2,
                Name = "Ala",
                Surname = "Kowalczyk",
                BirthDate = new DateOnly(),
                CategoryId = 2,
                Email = "a@wp.pl",
                SubCategory = "inna",
                Password = "5678",
                Phone = "123123123"
            };

            return new List<Contact> { c1, c2 };
        }

        protected async override Task OnInitializedAsync()
        {
            Console.WriteLine(10);
            Contacts = await ContactService.Contacts();
            /*
            try
            {
                await httpClient.PostAsJsonAsync<IEnumerable<Contact>>("http://localhost:8888/api/contact", Contacts);
                Console.WriteLine("ile="+Contacts.Count());
            }
            catch (Exception ex)
            {
                Console.WriteLine("err=>" + ex.Message);
            }
            Console.WriteLine(11);
            */

        }
    }
}
