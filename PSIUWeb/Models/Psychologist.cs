using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSIUWeb.Models
{

    public class Psychologist
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome requerido.")]
        [Display(Name = "Nome")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "CRP requerido.")]
        [Display(Name = "CRP")]
        public string? Crp { get; set; }

        [Required(ErrorMessage = "O campo liberado é requerido.")]
        [Display(Name = "Liberado")]
        public bool IsAllowed { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public AppUser? User { get; set; }
    }
}
