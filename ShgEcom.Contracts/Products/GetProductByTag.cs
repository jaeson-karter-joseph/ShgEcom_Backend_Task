using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShgEcom.Contracts.Products
{
    public record GetProductByTag
    {
        [Required]
        [JsonPropertyName("tag")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 100 characters")]
        [DefaultValue("default")]
        [SwaggerSchema(Description = "Tag name")]
        public string Tag { get; set; } = null!;
    }

}
