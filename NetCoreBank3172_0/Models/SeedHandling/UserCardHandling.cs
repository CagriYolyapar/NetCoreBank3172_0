using Microsoft.EntityFrameworkCore;
using NetCoreBank3172_0.Models.Entities;

namespace NetCoreBank3172_0.Models.SeedHandling
{
    public static class UserCardHandling
    {
        public static void SeedUserCard(ModelBuilder modelBuilder)
        {
            UserCardInfo uInfo = new()
            {
                ID = 1,
                Balance = 10000,
                CardLimit = 10000,
                CardNumber = "1111 1111 1111 1111",
                CardUserName ="Test verisidir",
                CVC="222",
                ExpiryMonth = 12,
                ExpiryYear = 2024
            };

            modelBuilder.Entity<UserCardInfo>().HasData(uInfo);
        }
    }
}
