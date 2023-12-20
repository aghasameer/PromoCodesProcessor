using System.ComponentModel.DataAnnotations.Schema;

namespace PromoCodesProcessor.Models
{
    public class Promo_Codes
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }

        public required string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        // Type 1 is the default value which represents Percentage discount. Type 2 is a Fixed Amount.
        public required int Discount_Type { get; set; } = 1;
        public required decimal Discount_Value { get; set; } = decimal.Zero;

        // Default value for free shipping is false unless changed by user.
        public required bool Shipping_Free { get; set; } = false;

        public required decimal Minimum_Order { get; set; } = Decimal.Zero;

        public required bool Multiple_Use { get; set; } = false;

        public List<Promo_Product_Categories>? Promo_Categories { get; set; }

        public List<Promo_Users>? Promo_Users { get; set; }


    }

    public class Promos_Data
    {

        public int? id { get; set; }

        public string name { get; set; } = string.Empty;
        public string? description { get; set; } = string.Empty;

        public int discount_type { get; set; } = 1;
        public decimal discount_value { get; set; } = 1;

        public bool free_shipping { get; set; } = false;

        public decimal min_order { get; set; } = Decimal.Zero;

        public bool multiple_use { get; set; } = false;

        public int redeem_count { get; set; }

        public List<Promo_Categories_Data>? categories { get; set; }

        public List<Promo_Users_Data>? users { get; set; }

        public Promos_Data()
        {
            categories = new List<Promo_Categories_Data>();
            users = new List<Promo_Users_Data>();
        }

    }

    public class CreatePromo
    {

        public required string name { get; set; } = string.Empty;
        public string? description { get; set; } = string.Empty;

        public required int discount_type { get; set; } = 1;
        public required decimal discount_value { get; set; } = 1;

        public required bool free_shipping { get; set; } = false;

        public required decimal min_order { get; set; } = Decimal.Zero;

        public required bool multiple_use { get; set; } = false;

        public string? categories { get; set; } = string.Empty;

        public string? users { get; set; } = string.Empty;

    }


    public class UpdatePromo
    {

        public int? id { get; set; }
        public string? description { get; set; } = string.Empty;

        public required int discount_type { get; set; } = 1;
        public required decimal discount_value { get; set; } = 1;

        public required bool free_shipping { get; set; } = false;

        public required decimal min_order { get; set; } = Decimal.Zero;

        public required bool multiple_use { get; set; } = false;

        public string? categories { get; set; } = string.Empty;

        public string? users { get; set; } = string.Empty;

    }

    public class CheckRedeem
    {
        public int user_id { get; set; }

        public string promo_code { get; set; } = string.Empty;
    }

    public class PurchasePromo
    {
        public int user_id { get; set; }
        public int promo_id { get; set; }
    }

    public class RedeemPromoData
    {
        public int promo_id { get; set; }
        public int discount_type { get; set; }
        public decimal discount_value { get; set; }
        public bool shipping_free { get; set; }
        public decimal min_order { get; set; }
        public List<Promo_Categories_Data> allowed_categories { get; set; }

        public RedeemPromoData()
        {
            allowed_categories = new List<Promo_Categories_Data>();
        }
    }
}
