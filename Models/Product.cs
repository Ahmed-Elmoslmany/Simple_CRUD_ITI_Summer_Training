using System.ComponentModel.DataAnnotations.Schema;

namespace demo.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }

        
        public string details { get; set; }

        public virtual Category Category { get; set; }

        [ForeignKey("Category")]
        public int? Category_ID { get; set; }
    }
}
