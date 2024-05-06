using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoralieHotel.Models
{
    public class Categorie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "maxlength is 30")]
        [DisplayName("Category Name")]
        public string? Name { get; set; }
    }
}
