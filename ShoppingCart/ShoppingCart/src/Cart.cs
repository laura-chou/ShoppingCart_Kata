using FluentAssertions.Equivalency;
using System.Text;

namespace ShoppingCart.src
{
    public class Cart
    {
        public List<Product>? Products = new List<Product>();

        internal string printTemplate = @"
                    -----------------------------------------
                    | Product    | Price      | Quantity    |
                    | ---------- | ---------- | ----------- |
                    {ProductRows}
                    | Promotion: {Promotion}|
                    |---------------------------------------|
                    | Total products: {TotalProducts}|
                    | Total price: {TotalPrice}|
                    -----------------------------------------";
        public Cart()
        {
            _product = new Product();
            _discount = new Discount();
        }

        public Discount Promotion { get; set; }
        public double TotalPrice => CalculatePrice();
        private Discount _discount { get; set; }
        private Product _product { get; set; }
        public void addItem(string product, int quantity)
        {
            var price = _product.getProductPrice(product);

            if (price > 0 && quantity > 0)
            {
                Products.Add(new Product
                {
                    Name = product,
                    Quantity = quantity,
                    Price = price * quantity
                });
            }
        }

        public void applyDiscount(string discount)
        {
            Promotion = _discount.getDiscount(discount);
        }

        public void deleteItem(string product, int quantity)
        {
            var item = Products.FirstOrDefault(p => p.Name == product);

            if (item != null)
            {
                item.Quantity -= quantity;

                if (item.Quantity <= 0)
                {
                    Products.Remove(item);
                }
                else
                {
                    item.Price = _product.getProductPrice(item.Name) * item.Quantity;
                }
            }
        }

        public string printShoppingCart()
        {
            StringBuilder productRow = new StringBuilder();
            foreach (var product in Products)
            {
                productRow.AppendLine($"| {product.Name.PadRight(10)} | {$"{product.Price.ToString("F2")} €".PadRight(10)} | {product.Quantity.ToString().PadRight(11)} |");
                productRow.Append(string.Empty.PadRight(20));
            }
            productRow.Append("|---------------------------------------|");

            var totalProduct = Products.Sum(product => product.Quantity);
            var promotion = $"{Promotion.Amount * 100}% off with code {Promotion.Code}";

            var replacements = new Dictionary<string, string>
            {
                { "ProductRows", productRow.ToString() },
                { "Promotion", promotion.PadRight(27) },
                { "TotalProducts", totalProduct.ToString().PadRight(22) },
                { "TotalPrice", $"{TotalPrice.ToString("F2")} €".PadRight(25) }
            };

            foreach (var item in replacements)
            {
                string placeholder = $"{{{item.Key}}}";
                printTemplate = printTemplate.Replace(placeholder, item.Value);
            }

            return printTemplate;
        }

        private double CalculatePrice()
        {
            var price = Products.Sum(product => product.Price);
            var discount = price * Promotion?.Amount;
            return discount != null ? Math.Round((double)(price - discount), 2) : price;
        }
    }
}