using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }


        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasOne(e => e.Employee)
                .WithMany(t => t.Tasks)
                .HasForeignKey(e => e.EmployeeId);

            /*    modelBuilder.Entity<ProjectEmployee>()
                    .HasKey(pe => new {pe.EmployeeId, pe.ProjectId});
    
                modelBuilder.Entity<ProjectEmployee>()
                    .HasOne(pe => pe.Employee)
                    .WithMany(e => e.ProjectEmployees)
                    .HasForeignKey(pe => pe.EmployeeId);
    
                modelBuilder.Entity<ProjectEmployee>()
                    .HasOne(pe => pe.Project)
                    .WithMany(p => p.ProjectEmployees)
                    .HasForeignKey(pe => pe.ProjectId);*/
        }
    }
}