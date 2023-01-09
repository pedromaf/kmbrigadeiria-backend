using System.Diagnostics.CodeAnalysis;

namespace KMBrigadeiria.Models.Entities
{
    public class Client
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? AddressId { get; set; }
        public virtual Address? Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
