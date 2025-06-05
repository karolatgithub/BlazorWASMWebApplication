using BlazorWASMWebApplication.Client.Services;
using BlazorWASMWebApplication.Shared;
using BlazorWASMWebApplication.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Security.Principal;
using System.Transactions;
using static System.Net.WebRequestMethods;

namespace BlazorWASMWebApplication.Client.Pages
{
    public partial class LoginView
    {
        [Inject]
        public IContactService ContactService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }

        public EditContext ViewContext { get; set; }
        private string? Email;
        private string? Password;
        public bool NotLogged { get; set; } = true;
        protected async override Task OnInitializedAsync()
        {
            ViewContext = new EditContext(this);
        }
        async Task CheckPassword()
        {
            NotLogged = !(await ContactService.PaswordIsValid(Email, Utils.ENCODE_PASSWORD_TO_BASE_64(Password)));
            ViewContext.NotifyValidationStateChanged();
        }
    }
}
