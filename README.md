# ShoppingCart_Kata
### About this kata
- [codurance](https =//www.codurance.com/katas/shopping-cart-kata)

### Test case
#### AddItemToCart
```
product
  addItem("Iceberg", 1)
print
---------------------------------------
| Product    | Price     | Quantity   |
| ---------- | --------- | ---------- |
| Iceberg    | 2.17 €    | 1          |
|-------------------------------------|
| Promotion:                          |
|-------------------------------------|
| Total products: 1                   |
| Total price: 2.17 €                 |
---------------------------------------
========================================
product
  addItem("Iceberg", 2)
  addItem("Tomato", 1)
print
---------------------------------------
| Product    | Price     | Quantity   |
| ---------- | --------- | ---------- |
| Iceberg    | 4.34 €    | 2          |
| Tomato     | 0.73 €    | 1          |
|-------------------------------------|
| Promotion:                          |
|-------------------------------------|
| Total products: 3                   |
| Total price: 5.07 €                 |
---------------------------------------
========================================
product
  addItem("Corn", 0)
print
---------------------------------------
| Product    | Price     | Quantity   |
| ---------- | --------- | ---------- |
|-------------------------------------|
| Promotion:                          |
|-------------------------------------|
| Total products: 0                   |
| Total price: 0.00 €                 |
---------------------------------------
```

#### DeleteItemToCart
```
product
  addItem("Chicken", 1)
  addItem("Bread", 1)
  deleteItem("Bread", 1)
print
---------------------------------------
| Product    | Price     | Quantity   |
| ---------- | --------- | ---------- |
| Chicken    | 1.83 €    | 1          |
|-------------------------------------|
| Promotion:                          |
|-------------------------------------|
| Total products: 1                   |
| Total price: 1.83 €                 |
---------------------------------------
========================================
product
  addItem("Chicken", 1)
  addItem("Bread", 2)
  deleteItem("Bread", 1)
print
---------------------------------------
| Product    | Price     | Quantity   |
| ---------- | --------- | ---------- |
| Chicken    | 1.83 €    | 1          |
| Bread      | 0.88 €    | 1          |
|-------------------------------------|
| Promotion:                          |
|-------------------------------------|
| Total products: 2                   |
| Total price: 2.71 €                 |
---------------------------------------
```

#### UseDiscounts
```
product
  addItem("Iceberg", 1)
  addItem("Tomato", 1)
  applyDiscount("PROMO_5")
print
---------------------------------------
| Product    | Price     | Quantity   |
| ---------- | --------- | ---------- |
| Iceberg    | 6.51 €    | 3          |
| Tomato     | 0.73 €    | 1          |
| Chicken    | 1.83 €    | 1          |
| Bread      | 1.76 €    | 2          |
| Corn       | 1.50 €    | 1          |
|-------------------------------------|
| Promotion: 5% off with code PROMO_5 |
|-------------------------------------|
| Total products: 2                   |
| Total price: 2.71 €                 |
---------------------------------------
========================================
product
  addItem("Chicken", 3)
  applyDiscount("PROMO_10")
cart
  new ShoppingCart {
    products = {
      new Product {
        name = "Chicken",
        quantity = 3,
        price = 5.49
      }
    },
    promotion = new Discount
    {
      code = "PROMO_10",
      amount = 0.1
    },
    totalProducts = 3,
    totalPrice = 4.94
  }
```