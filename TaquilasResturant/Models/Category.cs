using System.ComponentModel.DataAnnotations;
using TequliasRestaurant.Models;

namespace TaquilasResturant.Models
{
    public class Category
    {
        [Key]
        public int CartegoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}