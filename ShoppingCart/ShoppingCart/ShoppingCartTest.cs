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
            var actual = _cart.printShoppingCart();
            var expected = 
                "-----------------------------------------\n" +
                "| Product    | Price      | Quantity    |\n" +
                "| ---------- | ---------- | ----------- |\n" +
                "|---------------------------------------|\n" +
                "| Promotion:                            |\n" +
                "|---------------------------------------|\n" +
                "| Total products: 0                     |\n" +
                "| Total price: 0.00 £á                   |\n" +
                "-----------------------------------------";
            actual.Should().Be(expected);
        }
    }
}