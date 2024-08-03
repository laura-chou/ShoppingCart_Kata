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
            string expected = @"
            -----------------------------------------
            | Product    | Price      | Quantity    |
            | ---------- | ---------- | ----------- |
            | Iceberg    | 1.79 £á     | 1           |
            |---------------------------------------|
            | Promotion:                            |
            |---------------------------------------|
            | Total products: 1                     |
            | Total price: 1.79 £á                   |
            -----------------------------------------";
            AssertResultShouldReturn(expected);
        }

        private void AssertResultShouldReturn(string expected)
        {
            var actual = _cart.printShoppingCart();
            actual.Should().Be(expected);
        }

        private string GenerateExpectedString()
        {
            return @"
            -----------------------------------------
            | Product    | Price      | Quantity    |
            | ---------- | ---------- | ----------- |
            |---------------------------------------|
            | Promotion:                            |
            |---------------------------------------|
            | Total products: 0                     |
            | Total price: 0.00 £á                   |
            -----------------------------------------";
        }
    }
}