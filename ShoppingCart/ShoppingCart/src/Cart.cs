using System.Text;

namespace ShoppingCart.src
{
    public class Cart
    {
        internal string printTemplate = @"
            -----------------------------------------
            | Product    | Price      | Quantity    |
            | ---------- | ---------- | ----------- |
            {ProductRows}
            | Promotion: {Promotion}                           |
            |---------------------------------------|
            | Total products: {TotalProducts}                     |
            | Total price: {TotalPrice} €                   |
            -----------------------------------------";

        private List<Product> _cart;
        private Product _product;
        public Cart()
        {
            _cart = new List<Product>();
            _product = new Product();
        }

        public void addItem(string productName, int quantity)
        {
            var product = _product.getProduct(productName);

            if (product != null)
            {
                _cart.Add(new Product
                {
                    Name = product.Name,
                    Price = product.Price * quantity,
                    Quantity = quantity
                });
            }
        }

        public string printShoppingCart()
        {
            var totalProducts = _cart.Sum(p => p.Quantity);
            var totalPrice = _cart.Sum(p => p.Price);
            string productRows = buildProductRows();

            return replacePlaceholders(productRows, totalProducts, totalPrice);
        }

        private string buildProductRows()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var product in _cart)
            {
                sb.AppendLine($"| {product.Name.PadRight(10)} | {$"{product.Price.ToString("F2")} €".PadRight(10)} | {product.Quantity.ToString().PadRight(11)} |");
                sb.Append(string.Empty.PadRight(12));
            }

            sb.Append("|---------------------------------------|");
            return sb.ToString();
        }
        
        private string replacePlaceholders(string productRows, int totalProducts, double totalPrice)
        {
            var replacements = new Dictionary<string, string>
            {
                { "ProductRows", productRows },
                { "Promotion", string.Empty },
                { "TotalProducts", totalProducts.ToString() },
                { "TotalPrice", totalPrice.ToString("F2") }
            };

            foreach (var item in replacements)
            {
                string placeholder = $"{{{item.Key}}}";
                printTemplate = printTemplate.Replace(placeholder, item.Value);
            }

            return printTemplate;
        }
    }
}