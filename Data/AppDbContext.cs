/*Desenvolvido por:
  
  Pedro Xavier Oliveira CB3027376
  Leandro Felix Nunes CB3026159

 */

using BLContainerManager.Models; 
using Microsoft.EntityFrameworkCore;

namespace BLContainerManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<BL> BLs { get; set; }
        public DbSet<Container> Containers { get; set; }
    }
}
