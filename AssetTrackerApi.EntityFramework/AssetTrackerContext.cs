using AssetTrackerApi.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackerApi.EntityFramework;

public class AssetTrackerContext: DbContext
{
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<UserResource> UserResources { get; set; }
    public DbSet<UserOrganization> UserOrganizations { get; set; }


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

        modelBuilder.Entity<UserOrganization>()
            .HasKey(uo => new { uo.UserId, uo.OrganizationId });

        modelBuilder.Entity<UserOrganization>()
            .HasOne(uo => uo.User)
            .WithMany(u => u.UserOrganizations)
            .HasForeignKey(uo => uo.UserId);

        modelBuilder.Entity<UserOrganization>()
            .HasOne(uo => uo.Organization)
            .WithMany(o => o.UserOrganizations)
            .HasForeignKey(uo => uo.OrganizationId);
    }
}