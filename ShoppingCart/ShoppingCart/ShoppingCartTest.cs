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
        public void A00_StepUp()
        {
            _cart = new Cart();
        }

        [Test]
        public void A01_EmptyCart()
        {
            string expected = GenerateEmptyExpectedString();
            AssertResultShouldReturn(expected);
        }

        [TestCaseSource(nameof(AddItemToCartTestCases))]
        public void A02_AddItemToCart(Dictionary<string, int> addItems, string expected)
        {
            foreach (var item in addItems)
            {
                _cart.addItem(item.Key, item.Value);
            }
            AssertResultShouldReturn(expected);
        }

        [TestCaseSource(nameof(DeleteItemToCartTestCases))]
        public void A03_DeleteItemToCart(Dictionary<string, int> addItems, Dictionary<string, int> deleteItems, string expected)
        {
            foreach (var item in addItems)
            {
                _cart.addItem(item.Key, item.Value);
            }
            foreach (var item in deleteItems)
            {
                _cart.deleteItem(item.Key, item.Value);
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
            -----------------------------------------")
                    .SetArgDisplayNames("add Iceberg");

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
            -----------------------------------------")
                    .SetArgDisplayNames("add Iceberg, Tomato");
            }
        }

        private static IEnumerable DeleteItemToCartTestCases
        {
            get
            {
                yield return new TestCaseData(
                    new Dictionary<string, int>
                    {
                        { "Chicken", 1 },
                        { "Bread", 1 }
                    },
                    new Dictionary<string, int>
                    {
                        { "Bread", 1 }
                    }, @"
            -----------------------------------------
            | Product    | Price      | Quantity    |
            | ---------- | ---------- | ----------- |
            | Chicken    | 1.83 £á    | 1            |
            |---------------------------------------|
            | Promotion:                            |
            |---------------------------------------|
            | Total products: 1                     |
            | Total price: 1.83 £á                   |
            -----------------------------------------")
                    .SetArgDisplayNames("add Chicken, Bread and delete Bread");
            }
        }

        private void AssertResultShouldReturn(string expected)
        {
            var actual = _cart.printShoppingCart();
            actual.Should().Be(expected);
        }

        private string GenerateEmptyExpectedString()
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