using System.ComponentModel;
using System.Text.Json.Serialization;

namespace ShgEcom.Contracts.Authentication
{
    public record RegisterRequest
    {
        [JsonPropertyName("firstName")]
        [DefaultValue("Jaeson")]
        public string FirstName { get; set; } = null!;

        [JsonPropertyName("lastName")]
        [DefaultValue("Joseph")]
        public string LastName { get; set; } = null!;

        [JsonPropertyName("email")]
        [DefaultValue("example.user@gmail.com")]
        public string Email { get; set; } = null!;

        [JsonPropertyName("password")]
        [DefaultValue("SecurePassword123!")]
        public string Password { get; set; } = null!;
    }
}
