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

        protected async override Task OnInitializedAsync()
        {
            Contacts = await ContactService.Contacts();
        }
    }
}
