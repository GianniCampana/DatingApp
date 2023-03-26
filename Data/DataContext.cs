using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        { 
        }

        // iDbSet rappresentano le tabelle che avrò nel db e le prop di AppUser in questo caso i campi delle tabelle
        public DbSet<AppUser> Users { get; set; }
    }

    
}