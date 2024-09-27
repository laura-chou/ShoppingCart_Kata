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
        [TestCase(new object[] { new[] { "Iceberg,1,2.17" } })]
        [TestCase(new object[] { new[] { "Iceberg,2,4.34" } })]
        [TestCase(new object[] { new[] { "Iceberg,2,4.34", "Tomato,1,0.73", "Chicken,1,1.83", "Bread,1,0.88", "Corn,1,1.50" } })]
        [TestCase(new object[] { new[] { "Apple,2,0" } })]
        [TestCase(new object[] { new[] { "Iceberg,-2,0" } })]
        public void A01_AddItemToCart(string[] addItems)
        {
            var expected = new List<Product>();
            foreach (var item in addItems)
            {
                var data = item.Split(',');
                var name = data[0];
                var quantity = int.Parse(data[1]);
                var price = double.Parse(data[2]);

                _cart.addItem(name, quantity);

                if (price > 0)
                {
                    expected.Add(new Product
                    {
                        Name = name,
                        Quantity = quantity,
                        Price = price
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