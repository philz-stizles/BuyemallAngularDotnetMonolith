using System.ComponentModel.DataAnnotations;

namespace BuyEmAll.API.Dtos.Account
{
    public class AddressDto
    {
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
