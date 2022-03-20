using System.ComponentModel.DataAnnotations;

namespace DT191G_Projekt.Models
{
    // FÖRETAGSINFORMATION
    public class Company
    {
        // Företags-ID
        public int Id { get; set; }

        // Företagsnamnet
        [Required(ErrorMessage = "Ange företagsnamn")]
        [Display(Name = "Företagets namn")]
        public string? CompanyName { get; set; }

        // Telefon
        [Display(Name = "Telefonnummer")]
        public int? CompanyPhone { get; set; }

        // E-post
        [Display(Name = "E-post")]
        public string? CompanyMail { get; set; }

        // Adress
        [Display(Name = "Adress")]
        public string? CompanyAddress { get; set; }

        // Beskrivning
        [Display(Name = "Beskrivning av företaget")]
        public string? CompanyDescription { get; set; }

        // Öppet måndagar
        [Display(Name = "Öppettider måndagar")]
        public string? OpenMonday { get; set; }

        // Öppet tisdagar
        [Display(Name = "Öppettider tisdagar")]
        public string? OpenTuesday { get; set; }

        // Öppet onsdagar
        [Display(Name = "Öppettider onsdagar")]
        public string? OpenWednedsay { get; set; }

        // Öppet torsdagar
        [Display(Name = "Öppettider torsdagar")]
        public string? OpenThursday { get; set; }

        // Öppet fredagar
        [Display(Name = "Öppettider fredagar")]
        public string? OpenFriday { get; set; }

        // Öppet lördagar
        [Display(Name = "Öppettider lördagar")]
        public string? OpenSaturday { get; set; }

        // Öppet söndagar
        [Display(Name = "Öppettider söndagar")]
        public string? OpenSunday { get; set; }

        // Uppdaterad av (användare)
        [Display(Name = "Senast uppdaterad av")]
        public string? UpdatedBy { get; set; }

        // Uppdaterad datum (datumstämpel)
        [Display(Name = "Senast uppdaterad (datum)")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}