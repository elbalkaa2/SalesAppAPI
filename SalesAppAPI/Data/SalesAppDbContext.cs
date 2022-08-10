using Microsoft.EntityFrameworkCore;
using SalesAppAPI.Models;

namespace SalesAppAPI.Data
{
    public class SalesAppDbContext : DbContext
    {
        public SalesAppDbContext(DbContextOptions<SalesAppDbContext>options):base(options)
        {
        }

        public DbSet<User> Users { get; set; }   
        



    }



}
