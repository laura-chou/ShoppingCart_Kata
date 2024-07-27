namespace ShoppingCart.src
{
    public class Cart
    {
        public string printShoppingCart()
        {
            var totalProducts = 0;
            var totalPrice = 0;
            return "-----------------------------------------\n" +
                "| Product    | Price      | Quantity    |\n" +
                "| ---------- | ---------- | ----------- |\n" +
                "|---------------------------------------|\n" +
                "| Promotion:                            |\n" +
                "|---------------------------------------|\n" +
               $"| Total products: {totalProducts}                     |\n" +
               $"| Total price: {totalPrice.ToString("F2")} €                   |\n" +
                "-----------------------------------------";
        }

        internal void addItem(string v1, int v2)
        {
            throw new NotImplementedException();
        }
    }
}