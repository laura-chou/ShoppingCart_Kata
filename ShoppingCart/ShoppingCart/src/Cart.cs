﻿namespace ShoppingCart.src
{
    public class Cart
    {
        public List<Product>? Products = new List<Product>();
        private Product _product { get; set; }

        public Cart() { 
            _product = new Product();
        }

        public void addItem(string product, int quantity)
        {
            var price = _product.getProductPrice(product);
            
            if (price > 0)
            {
                Products.Add(new Product
                {
                    Name = product,
                    Quantity = quantity,
                    Price = price * quantity
                });
            }
        }
    }
}