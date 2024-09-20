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

        private void AssertResultShouldReturn(List<Product> expected)
        {
            var actual = _cart.Products;
            actual.Should().BeEquivalentTo(expected);
        }
    }
}