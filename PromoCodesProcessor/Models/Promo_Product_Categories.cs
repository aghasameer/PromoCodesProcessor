using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromoCodesProcessor.Models
{
    public class Promo_Product_Categories
    {

        public required int Id { get; set; }

        public required int Promo_Id { get; set; }
        
        public required int Category_Id { get; set; }

    }

    public class Promo_Categories_Data
    {
        public int category_id { get; set; }
        public string category_name { get; set; } = string.Empty;
    }
}
