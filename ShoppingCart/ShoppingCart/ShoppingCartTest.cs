using FluentAssertions;
using NUnit.Framework;
using ShoppingCart.src;
using System.Collections;

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
        
        [TestCaseSource(nameof(AddItemToCartTestCases))]
        public void A02_AddItemToCart(Dictionary<string, int> items,string expected)
        {
            foreach (var item in items)
            {
                _cart.addItem(item.Key, item.Value);
            }
            AssertResultShouldReturn(expected);
        }

        private static IEnumerable AddItemToCartTestCases
        {
            get
            {
                yield return new TestCaseData(
                    new Dictionary<string, int>
                    {
                        { "Iceberg", 1 }
                    }, @"
            -----------------------------------------
            | Product    | Price      | Quantity    |
            | ---------- | ---------- | ----------- |
            | Iceberg    | 1.79 £á     | 1           |
            |---------------------------------------|
            | Promotion:                            |
            |---------------------------------------|
            | Total products: 1                     |
            | Total price: 1.79 £á                   |
            -----------------------------------------");

                yield return new TestCaseData(
                    new Dictionary<string, int>
                    {
                        { "Iceberg", 2 },
                        { "Tomato", 1 }
                    }, @"
            -----------------------------------------
            | Product    | Price      | Quantity    |
            | ---------- | ---------- | ----------- |
            | Iceberg    | 3.58 £á     | 2           |
            | Tomato     | 0.60 £á     | 1           |
            |---------------------------------------|
            | Promotion:                            |
            |---------------------------------------|
            | Total products: 3                     |
            | Total price: 4.18 £á                   |
            -----------------------------------------");
            }
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