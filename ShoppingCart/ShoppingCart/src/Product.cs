namespace ShoppingCart.src
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        private List<Product> Products => new List<Product>
        {
            new Product{ Name = "Iceberg", Price = 2.17 }
        };

        public double getProductPrice(string productName)
        {
            var product = Products.FirstOrDefault(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            return product != null ? product.Price : 0;
        }
    }
}