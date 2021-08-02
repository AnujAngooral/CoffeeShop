using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    public class CoffeeDbContext:DbContext
    {
        public CoffeeDbContext(DbContextOptions<CoffeeDbContext> options)
              : base(options)
        {
        }

        public DbSet<Coffee> Coffee { get; set; }
    }
}
