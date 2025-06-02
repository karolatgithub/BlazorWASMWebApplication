using Microsoft.AspNetCore.Mvc;
using BlazorWASMWebApplication.Shared;
using BlazorWASMWebApplication.Shared.Model;
using System.Runtime.CompilerServices;

namespace BlazorWASMWebApplication.RESTApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly ContactsDataBaseContext contactsDataBaseContext;
    public ContactController(ContactsDataBaseContext contactsDataBaseContext)
    {
        this.contactsDataBaseContext = contactsDataBaseContext;
    }

    [HttpGet]
    public IEnumerable<Contact> Get()
    {
        return contactsDataBaseContext.Contact.ToList<Contact>();
    }
}
