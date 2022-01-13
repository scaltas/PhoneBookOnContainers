using Contact.API.Application;
using Contact.API.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService) =>
            _contactService = contactService;

        [HttpGet]
        public async Task<List<ContactEntry>> Get() =>
            await _contactService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<ContactEntry>> Get(string id)
        {
            var contact = await _contactService.GetAsync(id);

            if (contact is null)
            {
                return NotFound();
            }

            return contact;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ContactEntry newContact)
        {
            await _contactService.CreateAsync(newContact);

            return CreatedAtAction(nameof(Get), new { id = newContact.Id }, newContact);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, ContactEntry updatedContact)
        {
            var contact = await _contactService.GetAsync(id);

            if (contact is null)
            {
                return NotFound();
            }

            await _contactService.UpdateAsync(id, updatedContact);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var contact = await _contactService.GetAsync(id);

            if (contact is null)
            {
                return NotFound();
            }

            await _contactService.RemoveAsync(contact.Id);

            return NoContent();
        }
    }
}
