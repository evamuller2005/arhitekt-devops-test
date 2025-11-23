using Arhitekt.Models;
using Microsoft.EntityFrameworkCore;

namespace Arhitekt.Data;

public class ArhitektContext : DbContext
{
    public ArhitektContext(DbContextOptions<ArhitektContext> options) 
        : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Project>().ToTable("Project");
    }
}
