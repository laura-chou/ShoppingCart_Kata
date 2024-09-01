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
            | Promotion: {Promotion}|
            |---------------------------------------|
            | Total products: {TotalProducts}                     |
            | Total price: {TotalPrice}|
            -----------------------------------------";

        private List<Product> _cart;
        private Discount? _useDiscount;
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
            var promotion = string.Empty;
            if (_useDiscount != null)
            {
                var discountAmount = totalPrice * _useDiscount.Amount;
                totalPrice = totalPrice - discountAmount;
                promotion = $"{_useDiscount.Amount * 100}% off with code {_useDiscount.Code}";
            }
            return replacePlaceholders(productRows, promotion, totalProducts, totalPrice);
        }

        public void deleteItem(string productName, int quantity)
        {
            var cartProduct = _cart.FirstOrDefault(p => p.Name == productName);

            if (cartProduct != null)
            {                
                var product = _product.getProduct(productName);
                if (product != null)
                {
                    cartProduct.Price -= product.Price;
                }

                cartProduct.Quantity -= quantity;
                if (cartProduct.Quantity == 0)
                {
                    _cart.Remove(cartProduct);
                }
            }
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
        
        private string replacePlaceholders(string productRows, string promotion, int totalProducts, double totalPrice)
        {
            var replacements = new Dictionary<string, string>
            {
                { "ProductRows", productRows },
                { "Promotion", promotion.PadRight(27) },
                { "TotalProducts", totalProducts.ToString() },
                { "TotalPrice", $"{totalPrice.ToString("F2")} €".PadRight(25) }
            };

            foreach (var item in replacements)
            {
                string placeholder = $"{{{item.Key}}}";
                printTemplate = printTemplate.Replace(placeholder, item.Value);
            }

            return printTemplate;
        }

        public void applyDiscount(string discountCode)
        {
            _useDiscount = new Discount { Code = "PROMO_5", Amount = 0.05 };
        }
    }
}