using Microsoft.EntityFrameworkCore;
using SmsSender.DAL.Configurations;
using SmsSender.DAL.Entities;

namespace SmsSender.DAL.Core
{
    public class AppDbContext : DbContext
    {
        public DbSet<Invitation> Invitations { get; set; }

        public AppDbContext() : base() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InvitationConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=InvitationDB;Trusted_Connection=True;");
            }
        }
    }
}
