﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PetHotel.Infrastructure;


namespace DAL
{
    public class ViewModelContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ViewModelContext() : base("name=PetContext")
        {
        }

      
        public DbSet<PetHotel.Infrastructure.PriceLists> PriceList { get; set; }
        public DbSet<PetHotel.Models.Customer> Customers { get; set; }
        public DbSet<PetHotel.Models.Invoice> Invoices { get; set; }
        public DbSet<PetHotel.Models.OrderItem> OrderItems { get; set; }

        public System.Data.Entity.DbSet<PetHotel.Models.Price> Prices { get; set; }
    
    }
}
