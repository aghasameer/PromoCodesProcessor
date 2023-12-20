using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromoCodesProcessor.Models
{
    public class Promo_Users
    {
        public required int Id { get; set; }
        
        public int Promo_Id { get; set; }
        
        public int User_id { get; set; }

    }

    public class Promo_Users_Data
    {
        public int user_id { get; set; }
        public string user_name { get; set; } = string.Empty;
    }
}
