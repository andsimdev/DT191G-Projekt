using System.ComponentModel.DataAnnotations;

namespace DT191G_Projekt.Models
{
    public class ProductCategory
    {
        // Produktkategori-ID
        public int ProductCategoryId { get; set; }

        // Produktkategorinamn
        [Required(ErrorMessage = "Ange produktkategorinamn")]
        [Display(Name = "Kategori")]
        public string? ProductCategoryName { get; set; }

        // Produkter
        public List<Product>? Products { get; set; }
    }
}
