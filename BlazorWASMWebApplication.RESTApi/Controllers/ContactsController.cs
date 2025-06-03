using Microsoft.AspNetCore.Mvc;
using BlazorWASMWebApplication.Shared.Model;

namespace BlazorWASMWebApplication.RESTApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly ContactsDataBaseContext contactsDataBaseContext;
    public ContactsController(ContactsDataBaseContext contactsDataBaseContext)
    {
        this.contactsDataBaseContext = contactsDataBaseContext;
    }

    [HttpGet("contacts")]
    public IEnumerable<Contact> GetContacts()
    {
        return contactsDataBaseContext.Contact.ToList<Contact>();
    }

    [HttpGet("contact/{id}")]
    public Contact GetContact(int id)
    {
        return contactsDataBaseContext.Contact.Find(id);
    }

    [HttpGet("categories")]
    public IEnumerable<Category> GetCategories()
    {
        return contactsDataBaseContext.Category.ToList<Category>();
    }

    [HttpGet("category/{id}")]
    public Category GetCategory(int id)
    {
        return contactsDataBaseContext.Category.Find(id);
    }
    [HttpGet("subcategories")]
    public IEnumerable<SubCategory> GetSubCategories()
    {
        return contactsDataBaseContext.SubCategory.ToList<SubCategory>();
    }

    [HttpGet("subcategory/{id}/{name}")]
    public SubCategory GetSubCategory(int id, string name)
    {
        return contactsDataBaseContext.SubCategory.Find(id, name);
    }
}
