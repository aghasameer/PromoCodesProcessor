using System.ComponentModel.DataAnnotations.Schema;

namespace PromoCodesProcessor.Models
{
    public class Promo_Redeems
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Promos_Id { get; set; }

        public int User_Id { get; set; }
    }

}
