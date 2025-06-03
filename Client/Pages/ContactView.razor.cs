using BlazorWASMWebApplication.Client.Services;
using BlazorWASMWebApplication.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace BlazorWASMWebApplication.Client.Pages
{
    public partial class ContactView
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IContactService ContactService { get; set; }

        public Contact Contact { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Contact = await ContactService.Contact(Int32.Parse(Id));
            Categories = await ContactService.Categories();
        }
    }
}
