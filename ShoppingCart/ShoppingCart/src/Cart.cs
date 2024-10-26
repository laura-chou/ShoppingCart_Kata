using FluentAssertions.Equivalency;

namespace ShoppingCart.src
{
    public class Cart
    {
        public List<Product>? Products = new List<Product>();
        public Cart()
        {
            _product = new Product();
        }

        public Discount Promotion { get; set; }
        public double TotalPrice => CalculatePrice();
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
            Promotion = new Discount
            {
                Code = discount,
                Amount = 0.05
            };
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

        private double CalculatePrice()
        {
            var price = Products.Sum(product => product.Price);
            var discount = price * Promotion?.Amount;
            return discount != null ? Math.Round((double)(price - discount), 2) : price;
        }
    }
}