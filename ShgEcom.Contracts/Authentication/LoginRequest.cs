using System.ComponentModel;
using System.Text.Json.Serialization;

namespace ShgEcom.Contracts.Authentication
{
    public record LoginRequest
    {
        [JsonPropertyName("email")]
        [DefaultValue("jkjoseph2023@gmail.com")]
        public string Email { get; set; } =  null!;

        [JsonPropertyName("password")]
        [DefaultValue("SecurePassword123!")]
        public string Password { get; set; } = null!;
    }


}
