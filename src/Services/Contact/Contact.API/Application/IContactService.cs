using Contact.API.Domain;

namespace Contact.API.Application;

public interface IContactService
{
    Task<List<ContactEntry>> GetAsync();
    Task<ContactEntry?> GetAsync(string id);
    Task CreateAsync(ContactEntry contact);
    Task UpdateAsync(string id, ContactEntry updatedContact);
    Task RemoveAsync(string id);
}