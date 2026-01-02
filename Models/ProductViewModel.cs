using System.ComponentModel.DataAnnotations;

namespace ProductosSA.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Description { get; set; } = string.Empty;

        public decimal Cost { get; set; }

        public decimal Price{ get; set; }

        public int? Category { get; set; }

        public bool IsActive { get; set; }
    }
}
