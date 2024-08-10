# ShoppingCart_Kata
### About this kata
- [codurance](https://www.codurance.com/katas/shopping-cart-kata)

### Test case
#### EmptyCart
```
printShoppingCart
-----------------------------------------
| Product    | Price      | Quantity    |
| ---------- | ---------- | ----------- |
|---------------------------------------|
| Promotion:                            |
|---------------------------------------|
| Total products: 0                     |
| Total price: 0.00 €                   |
-----------------------------------------
```
#### AddItemToCart
```
addItem("Iceberg", 1)

printShoppingCart
-----------------------------------------
| Product    | Price      | Quantity    |
| ---------- | ---------- | ----------- |
| Iceberg    | 1.79 €     | 1           |
|---------------------------------------|
| Promotion:                            |
|---------------------------------------|
| Total products: 1                     |
| Total price: 1.79 €                   |
-----------------------------------------
==========================================

addItem("Iceberg", 2)
addItem("Tomato", 1)

printShoppingCart
-----------------------------------------
| Product    | Price      | Quantity    |
| ---------- | ---------- | ----------- |
| Iceberg    | 3.58 €     | 2           |
| Tomato     | 0.60 €     | 1           |
|---------------------------------------|
| Promotion:                            |
|---------------------------------------|
| Total products: 3                     |
| Total price: 4.18 €                   |
-----------------------------------------
```

#### DeleteItemToCart
```
addItem("Chicken", 1)
addItem("Bread", 1)
deleteItem("Bread", 1)

printShoppingCart
-----------------------------------------
| Product    | Price      | Quantity    |
| ---------- | ---------- | ----------- |
| Chicken    | 1.83 €    | 1            |
|---------------------------------------|
| Promotion:                            |
|---------------------------------------|
| Total products: 1                     |
| Total price: 1.83 €                   |
-----------------------------------------
==========================================

addItem("Chicken", 1)
addItem("Bread", 2)
deleteItem("Bread", 1)

printShoppingCart
-----------------------------------------
| Product    | Price      | Quantity    |
| ---------- | ---------- | ----------- |
| Chicken    | 1.83 €    | 1            |
| Bread      | 0.88 €    | 1            |
|---------------------------------------|
| Promotion:                            |
|---------------------------------------|
| Total products: 2                     |
| Total price: 2.71 €                   |
-----------------------------------------
```

#### UseDiscounts
```
addItem("Iceberg", 3)
addItem("Tomato", 1)
addItem("Chicken", 1)
addItem("Bread", 2)
addItem("Corn", 1)
applyDiscount("PROMO_5")

printShoppingCart
-----------------------------------------
| Product    | Price      | Quantity    |
| ---------- | ---------- | ----------- |
| Iceberg    | 6.51 €     | 3           |
| Tomato     | 0.73 €     | 1           |
| Chicken    | 1.83 €     | 1           |
| Bread      | 1.76 €     | 2           |
| Corn       | 1.50 €     | 1           |
|---------------------------------------|
| Promotion: 5% off with code PROMO_5   |
|---------------------------------------|
| Total products: 8                     |
| Total price: 11.71 €                  |
-----------------------------------------
==========================================

addItem("Chicken", 3)
applyDiscount("PROMO_10")

printShoppingCart
-----------------------------------------
| Product    | Price      | Quantity    |
| ---------- | ---------- | ----------- |
| Chicken    | 5.49 €     | 3           |
|---------------------------------------|
| Promotion: 10% off with code PROMO_10 |
|---------------------------------------|
| Total products: 3                     |
| Total price: 4.94 €                   |
-----------------------------------------
```