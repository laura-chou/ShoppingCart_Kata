namespace ShoppingCart.src
{
    public class Cart
    {
        public List<Product>? Products { get; set; }

        public Cart() { 
            Products = new List<Product>();
        }

        public void addItem(string product, int quantity)
        {
            Products.Add(new Product
            {
                Name = product,
                Quantity = quantity,
                Price = 2.17
            });
        }
    }
}