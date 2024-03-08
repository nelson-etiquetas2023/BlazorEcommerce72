using System.ComponentModel.DataAnnotations;

namespace DataflowWebApiNet8.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductCategory { get; set; } = string.Empty;
        public double ProductPrice { get; set; }
        public string ProductBarCode { get; set; }
    }
}
