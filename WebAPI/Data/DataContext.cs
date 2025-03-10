using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){}
        
        public DbSet<User> Users { get; set; }

        public DbSet<Plastic> Plastic {get; set;}

        public DbSet<PlasticType> PropertyTypes {get; set;}
     
    }
}