using Microsoft.EntityFrameworkCore;
using THUCTAP.Models;
using Microsoft.AspNetCore.Http; 
using System.Security.Claims;

namespace THUCTAP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<AppAction> Actions { get; set; }
        public DbSet<FormField> FormFields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Menu>()
                .HasOne(m => m.parent)
                .WithMany(m => m.children)
                .HasForeignKey(m => m.parentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasData(
                new User { id = 1, userName = "admin", userCode = "NV001", password = "123", email = "admin@test.com", department = "Ban Giám Đốc" },
                new User { id = 2, userName = "bacsi01", userCode = "BS001", password = "123", email = "bs@test.com", department = "Khoa Nội" }
            );

            modelBuilder.Entity<Group>().HasData(
                new Group { id = 1, name = "Quản trị hệ thống", code = "ADMIN" },
                new Group { id = 2, name = "Bác sĩ", code = "DOCTOR" },
                new Group { id = 3, name = "Nhân viên", code = "Employee" }
            );

            modelBuilder.Entity<AppAction>().HasData(
                new AppAction { id = 1, menuId = 6, label = "View", code = "VIEW", endpoint = "/api/users", method = "GET" },
                new AppAction { id = 2, menuId = 6, label = "Detail", code = "DETAIL", endpoint = "/api/users/{id}", method = "GET" },
                new AppAction { id = 3, menuId = 6, label = "Create", code = "CREATE", endpoint = "/api/users", method = "POST" },
                new AppAction { id = 4, menuId = 6, label = "Update", code = "EDIT", endpoint = "/api/users/{id}", method = "PUT" },
                new AppAction { id = 5, menuId = 6, label = "Delete", code = "DELETE", endpoint = "/api/users/{id}", method = "DELETE" },
                new AppAction { id = 6, menuId = 7, label = "View", code = "VIEW", endpoint = "/api/groups", method = "GET" },
                new AppAction { id = 7, menuId = 7, label = "Create", code = "CREATE", endpoint = "/api/groups", method = "POST" },
                new AppAction { id = 8, menuId = 7, label = "Update", code = "EDIT", endpoint = "/api/groups/{id}", method = "PUT" },
                new AppAction { id = 9, menuId = 7, label = "Delete", code = "DELETE", endpoint = "/api/groups/{id}", method = "DELETE" },
                new AppAction { id = 10, menuId = 7, label = "Detail", code = "DETAIL", endpoint = "/api/groups/{id}", method = "GET" }
            );

            modelBuilder.Entity<Menu>().HasData(
                 new Menu { id = 1, label = "SECURITY & SYSTEM", to = "", icon = "shield", parentId = null },
                 new Menu { id = 2, label = "EMPLOYEE MANAGEMENT", to = "", icon = "users", parentId = null },
                 new Menu { id = 3, label = "ADMINISTRATION", to = "", icon = "settings", parentId = null },
                 new Menu { id = 4, label = "TRANSACTIONS", to = "", icon = "shopping-cart", parentId = null },
                 new Menu { id = 5, label = "MASTER DATA", to = "", icon = "database", parentId = null },
                 new Menu { id = 6, label = "User Accounts", to = "/system/users", icon = "user", parentId = 1 },
                 new Menu { id = 7, label = "User Groups", to = "/system/groups", icon = "users", parentId = 1 },
                 new Menu { id = 8, label = "Employee Management", to = "/employee/manage", icon = "user-check", parentId = 2 },
                 new Menu { id = 9, label = "Administration", to = "/admin/settings", icon = "sliders", parentId = 3 },
                 new Menu { id = 10, label = "Orders", to = "/transactions/orders", icon = "file-text", parentId = 4 },
                 new Menu { id = 11, label = "Invoice Management", to = "/transactions/invoices", icon = "file-invoice", parentId = 4 },
                 new Menu { id = 12, label = "Product Categories", to = "/master/product-categories", icon = "tag", parentId = 5 },
                 new Menu { id = 13, label = "Customer Categories", to = "/master/customer-categories", icon = "users", parentId = 5 },
                 new Menu { id = 14, label = "Customer Master", to = "/master/customers", icon = "user", parentId = 5 }
             );

            modelBuilder.Entity<FormField>().HasData(
                new FormField { id = 1, entityName = "User", field = "username", label = "Tên đăng nhập", type = "text", colSpan = 6, sortOrder = 1, isDetail = false },
                new FormField { id = 2, entityName = "User", field = "department", label = "Phòng ban", type = "select", colSpan = 6, sortOrder = 2, isDetail = false }
            );

            modelBuilder.Entity<User>()
                .HasMany(u => u.group)
                .WithMany(g => g.user)
                .UsingEntity(j => j
                    .ToTable("User_Group")
                    .HasData(
                        new { userid = 1, groupid = 1 },
                        new { userid = 2, groupid = 2 }
                    )
                );

            modelBuilder.Entity<Group>()
                .HasMany(g => g.menu)
                .WithMany(m => m.group)
                .UsingEntity(j => j
                    .ToTable("Group_Menu")
                    .HasData(
                        new { groupid = 1, menuid = 1 },
                        new { groupid = 1, menuid = 2 },
                        new { groupid = 2, menuid = 2 },
                        new { groupid = 2, menuid = 8 },
                        new { groupid = 3, menuid = 2 },
                        new { groupid = 3, menuid = 8 }
                    )
                );

            modelBuilder.Entity<Group>()
                 .HasMany(g => g.action)
                 .WithMany(a => a.group)
                 .UsingEntity(j => j
                     .ToTable("Group_Action")
                     .HasData(
                         new { groupid = 1, actionid = 1 },
                         new { groupid = 1, actionid = 2 },
                         new { groupid = 1, actionid = 3 },
                         new { groupid = 1, actionid = 4 },
                         new { groupid = 1, actionid = 5 },

                         
                         new { groupid = 2, actionid = 1 }, 
                         new { groupid = 2, actionid = 2 }, 
                         new { groupid = 2, actionid = 4 }, 

                         
                         new { groupid = 3, actionid = 1 }
                     )
                 );
        }
    }
}