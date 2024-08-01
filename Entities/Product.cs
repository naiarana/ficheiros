

namespace Ficheiros.Entities
{
    internal class Product

    {
    
        public string ProductName { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public Product(string productName, double price, int quantity)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }

        public double Total() 
        {
            return Price * Quantity;
        }
    }
}
