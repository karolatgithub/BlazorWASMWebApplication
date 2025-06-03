using BlazorWASMWebApplication.Client.Services;
using BlazorWASMWebApplication.Shared.Model;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorWASMWebApplication.Client.Pages
{
    public partial class ContactsView
    {

        [Inject]
        public IContactService ContactService { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public Category Category { get; set; }

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
            Contacts = await ContactService.Contacts();
        }

        public async void RefreshCategoryById(int id)
        {
            Category = await ContactService.Category(id);
            InvokeAsync(StateHasChanged);
        }
    }
}
