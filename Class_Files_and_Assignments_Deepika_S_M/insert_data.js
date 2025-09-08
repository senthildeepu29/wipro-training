use onlineRetail;

const productResult = db.products.insertOne({
  name: "Wireless Mouse",
  category: "Electronics",
  price: 25.99,
  stock: 120,
  attributes: { brand: "Logitech", color: "Black", connectivity: "Wireless" },
  created_at: new Date()
});
const productId = productResult.insertedId;

const userResult = db.users.insertOne({
  username: "john_doe",
  email: "john@example.com",
  password_hash: "s0m3H4shV4lu3",
  created_at: new Date()
});
const userId = userResult.insertedId;

db.orders.insertOne({
  user_id: userId,
  order_date: new Date(),
  items: [
    {
      product_id: productId,
      name: "Wireless Mouse",
      quantity: 2,
      price: 25.99
    }
  ],
  total_cost: 51.98,
  status: "Shipped"
});
