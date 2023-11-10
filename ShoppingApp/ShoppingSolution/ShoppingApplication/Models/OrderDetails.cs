using ShoppingApplication.Models;

namespace ShoppingApplication.Models
{
    public class OrderDetails
    {
        public int OrderID { get; set; }
        public int Product_Id { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
