namespace ShoppingCart.src
{
    public class Discount
    {
        public double Amount { get; set; }
        public string Code { get; set; }

        internal List<Discount> Discounts => new List<Discount>
        {
            new Discount{ Code = "PROMO_5", Amount = 0.05 },
            new Discount{ Code = "PROMO_10", Amount = 0.1 }
        };

        public Discount? getDiscount(string discountCode)
        {
            return Discounts.FirstOrDefault(discount => discount.Code == discountCode);
        }
    }
}