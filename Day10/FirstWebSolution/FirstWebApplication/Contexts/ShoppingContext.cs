﻿using FirstWebApplication.Controllers;
using FirstWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApplication.Contexts
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
