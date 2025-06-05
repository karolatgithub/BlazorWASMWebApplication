using BlazorWASMWebApplication.Client.Services;
using BlazorWASMWebApplication.Shared.Model;
using Microsoft.AspNetCore.Components;
using Blazored.LocalStorage;

namespace BlazorWASMWebApplication.Client.Pages
{
    public partial class ContactsView
    {
        public bool Editable { get; set; } = false;
        [Inject]
        public IContactService ContactService { get; set; }
        [Inject]
        ILocalStorageService ProtectedStorage { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Editable = await ProtectedStorage.ContainKeyAsync("Editable");
            Contacts = await ContactService.Contacts();
        }
    }
}
