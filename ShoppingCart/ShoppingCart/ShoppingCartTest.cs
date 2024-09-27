using FluentAssertions;
using NUnit.Framework;
using ShoppingCart.src;

namespace ShoppingCart
{
    [TestFixture]
    public class Tests
    {
        private Cart _cart;

        [SetUp]
        public void A00_StepUp()
        {
            _cart = new Cart();
        }

        [Test]
        [TestCase(new[] { "Iceberg" }, new[] { 1 }, new[] { 2.17 })]
        [TestCase(new[] { "Iceberg" }, new[] { 2 }, new[] { 4.34 })]
        [TestCase(
            new[] { "Iceberg", "Tomato", "Chicken", "Bread", "Corn" },
            new[] { 2, 1, 1, 1, 1 },
            new[] { 4.34, 0.73, 1.83, 0.88, 1.50 }
        )]
        [TestCase(new[] { "Apple" }, new[] { 2 }, new[] { 0.00 })]
        [TestCase(new[] { "Iceberg" }, new[] { -2 }, new[] { 0.00 })]
        public void A01_AddItemToCart(string[] productNames, int[] quantities, double[] prices)
        {
            var expected = new List<Product>();
            
            for (int i = 0; i < productNames.Length; i++)
            {
                _cart.addItem(productNames[i], quantities[i]);

                if (prices[i] > 0)
                {
                    expected.Add(new Product
                    {
                        Name = productNames[i],
                        Quantity = quantities[i],
                        Price = prices[i]
                    });
                }
            }

            AssertResultShouldReturn(expected);
        }

        [Test]
        [TestCase(new[] { "Bread,2" }, new[] { "Bread,1" }, new[] { "Bread,1,0.88" })]
        public void A02_DeleteItemToCart(string[] addItems, string[] deleteItems, string[] expectedItems)
        {
            foreach (var item in addItems)
            {
                var data = item.Split(",");
                _cart.addItem(data[0], int.Parse(data[1]));
            }

            foreach (var item in deleteItems)
            {
                var data = item.Split(",");
                _cart.deleteItem(data[0], int.Parse(data[1]));
            }

            var expected = expectedItems.Select(item =>
            {
                var parts = item.Split(',');
                return new Product
                {
                    Name = parts[0],
                    Quantity = int.Parse(parts[1]),
                    Price = double.Parse(parts[2])
                };
            }).ToList();

            AssertResultShouldReturn(expected);
        }

        private void AssertResultShouldReturn(List<Product> expected)
        {
            var actual = _cart.Products;
            actual.Should().BeEquivalentTo(expected);
        }
    }
}