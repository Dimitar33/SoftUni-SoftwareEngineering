using System.ComponentModel.DataAnnotations;

namespace PetsDates.Data.Models
{
    public class Moderator 
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public string UserId { get; set; }
    }
}
