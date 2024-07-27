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
        public void A01_EmptyCart()
        {
            string expected = GenerateExpectedString();
            AssertResultShouldReturn(expected);
        }

        [Test]
        public void A02_AddItemToCart()
        {
            _cart.addItem("Iceberg", 1);
            string expected = 
                "-----------------------------------------\n" +
                "| Product    | Price      | Quantity    |\n" +
                "| ---------- | ---------- | ----------- |\n" +
                "| Iceberg    | 2.17 £á     | 1           |\n" +
                "|---------------------------------------|\n" +
                "| Promotion:                            |\n" +
                "|---------------------------------------|\n" +
                "| Total products: 1                     |\n" +
                "| Total price: 2.17 £á                   |\n" +
                "-----------------------------------------";
            AssertResultShouldReturn(expected);
        }

        private void AssertResultShouldReturn(string expected)
        {
            var actual = _cart.printShoppingCart();
            actual.Should().Be(expected);
        }

        private string GenerateExpectedString()
        {
            return 
                "-----------------------------------------\n" +
                "| Product    | Price      | Quantity    |\n" +
                "| ---------- | ---------- | ----------- |\n" +
                "|---------------------------------------|\n" +
                "| Promotion:                            |\n" +
                "|---------------------------------------|\n" +
                "| Total products: 0                     |\n" +
                "| Total price: 0.00 £á                   |\n" +
                "-----------------------------------------";
        }
    }
}