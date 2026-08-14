using Microsoft.EntityFrameworkCore;
using THUCTAP.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace THUCTAP.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<AppAction> Actions { get; set; }
        public DbSet<FormField> FormFields { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<CustomerCategory> CustomerCategories { get; set; }
        public DbSet<CustomerMaster> CustomerMasters { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var currentUser = _httpContextAccessor.HttpContext?.User?.FindFirst("userId")?.Value
                              ?? _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                              ?? "System";
            var entries = ChangeTracker.Entries<BaseModel>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.createdAt = DateTime.Now;
                    entry.Entity.createdBy = currentUser; 
                    entry.Entity.updatedAt = DateTime.Now;
                    entry.Entity.updatedBy = currentUser; 
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.updatedAt = DateTime.Now;
                    entry.Entity.updatedBy = currentUser; 
                    entry.Property(x => x.createdAt).IsModified = false;
                    entry.Property(x => x.createdBy).IsModified = false;
                }
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.isActive = false;
                    entry.Entity.updatedAt = DateTime.Now;
                    entry.Entity.updatedBy = currentUser;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Menu>()
                .HasOne(m => m.parent)
                .WithMany(m => m.children)
                .HasForeignKey(m => m.parentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
                .HasMany(u => u.group)
                .WithMany(g => g.user)
                .UsingEntity(j => j.ToTable("User_Group")
                );
            modelBuilder.Entity<Group>()
                .HasMany(g => g.menu)
                .WithMany(m => m.group)
                .UsingEntity(j => j.ToTable("Group_Menu")
                );
            modelBuilder.Entity<Group>()
                 .HasMany(g => g.action)
                 .WithMany(a => a.group)
                 .UsingEntity(j => j.ToTable("Group_Action")
                 );
            modelBuilder.Entity<FormField>()
                .HasOne(f => f.menu)
                .WithMany(m => m.formFields)
                .HasForeignKey(f => f.menuId)
                .OnDelete(DeleteBehavior.SetNull
            );
            modelBuilder.Entity<CustomerMaster>()
                .HasOne(c => c.Category)
                .WithMany()
                .HasForeignKey(c => c.categoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Seed();
        }
    }
}