using Microsoft.EntityFrameworkCore;
using NetCoreBank3172_0.Models.Entities;
using NetCoreBank3172_0.Models.SeedHandling;

namespace NetCoreBank3172_0.Models.ContextClasses
{
    public class MyContext : DbContext
    {

        public MyContext(DbContextOptions<MyContext> opt):base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            UserCardHandling.SeedUserCard(modelBuilder);
        }

        public DbSet<UserCardInfo> CardInfoes { get; set; }
    }
}
