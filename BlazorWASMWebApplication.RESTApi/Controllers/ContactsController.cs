using Microsoft.AspNetCore.Mvc;
using BlazorWASMWebApplication.Shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

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
        return contactsDataBaseContext.Contact.Include(c => c.Category).ToList<Contact>();
    }

    [HttpGet("contact/{id}")]
    public Contact GetContact(int id)
    {
        return contactsDataBaseContext.Contact.Find(id);
    }

    [HttpGet("categories")]
    public IEnumerable<Category> GetCategories()
    {
        return contactsDataBaseContext.Category.Include(c => c.SubCategories).ToList<Category>();
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


    [HttpPut("contact")]
    public Contact SaveContact([FromBody] Contact contact)
    {
        if (contact.Id == null)
        {
            contactsDataBaseContext.Add(contact).State = EntityState.Added;
        }
        else
        {
            contactsDataBaseContext.Entry(contact).State = EntityState.Modified;
        }
        try
        {
            contactsDataBaseContext.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            if (contactsDataBaseContext.Contact.FirstOrDefaultAsync(c => c.Id == contact.Id) == null)
            {
                throw new EntryPointNotFoundException("Contact:id=" + contact.Id);
            }
            else
            {
                throw;
            }
        }
        return contact;
    }
}
