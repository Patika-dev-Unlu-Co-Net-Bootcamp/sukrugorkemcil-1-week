using System.ComponentModel.DataAnnotations;

namespace StockApi.Model
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Color { get; set; }

        public int Size { get; set; }
    }
}
