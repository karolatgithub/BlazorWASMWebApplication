using BlazorWASMWebApplication.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace BlazorWASMWebApplication.Client.Pages
{
    public partial class ContactView
    {
        [Parameter]
        public string Id { get; set; }

        public Contact Contact { get; set; }


        protected override Task OnInitializedAsync()
        {
            Console.WriteLine(Id);
            Contact = ContactsView.INITIALIZE_CONTACTS().FirstOrDefault(contact=>contact.Id== Convert.ToInt32(Id));
            return base.OnInitializedAsync();
        }
    }
}
