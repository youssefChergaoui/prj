using System.ComponentModel.DataAnnotations;

namespace Artisanale.Web.Models
{
    public class ProductDto
    {

        public int ProductId { get; set; }

        public string Libelle { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

    }
}
