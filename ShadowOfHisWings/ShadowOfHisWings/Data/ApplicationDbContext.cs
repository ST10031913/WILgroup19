using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShadowOfHisWings.Models;

namespace ShadowOfHisWings.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Donation> Donations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
