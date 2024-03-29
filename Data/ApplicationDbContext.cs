using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportUniTrack.Models;
using System.Collections;

namespace SportUniTrack.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SportUniTrack.Models.ApplicationUser> ApplicationUser { get; set; } = default!;
        public DbSet<SportUniTrack.Models.Equipment> Equipment { get; set; } = default!;
        public DbSet<SportUniTrack.Models.Borrowing> Borrowing { get; set; } = default!;
        public IEnumerable Equipments { get; internal set; }
    }
}
