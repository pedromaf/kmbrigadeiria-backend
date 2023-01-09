using KMBrigadeiria.Models.Entities;

namespace KMBrigadeiria.Models.DTOs
{
    public class ReadClientDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ReadAddressDTO Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
