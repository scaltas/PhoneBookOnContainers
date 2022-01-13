namespace Contact.API.Domain
{
    public class ContactInfo
    {
        public ContactType Type { get;}
        public string Value { get;}
        public ContactInfo(string value, ContactType type)
        {
            Value = value;
            Type = type;
        }
    }
}