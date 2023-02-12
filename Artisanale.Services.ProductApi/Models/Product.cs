using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artisanale.Services.ProductApi.Models
{

    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [ StringLength(25)]
        public string Libelle { get; set; }
        [Range(1,1000)]
        public double Price { get; set; }

        public string Description  { get; set; }

        public string CategoryName { get; set; }

        public string  ImageUrl { get; set; }


    }
}
