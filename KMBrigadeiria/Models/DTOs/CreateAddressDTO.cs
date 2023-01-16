using System.ComponentModel.DataAnnotations;

namespace KMBrigadeiria.Models.DTOs
{
    public class CreateAddressDTO
    {
        [Required, MaxLength(50)]
        public string State { get; set; }

        [Required, MaxLength(50)]
        public string City { get; set; }

        [Required, MaxLength(50)]
        public string Neighborhood { get; set; }

        [Required, MaxLength(50)]
        public string Street { get; set; }

        public int? Number { get; set; }

        [Required, MaxLength(50)]
        public string Complement { get; set; }
    }
}
