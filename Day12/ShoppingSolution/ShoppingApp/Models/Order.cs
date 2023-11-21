using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingApp.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Username { get; set; }
        public DateTime OrderDate { get; set; }
        public double ToatalAmount { get; set; }

        [ForeignKey("Username")]
        public User User { get; set; }
    }

}
