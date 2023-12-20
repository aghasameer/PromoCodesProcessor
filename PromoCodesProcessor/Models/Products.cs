using System.ComponentModel.DataAnnotations.Schema;

namespace PromoCodesProcessor.Models
{
    public class Products
    {

        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        public int CategoryId { get; set; }

        public decimal Price { get; set; }
    }

    public class Products_Data
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public decimal Price { get; set; }

    }

    
}
