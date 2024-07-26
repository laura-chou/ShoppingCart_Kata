namespace ShoppingCart.src
{
    public class Cart
    {
        public string printShoppingCart()
        {
            return "-----------------------------------------\n" +
                "| Product    | Price      | Quantity    |\n" +
                "| ---------- | ---------- | ----------- |\n" +
                "|---------------------------------------|\n" +
                "| Promotion:                            |\n" +
                "|---------------------------------------|\n" +
                "| Total products: 0                     |\n" +
                "| Total price: 0.00 €                   |\n" +
                "-----------------------------------------";
        }
    }
}