using costs_api.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace costs_api.Database.Context
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> opt) : base(opt)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
