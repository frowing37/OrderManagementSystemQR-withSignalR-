﻿using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SignalR_Entities.Concrete;

namespace SignalR_DataAccess.Concrete
{
	public class SignalRContext : IdentityDbContext<AppUser,AppRole,int>
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=SignalR;User Id=SA;Password=reallyStrongPwd123;TrustServerCertificate=True;Encrypt=false;");
        }

        public DbSet<About> Abouts { get; set; }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        public DbSet<Feature> Features { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<SocialMedia> SocialMedias { get; set; }

        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<MoneyCase> MoneyCases { get; set; }
        public DbSet<MenuTable> MenuTables { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        
        public DbSet<Message> Messages { get; set; }
     }
}

