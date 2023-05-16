using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Customers.Application.Models
{
    public class CustomerDto
    {
        [Required]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }

        [Required]
        [JsonPropertyName("surname")]
        public string Surname { get; set; }
    }
}
