using System.ComponentModel.DataAnnotations.Schema;

namespace enaa.Models
{
    public class Menu
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Id { get; set; }
        public string? TitleMenu { get; set; }
        public string? Link { get; set; }
        public string? Color { get; set; } = "white";
        public int? Size { get; set; } = 18;
    }
}
