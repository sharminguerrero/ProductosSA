using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductosSA.Entities
{
    public class Products
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Description { get; set; } = string.Empty;

        public decimal Cost { get; set; }

        public decimal Price { get; set; }

        public int? CategoryId {  get; set; }

        public bool IsActive { get; set; } = true;

        [ForeignKey(nameof(CategoryId))]
        public Categories? Category { get; set; }

    }
}
