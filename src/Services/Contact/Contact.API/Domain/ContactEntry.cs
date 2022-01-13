namespace Contact.API.Domain
{
    public class ContactEntry
    {
        public string Id { get; }
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public string Company { get; protected set; }
        public List<ContactInfo> ContactInfos { get; protected set; }
        public ContactEntry(string name, string surname, string company, List<ContactInfo> contactInfos)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Surname = surname;
            Company = company;
            ContactInfos = contactInfos;
        }



    }
}
