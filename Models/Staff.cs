using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DT191G_Projekt.Models
{
    public class Staff
    {
        // Personal-ID
        public int StaffId { get; set; }

        // Personalnamn
        [Required(ErrorMessage = "Ange personalens namn")]
        [Display(Name = "Personals namn")]
        public string? StaffName { get; set; }

        // Personaltitel
        [Display(Name = "Titel")]
        [Required(ErrorMessage = "Ange personalens titel")]
        public string? StaffRole { get; set; }

        // Personalmail
        [Display(Name = "E-post")]
        public string? StaffMail { get; set; }

        // Personalbild-namn
        [Display(Name = "Personalbildsnamn")]
        public string? StaffImageName { get; set; }

        // Personalbild-fil
        [NotMapped]
        [Display(Name = "Personalbild")]
        public IFormFile? StaffImageFile { get; set; }

        // Uppdaterad av (användare)
        [Display(Name = "Senast uppdaterad av")]
        public string? UpdatedBy { get; set; }

        // Uppdaterad datum (datumstämpel)
        [Display(Name = "Senast uppdaterad (datum)")]
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
    }
}
