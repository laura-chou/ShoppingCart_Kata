namespace ShoppingCart.src
{
    public class Discount
    {
        public string Code { get; set; }
        public double Amount { get; set; }
        private List<Discount> Discounts => new List<Discount>
        {
            new Discount{ Code = "PROMO_5", Amount = 0.05 },
            new Discount{ Code = "PROMO_10", Amount = 0.1 }
        };

        public Discount getDiscount(string discount)
        {
            var data = Discounts.FirstOrDefault(p => p.Code.Equals(discount, StringComparison.OrdinalIgnoreCase));
            return data != null ? data : new Discount();
        }
    }
}