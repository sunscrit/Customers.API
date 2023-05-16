using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Customers.Application.Models
{
    public class CreateCustomerRequest
    {
        [Required]
        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }

        [Required]
        [JsonPropertyName("surname")]
        public string Surname { get; set; }
    }
}
