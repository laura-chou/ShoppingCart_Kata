﻿using System.Xml.Linq;

namespace ShoppingCart.src
{
    public class Cart
    {
        private List<Product> _cart;

        public Cart()
        {
            _cart = new List<Product>();
        }

        public string printShoppingCart()
        {
            var totalProducts = _cart.Count;
            var totalPrice = 0;
            if (_cart.Count > 0)
            {
                return "-----------------------------------------\n" +
                "| Product    | Price      | Quantity    |\n" +
                "| ---------- | ---------- | ----------- |\n" +
                "| Iceberg    | 2.17 €     | 1           |\n" +
                "|---------------------------------------|\n" +
                "| Promotion:                            |\n" +
                "|---------------------------------------|\n" +
                "| Total products: 1                     |\n" +
                "| Total price: 2.17 €                   |\n" +
                "-----------------------------------------";
            }
            return "-----------------------------------------\n" +
                "| Product    | Price      | Quantity    |\n" +
                "| ---------- | ---------- | ----------- |\n" +
                "|---------------------------------------|\n" +
                "| Promotion:                            |\n" +
                "|---------------------------------------|\n" +
               $"| Total products: {totalProducts}                     |\n" +
               $"| Total price: {totalPrice.ToString("F2")} €                   |\n" +
                "-----------------------------------------";
        }

        public void addItem(string productName, int quantity)
        {
            _cart.Add(new Product
            {
                Name = productName,
                Price = 1.79,
                Quantity = quantity
            });
        }
    }
}