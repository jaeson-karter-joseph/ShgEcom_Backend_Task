using ErrorOr;

namespace ShgEcom.Domain.Errors
{
    public static partial class Errors
    {
        public static class Product
        {
            public static Error NoProductsFound => Error.NotFound(
                code: "Product.NoProductsFound",
                description: "No products found in the inventory.");
            public static Error ProductNotFound => Error.NotFound(
                code: "Product.NotFound",
                description: "The requested product does not exist.");

            public static Error InvalidName => Error.Validation(
                code: "Product.InvalidName",
                description: "Product name must be between 1 and 100 characters.");

            public static Error NegativePrice => Error.Validation(
                code: "Product.NegativePrice",
                description: "Product price cannot be negative.");

            public static Error InvalidStockQuantity => Error.Validation(
                code: "Product.InvalidStockQuantity",
                description: "Stock quantity cannot be negative.");

            public static Error OutOfStock => Error.Conflict(
                code: "Product.OutOfStock",
                description: "Product is currently out of stock.");
        }

        public static class Order
        {
            public static Error InvalidOrderQuantity => Error.Validation(
                code: "Order.InvalidQuantity",
                description: "Order quantity must be greater than zero.");

            public static Error InsufficientStock => Error.Conflict(
                code: "Order.InsufficientStock",
                description: "Insufficient product stock for the order.");
        }
    }
}
