using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DT191G_Projekt.Models
{
    public class Product
    {
        // Produkt-ID
        public int ProductId { get; set;}

        // Produktnamn
        [Required(ErrorMessage = "Ange produktnamn")]
        [Display(Name = "Produktnamn")]
        public string? ProductName { get; set;}

        // Produktbeskrivning
        [Required(ErrorMessage = "Ange produktbeskrivning")]
        [Display(Name = "Beskrivning")]
        public string? ProductDescription { get; set;}

        // Produktpris
        [Required(ErrorMessage = "Ange produktpris")]
        [Display(Name = "Pris")]
        public int? ProductPrice { get; set;}

        // Produktbild-namn
        [Display(Name = "Bildnamn")]
        public string? ProductImageName { get; set;}

        // Produktbild-fil
        [NotMapped]
        [Display(Name = "Bildfil")]
        public IFormFile? ProductImageFile { get; set;}

        // Produktkategori
        [Required]
        [Display(Name = "Kategori")]
        public int ProductCategoryId { get; set;}
        [Display(Name = "Kategori")]
        public ProductCategory? ProductCategory { get; set;}

        // Uppdaterad av (användarnamn)
        [Display(Name = "Senast uppdaterad av")]
        public string? UpdatedBy { get; set; }

        // Uppdaterad datum (datumstämpel)
        [Display(Name = "Senast uppdaterad (datum)")]
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
    }
}
