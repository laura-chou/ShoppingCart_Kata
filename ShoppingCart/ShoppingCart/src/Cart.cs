namespace ShoppingCart.src
{
    public class Cart
    {
        public List<Product>? Products = new List<Product>();
        private Product _product { get; set; }
        public double TotalPrice => Products.Sum(product => product.Price);

        public Cart() { 
            _product = new Product();
        }

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
    }
}