using BlazorWASMWebApplication.Shared.Model;

namespace BlazorWASMWebApplication.Client.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> Contacts();
        Task<Contact> Contact(int id);
    }
}
