using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using API_PRO.Data.Models;
using API_PRO.Data;
using System.Collections.Generic;

namespace API_PRO.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ApiItem> ApiItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

    }
}
