namespace LandingTemplate.Models
{
    public class GoodDTO
    {
        //обязательные поля
        public int Id { get; set; }
        public string Title { get; set; }    
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string UrlImage { get; set; }

        //опциональные поля
        public decimal PriceOld { get; set; }
        public bool IsHit { get; set; }
    }
}