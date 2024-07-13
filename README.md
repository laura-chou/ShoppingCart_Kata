# ShoppingCart_Kata
### About this kata
- [codurance](https =//www.codurance.com/katas/shopping-cart-kata)

### Test case
#### AddItemToCart
```
product
  addItem("Iceberg", 1)
cart
  new ShoppingCart {
    products = {
      new Product {
        name = "Iceberg",
        quantity = 1,
        price = 2.17
      }
    }
  }
--------------------------------
product
  addItem("Iceberg", 2)
  addItem("Tomato", 1)
cart
  new ShoppingCart {
    products = {
      new Product {
        name = "Iceberg",
        quantity = 2,
        price = 4.34
      },
      new Product {
        name = "Tomato",
        quantity = 1,
        price = 0.73
      }
    }
  }
--------------------------------
product
  addItem("Corn", 0)
cart
  new ShoppingCart {
    products = {}
  }
```

#### DeleteItemToCart
```
product
  addItem("Chicken", 1)
  addItem("Bread", 1)
  deleteItem("Bread", 1)
cart
  new ShoppingCart {
    products = {
      new Product {
        name = "Chicken",
        quantity = 1,
        price = 1.83
      }  
    }
  }
--------------------------------
product
  addItem("Chicken", 1)
  addItem("Bread", 2)
  deleteItem("Bread", 1)
cart
  new ShoppingCart {
    products = {
      new Product {
        name = "Chicken",
        quantity = 1,
        price = 1.83
      },
      new Product {
        name = "Bread",
        quantity = 1,
        price = 0.88
      }
    }
  }
```

#### CalculateTotalProducts
```
product
  addItem("Chicken", 1)
  addItem("Bread", 2)
  addItem("Corn", 2)
cart
  new ShoppingCart {
    products = {
      new Product {
        name = "Chicken",
        quantity = 1,
        price = 1.83
      },
      new Product {
        name = "Bread",
        quantity = 2,
        price = 1.76
      },
      new Product {
        name = "Corn",
        quantity = 2,
        price = 3
      }
    },
    totalProducts = 5
  }
```

#### CalculateTotalPrice
```
product
  addItem("Chicken", 1)
  addItem("Bread", 2)
  addItem("Corn", 2)
cart
  new ShoppingCart {
    products = {
      new Product {
        name = "Chicken",
        quantity = 1,
        price = 1.83
      },
      new Product {
        name = "Bread",
        quantity = 2,
        price = 1.76
      },
      new Product {
        name = "Corn",
        quantity = 2,
        price = 3
      }
    },
    totalProducts = 5,
    totalPrice = 6.59
  }
--------------------------------
product
  addItem("Iceberg", 1)
  addItem("Tomato", 1)
  applyDiscount("PROMO_5")
cart
  new ShoppingCart {
    products = {
      new Product {
        name = "Iceberg",
        quantity = 1,
        price = 2.17
      },
      new Product {
        name = "Tomato",
        quantity = 1,
        price = 0.73
      }
    },
    promotion = new Discount
    {
      code = "PROMO_5",
      amount = 0.05
    },
    totalProducts = 2,
    totalPrice = 2.75
  }
--------------------------------
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