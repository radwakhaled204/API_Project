using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.SqlServer;
using API_PRO.Data.Models;
using API_PRO.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace API_PRO.Data
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }//12
        public DbSet<Exam> Exam { get; set; }
        public DbSet<ApiItem> ApiItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

    }
}
