using BlazorWASMWebApplication.Client.Services;
using BlazorWASMWebApplication.Shared.Model;
using Microsoft.AspNetCore.Components;
using System.Transactions;

namespace BlazorWASMWebApplication.Client.Pages
{
    public partial class LoginView
    {
        [Inject]
        public IContactService ContactService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        private string? Email;
        private string? Password;
        public bool NotLogged { get; set; } = true;
        protected async override Task OnInitializedAsync()
        {
            NotLogged = true;
        }
    }
}
