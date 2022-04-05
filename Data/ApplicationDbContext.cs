using aspcore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
// ReSharper disable UnusedMember.Global
#pragma warning disable 108,114

namespace aspcore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        
        public virtual DbSet<User> Users { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Issue> Issues { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}