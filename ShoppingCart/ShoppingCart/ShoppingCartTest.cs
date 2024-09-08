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

        [TestCaseSource(nameof(UseDiscountsTestCases))]
        public void A04_UseDiscounts(Dictionary<string, int> addItems, string discount, string expected)
        {
            foreach (var item in addItems)
            {
                _cart.addItem(item.Key, item.Value);
            }
            _cart.applyDiscount(discount);
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
            | Iceberg    | 2.17 £á     | 1           |
            |---------------------------------------|
            | Promotion:                            |
            |---------------------------------------|
            | Total products: 1                     |
            | Total price: 2.17 £á                   |
            -----------------------------------------")
                    .SetArgDisplayNames("add 1 Iceberg");

                yield return new TestCaseData(
                    new Dictionary<string, int>
                    {
                        { "Iceberg", 2 },
                        { "Tomato", 1 }
                    }, @"
            -----------------------------------------
            | Product    | Price      | Quantity    |
            | ---------- | ---------- | ----------- |
            | Iceberg    | 4.34 £á     | 2           |
            | Tomato     | 0.73 £á     | 1           |
            |---------------------------------------|
            | Promotion:                            |
            |---------------------------------------|
            | Total products: 3                     |
            | Total price: 5.07 £á                   |
            -----------------------------------------")
                    .SetArgDisplayNames("add 2 Iceberg, 1 Tomato");
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
            | Chicken    | 1.83 £á     | 1           |
            |---------------------------------------|
            | Promotion:                            |
            |---------------------------------------|
            | Total products: 1                     |
            | Total price: 1.83 £á                   |
            -----------------------------------------")
                    .SetArgDisplayNames("add 1 Chicken, 1 Bread and delete 1 Bread");

                yield return new TestCaseData(
                    new Dictionary<string, int>
                    {
                        { "Chicken", 1 },
                        { "Bread", 2 }
                    },
                    new Dictionary<string, int>
                    {
                        { "Bread", 1 }
                    }, @"
            -----------------------------------------
            | Product    | Price      | Quantity    |
            | ---------- | ---------- | ----------- |
            | Chicken    | 1.83 £á     | 1           |
            | Bread      | 0.88 £á     | 1           |
            |---------------------------------------|
            | Promotion:                            |
            |---------------------------------------|
            | Total products: 2                     |
            | Total price: 2.71 £á                   |
            -----------------------------------------")
                    .SetArgDisplayNames("add 1 Chicken, 2 Bread and delete 1 Bread");
            }
        }

        private static IEnumerable UseDiscountsTestCases
        {
            get
            {
                yield return new TestCaseData(
                    new Dictionary<string, int>
                    {
                        { "Iceberg", 3 },
                        { "Tomato", 1 },
                        { "Chicken", 1 },
                        { "Bread", 2 },
                        { "Corn", 1 },
                    },
                    "PROMO_5", @"
            -----------------------------------------
            | Product    | Price      | Quantity    |
            | ---------- | ---------- | ----------- |
            | Iceberg    | 6.51 £á     | 3           |
            | Tomato     | 0.73 £á     | 1           |
            | Chicken    | 1.83 £á     | 1           |
            | Bread      | 1.76 £á     | 2           |
            | Corn       | 1.50 £á     | 1           |
            |---------------------------------------|
            | Promotion: 5% off with code PROMO_5   |
            |---------------------------------------|
            | Total products: 8                     |
            | Total price: 11.71 £á                  |
            -----------------------------------------")
                    .SetArgDisplayNames("use discount PROMO_5");

                yield return new TestCaseData(
                    new Dictionary<string, int>
                    {
                        { "Chicken", 3 }
                    },
                    "PROMO_10", @"
            -----------------------------------------
            | Product    | Price      | Quantity    |
            | ---------- | ---------- | ----------- |
            | Chicken    | 5.49 £á     | 3           |
            |---------------------------------------|
            | Promotion: 10% off with code PROMO_10 |
            |---------------------------------------|
            | Total products: 3                     |
            | Total price: 4.94 £á                   |
            -----------------------------------------")
                    .SetArgDisplayNames("use discount PROMO_10");
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