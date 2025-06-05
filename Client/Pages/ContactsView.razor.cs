using Blazored.LocalStorage;
using BlazorWASMWebApplication.Client.Services;
using BlazorWASMWebApplication.Shared;
using BlazorWASMWebApplication.Shared.Model;
using Microsoft.AspNetCore.Components;
using System.Globalization;

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
            Editable = false;
            try
            {
                if (DateTime.ParseExact(await ProtectedStorage.GetItemAsStringAsync("Editable"), Utils.DATE_TIME_TO_STRING_FORMAT, CultureInfo.InvariantCulture) >= DateTime.Now)
                {
                    Editable = true;
                }
            }
            catch (Exception) { }
            finally
            {
                if (!Editable)
                {
                    await ProtectedStorage.RemoveItemAsync("Editable");
                }
            }
            Contacts = await ContactService.Contacts();
        }
    }
}
