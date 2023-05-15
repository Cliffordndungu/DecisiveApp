using DecisiveApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Numerics;

namespace DecisiveApp.Data
{
    public class AppDBContext : DbContext

    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Downloads> Downloads{get; set;}
        public DbSet<Reports> Reports { get; set; }
        public DbSet<Service> Services{ get; set; }
      
    }
}


