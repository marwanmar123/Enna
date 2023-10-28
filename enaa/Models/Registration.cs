using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace enaa.Models
{
    public class Registration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Id { get; set; }
        [Required]
        public string? Nom { get; set; }
        [Required]
        public string? Prenom { get; set; }
        public string? Genre { get; set; }
        public DateTime? DateDeN { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public int? Phone { get; set; }

        [Required]
        public string? Cin { get; set; }
        public string? BrancheBac { get; set; }
        public string? NiveauAcad { get; set; }
        public string? FiliereAcad { get; set; }
        public string? AutreFiliereAcad { get; set; }
        public DateTime? DernierDip { get; set; }
        public string? Etablissement { get; set; }
        public DateTime? AnneeDiplome { get; set; }
        public string? Experience { get; set; }
        public string? SiOuiExperience { get; set; }
        public string? Ville { get; set; }
        public string? Comment { get; set; }
        public DateTime? RegisteredOn { get; set; } = DateTime.Now;
    }
}
