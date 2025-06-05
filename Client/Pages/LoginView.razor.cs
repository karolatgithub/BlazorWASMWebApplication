using Blazored.LocalStorage;
using BlazorWASMWebApplication.Client.Services;
using BlazorWASMWebApplication.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorWASMWebApplication.Client.Pages
{
    public partial class LoginView
    {
        [Inject]
        public IContactService ContactService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Inject]
        ILocalStorageService ProtectedStorage { get; set; }
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
            if (NotLogged)
            {
                await ProtectedStorage.RemoveItemAsync("Editable");
            }
            else
            {
                await ProtectedStorage.SetItemAsStringAsync("Editable", "true");
            }
            ViewContext.NotifyValidationStateChanged();
        }
    }
}
