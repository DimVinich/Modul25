﻿using Microsoft.EntityFrameworkCore;
using Modul25.Configuration;
using Modul25.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modul25
{
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }

        //  Объекты таблицы Books
        public DbSet<Book> Books { get; set; }

        public AppContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=EF;Trusted_Connection=True;TrustServerCertificate=Yes;");
            optionsBuilder.UseSqlServer(ConnectionString.MsSqlConnection);
        }
    }
}
