using Microsoft.EntityFrameworkCore;
using THUCTAP.Models;

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
                .HasForeignKey(m => m.parentid)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasData(
                new User { id = 1, username = "admin", usercode = "NV001", password = "123", email = "admin@test.com", department = "Ban Giám Đốc" },
                new User { id = 2, username = "bacsi01", usercode = "BS001", password = "123", email = "bs@test.com", department = "Khoa Nội" }
            );

            modelBuilder.Entity<Group>().HasData(
                new Group { id = 1, name = "Quản trị hệ thống", code = "ADMIN", description = "Full quyền" },
                new Group { id = 2, name = "Bác sĩ", code = "DOCTOR", description = "Quyền khám chữa bệnh" }
            );

            modelBuilder.Entity<AppAction>().HasData(
                new AppAction { id = 1, menuid = 2, label = "Danh sách ", code = "USER_VIEW_LIST", endpoint = "/api/users", method = "GET" },
                new AppAction { id = 2, menuid = 2, label = "Chi tiết ", code = "USER_VIEW_DETAIL", endpoint = "/api/users/{id}", method = "GET" },
                new AppAction { id = 3, menuid = 2, label = "Thêm mới ", code = "USER_ADD", endpoint = "/api/users", method = "POST" },
                new AppAction { id = 4, menuid = 2, label = "Cập nhật ", code = "USER_EDIT", endpoint = "/api/users/{id}", method = "PUT" },
                new AppAction { id = 5, menuid = 2, label = "Xóa ", code = "USER_DEL", endpoint = "/api/users/{id}", method = "DELETE" }
            );

            modelBuilder.Entity<Menu>().HasData(
                new Menu { id = 1, label = "Hệ thống", to = "/system", icon = "settings", parentid = null },
                new Menu { id = 2, label = "Quản lý Người dùng", to = "/system/users", icon = "users", parentid = 1 }
            );

            modelBuilder.Entity<FormField>().HasData(
                new FormField { id = 1, entityname = "User", field = "username", label = "Tên đăng nhập", type = "text", colspan = 6, sortorder = 1, isdetail = false },
                new FormField { id = 2, entityname = "User", field = "department", label = "Phòng ban", type = "select", colspan = 6, sortorder = 2, isdetail = false }
            );

            modelBuilder.Entity<User>()
                .HasMany(u => u.groups)
                .WithMany(g => g.users)
                .UsingEntity(j => j
                    .ToTable("User_Groups")
                    .HasData(
                        new { usersid = 1, groupsid = 1 },
                        new { usersid = 2, groupsid = 2 }
                    )
                );

            modelBuilder.Entity<Group>()
                .HasMany(g => g.menus)
                .WithMany(m => m.groups)
                .UsingEntity(j => j
                    .ToTable("Group_Menus")
                    .HasData(
                        new { groupsid = 1, menusid = 1 },
                        new { groupsid = 1, menusid = 2 }
                    )
                );

            modelBuilder.Entity<Group>()
                 .HasMany(g => g.actions)
                 .WithMany(a => a.groups)
                 .UsingEntity(j => j
                     .ToTable("Group_Actions")
                     .HasData(
                         new { groupsid = 1, actionsid = 1 },
                         new { groupsid = 1, actionsid = 2 },
                         new { groupsid = 1, actionsid = 3 },
                         new { groupsid = 1, actionsid = 4 },
                         new { groupsid = 1, actionsid = 5 }
                     )
                 );
        }
    }
}