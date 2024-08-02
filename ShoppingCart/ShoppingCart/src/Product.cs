namespace ShoppingCart.src
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        internal List<Product> Products => new List<Product>
        {
            new Product{ Name = "Iceberg", Price = 1.79 },
            new Product{ Name = "Tomato", Price = 0.60 },
            new Product{ Name = "Chicken", Price = 1.51 },
            new Product{ Name = "Bread", Price = 0.80 },
            new Product{ Name = "Corn", Price = 1.36 }
        };

        public Product? getProduct(string productName)
        {
            return Products.FirstOrDefault(product => product.Name == productName);
        }
    }
}