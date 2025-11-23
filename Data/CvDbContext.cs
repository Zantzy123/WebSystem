using Longheng.Models;
using Microsoft.EntityFrameworkCore;

namespace Longheng.Data;

public class CvDbContext : DbContext
{
    public CvDbContext(DbContextOptions options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnPartialModelCreating(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private void OnPartialModelCreating(ModelBuilder builder)
    {
        builder.Entity<CvTemplate>().HasOne(e => e.Creator)
               .WithMany(e => e.OwnedTemplates).HasForeignKey(e => e.CreatorId);
        builder.Entity<UserTemplate>()
               .Property<int>("UserId")
               .IsRequired();
        builder.Entity<UserTemplate>()
               .Property<int>("TemplateId")
               .IsRequired();
        builder.Entity<User>()
               .HasMany(e => e.UsedTemplates)
               .WithMany(e => e.Users)
               .UsingEntity<UserTemplate>().HasKey(e=>e.Id);
    }

public DbSet<Longheng.Models.CvTemplate> CvTemplates { get; set; } = default!;

public DbSet<Longheng.Models.User> Users { get; set; } = default!;
}