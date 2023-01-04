using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models
{
    public record Platform
    {
        [Key]
        [Required]
        public int Id { get; init; }

        [Required]
        public string Name { get; init; }

        [Required]
        public string Publisher { get; init; }

        [Required]
        public string Cost { get; init; }
    }
}