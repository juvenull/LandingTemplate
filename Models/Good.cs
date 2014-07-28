using System.ComponentModel.DataAnnotations;

namespace LandingTemplate.Models
{
    public class Good
    {
        //обязательные поля
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Amount { get; set; }
        public string UrlImage { get; set; }

        //опциональные поля
        public decimal PriceOld { get; set; }
        public bool IsHit { get; set; }
        public int AmountSold { get; set; }

    }
}