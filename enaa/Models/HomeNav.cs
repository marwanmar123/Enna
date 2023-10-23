using System.ComponentModel.DataAnnotations.Schema;

namespace enaa.Models
{
    public class HomeNav
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Id { get; set; }
        public string? BgNav { get; set; }
        public string? LogoSize { get; set; }
    }
}
