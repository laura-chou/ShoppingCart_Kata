# ShoppingCart_Kata
### About this kata
- [codurance](https://www.codurance.com/katas/shopping-cart-kata)

### Test case
#### AddItemToCart
```
添加一個商品到空的購物車
addItem("Iceberg", 1)

expected
new Cart {
  Products = new List<Product> 
    {
      new Product { 
        Name = "Iceberg",
        Quantity = 1,
        Price = 2.17
      }
    }
}
==========================================
添加多個相同的商品到購物車
addItem("Iceberg", 2)

expected
new Cart {
  Products = new List<Product> 
    {
      new Product { 
        Name = "Iceberg",
        Quantity = 2,
        Price = 4.34
      }
    }
}
==========================================
添加不同的商品到購物車
addItem("Iceberg", 2)
addItem("Tomato", 1)
addItem("Chicken", 1)
addItem("Bread", 1)
addItem("Corn", 1)

expected
new Cart {
  Products = new List<Product> 
    {
      new Product { 
        Name = "Iceberg",
        Quantity = 2,
        Price = 4.34
      },
      new Product { 
        Name = "Tomato",
        Quantity = 1,
        Price = 0.73
      },
      new Product { 
        Name = "Chicken",
        Quantity = 1,
        Price = 1.83
      },
      new Product { 
        Name = "Bread",
        Quantity = 1,
        Price = 0.88
      },
      new Product { 
        Name = "Corn",
        Quantity = 1,
        Price = 0.50
      }
    }
}
```
#### DeleteItemToCart
```
從購物車中刪除一個商品
addItem("Bread", 2)
deleteItem("Bread", 1)

expected
new Cart {
  Products = new List<Product> 
    {
      new Product { 
        Name = "Bread",
        Quantity = 1,
        Price = 0.88
      }
    }
}
==========================================
從購物車中刪除一個不存在的商品
addItem("Chicken", 1)
deleteItem("Apple", 1)

expected
new Cart {
  Products = new List<Product> 
    {
      new Product { 
        Name = "Chicken",
        Quantity = 1,
        Price = 1.83
      }
    }
}
```
#### CaculateTotalPrice
```
計算空購物車的總價格
expected
new Cart {
  Products = new List<Product>(),
  TotalPrice = 0.00
}
==========================================
計算購物車包含單個商品的總價格
addItem("Corn", 1)

expected
new Cart {
  Products = new List<Product> 
  {
    new Product { 
      Name = "Corn",
      Quantity = 1,
      Price = 1.50
    }
  },
  TotalPrice = 1.50
}
==========================================
計算購物車中相同商品的總價格
addItem("Corn", 2)

expected
new Cart {
  Products = new List<Product> 
  {
    new Product { 
      Name = "Corn",
      Quantity = 2,
      Price = 3.00
    }
  },
  TotalPrice = 3.00
}
==========================================
計算購物車包含多個不同商品的總價格
addItem("Iceberg", 3)
addItem("Bread", 2)
addItem("Tomato", 1)

expected
new Cart {
  Products = new List<Product> 
  {
    new Product { 
      Name = "Iceberg",
      Quantity = 3,
      Price = 6.51
    },
    new Product { 
      Name = "Bread",
      Quantity = 2,
      Price = 1.76
    },
    new Product { 
      Name = "Tomato",
      Quantity = 1,
      Price = 0.73
    }
  },
  TotalPrice = 9.00
}
```
#### UseDiscounts
```
對購物車應用 PROMO_5 折扣碼
addItem("Tomato", 5)
addItem("Corn", 10)
applyDiscount("PROMO_5")

printShoppingCart
-----------------------------------------
| Product    | Price      | Quantity    |
| ---------- | ---------- | ----------- |
| Tomato     | 3.65 €     | 5           |
| Corn       | 15.00 €    | 10          |
|---------------------------------------|
| Promotion: 5% off with code PROMO_5   |
|---------------------------------------|
| Total products: 15                    |
| Total price: 17.72 €                  |
-----------------------------------------
==========================================
對購物車應用 PROMO_10 折扣碼
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
==========================================
應用無效的折扣碼
addItem("Bread ", 2)
applyDiscount("PROMO_100")

printShoppingCart
-----------------------------------------
| Product    | Price      | Quantity    |
| ---------- | ---------- | ----------- |
| Bread      | 1.76 €     | 2           |
|---------------------------------------|
| Promotion:                            |
|---------------------------------------|
| Total products: 2                     |
| Total price: 1.76 €                   |
-----------------------------------------
```