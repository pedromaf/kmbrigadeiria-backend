
using System.ComponentModel.DataAnnotations;

namespace KMBrigadeiria.Models.DTOs
{
    public class CreateClientDTO
    {
        [Required, MaxLength(200)]
        public string Name { get; set; }
        
        [Required, MaxLength(50)]
        public string PhoneNumber { get; set; }
    }
}