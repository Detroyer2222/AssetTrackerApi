using AssetTrackerApi.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackerApi.EntityFramework;

public class AssetTrackerContext: DbContext
{
    public DbSet<Organisation> Organisations { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<UserResource> UserResources { get; set; }
    public DbSet<UserOrganisation> UserOrganisations { get; set; }

        
    public AssetTrackerContext(DbContextOptions<AssetTrackerContext> options)
        :base(options)
    {
            
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserResource>()
            .HasKey(ur => new { ur.UserId, ur.ResourceId });

        modelBuilder.Entity<UserResource>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserResources)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserResource>()
            .HasOne(ur => ur.Resource)
            .WithMany(r => r.UserResources)
            .HasForeignKey(ur => ur.ResourceId);

        modelBuilder.Entity<UserOrganisation>()
            .HasKey(uo => new { uo.UserId, uo.OrganisationId });

        modelBuilder.Entity<UserOrganisation>()
            .HasOne(uo => uo.User)
            .WithMany(u => u.UserOrganisations)
            .HasForeignKey(uo => uo.UserId);

        modelBuilder.Entity<UserOrganisation>()
            .HasOne(uo => uo.Organisation)
            .WithMany(o => o.UserOrganisations)
            .HasForeignKey(uo => uo.OrganisationId);
    }
}