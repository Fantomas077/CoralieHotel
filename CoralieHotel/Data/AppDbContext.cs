using CoralieHotel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoralieHotel.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>  // Assurez-vous que les types génériques sont corrects
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Categorie> Categories { get; set; }

        
    }
}
