using KMBrigadeiria.Models.Enums;
using KMBrigadeiria.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace KMBrigadeiria.Models.DTOs
{
    public class UpdateAddressDTO
    {
        [ValidId]
        public long Id { get; set; }

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
