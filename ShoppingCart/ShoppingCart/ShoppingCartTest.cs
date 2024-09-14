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
        public void A00_StepUp ()
        {
            _cart = new Cart ();
        }

        [Test]
        public void A01_AddItemToCart()
        {
            _cart.addItem("Iceberg", 1);
            var expected = new List<Product>
                {
                    new Product 
                    {
                        Name = "Iceberg",
                        Quantity = 1,
                        Price = 2.17
                    }
                };
            var actual = _cart.Products;
            actual.Should().BeEquivalentTo(expected);
        }
    }
}