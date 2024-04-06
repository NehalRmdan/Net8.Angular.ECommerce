using System.ComponentModel.DataAnnotations;

namespace core.Entities.Identity
{
    public class Address
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Street { get; set; }

        public string? Building { get; set; }

        public string? Appartment { get; set; }

        public string? ZIPCode { get; set; }

        public string? Mark { get; set; }

        [Required]
        public  string APPUserId { get; set; }

        public  AppUser APPUser { get; set; }


    }
}