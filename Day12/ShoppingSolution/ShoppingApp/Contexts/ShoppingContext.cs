using Microsoft.EntityFrameworkCore;
using ShoppingApp.Models;

namespace ShoppingApp.Contexts
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItems> CartItems { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        //public DbSet<Wishlist> Whishlists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API


            modelBuilder.Entity<Cart>(cart =>
            {
                cart.HasKey(ck => ck.cartNumber);
            });
            modelBuilder.Entity<CartItems>(ci =>
            {
                ci.HasKey(cik => new { cik.CartNumber, cik.Product_Id });
            });
            modelBuilder.Entity<CartItems>()
                .HasOne<Product>(ci => ci.Product)
                .WithMany(p => p.CartItems);



            modelBuilder.Entity<Order>(order =>
            {
                order.HasKey(ck => ck.OrderID);
            });

            modelBuilder.Entity<OrderDetails>(od =>
            {
                od.HasKey(odk => new { odk.OrderID, odk.Product_Id });
            });

            modelBuilder.Entity<OrderDetails>()
                .HasOne<Product>(od => od.Product)
                .WithMany(p => p.OrderDetails);
        }
    }
}

