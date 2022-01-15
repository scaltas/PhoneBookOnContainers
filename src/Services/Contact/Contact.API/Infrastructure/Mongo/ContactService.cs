using AutoMapper;
using Contact.API.Application;
using Contact.API.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Contact.API.Infrastructure.Mongo
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ContactEntry> _contactsCollection;

        public ContactService(
            IOptions<DatabaseSettings> contactDatabaseSettings, IMapper mapper)
        {
            _mapper = mapper;
            var mongoClient = new MongoClient(
                contactDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                contactDatabaseSettings.Value.DatabaseName);

            _contactsCollection = mongoDatabase.GetCollection<Domain.ContactEntry>(
                contactDatabaseSettings.Value.ContactsCollectionName);
        }

        public async Task<List<ContactEntry>> GetAsync() =>
            await _contactsCollection.Find(_ => true).ToListAsync();

        public async Task<ContactEntry?> GetAsync(string id) =>
            await _contactsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<string> CreateAsync(NewContact contact)
        {
            var contactToInsert = _mapper.Map<ContactEntry>(contact);
            await _contactsCollection.InsertOneAsync(contactToInsert);
            return contactToInsert.Id ?? string.Empty;
        }
            

        public async Task UpdateAsync(string id, ContactEntry updatedContact) =>
            await _contactsCollection.ReplaceOneAsync(x => x.Id == id, updatedContact);

        public async Task RemoveAsync(string id) =>
            await _contactsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
