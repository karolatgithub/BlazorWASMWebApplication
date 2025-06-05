using BlazorWASMWebApplication.Shared.Model;

namespace BlazorWASMWebApplication.Client.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> Contacts();
        Task<Contact> Contact(int id);
        Task<IEnumerable<Category>> Categories();
        Task<Category> Category(int id);
        Task<IEnumerable<SubCategory>> SubCategories();
        Task<SubCategory> SubCategory(int id, string name);
        Task<Contact> SaveContact(Contact contact);
        Task<bool> PaswordIsValid(string email, string token);
    }
}
