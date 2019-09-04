using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UsersAccount.Models
{
    public partial class BooDevContext : DbContext
    {
        public BooDevContext()
        {
        }

        public BooDevContext(DbContextOptions<BooDevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuRights> MenuRights { get; set; }
        public virtual DbSet<MenuType> MenuType { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleMenuAccess> RoleMenuAccess { get; set; }
        public virtual DbSet<RoleMenuAuthorization> RoleMenuAuthorization { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<SystemConstant> SystemConstant { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserMenuAccess> UserMenuAccess { get; set; }
        public virtual DbSet<UserMenuAuthorization> UserMenuAuthorization { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //        optionsBuilder.UseSqlServer("Server=7LXSYW2\\SQLEXPRESS01;Database=BooDev;Integrated Security=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => new { e.City1, e.StateId, e.CountryId })
                    .HasName("UNK_City")
                    .IsUnique();

                entity.Property(e => e.CityId)
                    .HasColumnName("CityID")
                    .ValueGeneratedNever();

                entity.Property(e => e.City1)
                    .HasColumnName("City")
                    .HasMaxLength(50);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_City2");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_City1");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.Country1)
                    .HasName("UNK_Country")
                    .IsUnique();

                entity.Property(e => e.CountryId)
                    .HasColumnName("CountryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Country1)
                    .HasColumnName("Country")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.MenuId)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.MenuCode)
                    .HasName("UNK_Menu")
                    .IsUnique();

                entity.Property(e => e.MenuId)
                    .HasColumnName("MenuID")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Menu1)
                    .HasColumnName("Menu")
                    .HasMaxLength(50);

                entity.Property(e => e.MenuCode).HasMaxLength(20);

                entity.Property(e => e.MenuTypeId).HasColumnName("MenuTypeID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.RootId).HasColumnName("RootID");

                entity.Property(e => e.TargetUrl)
                    .HasColumnName("TargetURL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.MenuType)
                    .WithMany(p => p.Menu)
                    .HasForeignKey(d => d.MenuTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Menu1");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Menu2");
            });

            modelBuilder.Entity<MenuRights>(entity =>
            {
                entity.HasKey(e => e.MenuId)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.MenuId)
                    .HasColumnName("MenuID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.Menu)
                    .WithOne(p => p.MenuRights)
                    .HasForeignKey<MenuRights>(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuRights");
            });

            modelBuilder.Entity<MenuType>(entity =>
            {
                entity.HasKey(e => e.MenuTypeId)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.MenuType1)
                    .HasName("UNK_MenuType")
                    .IsUnique();

                entity.Property(e => e.MenuTypeId)
                    .HasColumnName("MenuTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MenuType1)
                    .HasColumnName("MenuType")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.Role1)
                    .HasName("UNK_Role")
                    .IsUnique();

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Role1)
                    .HasColumnName("Role")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RoleMenuAccess>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.MenuId })
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.RoleMenuAccess)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleMenuAccess2");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleMenuAccess)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleMenuAccess1");
            });

            modelBuilder.Entity<RoleMenuAuthorization>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.MenuId })
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.RoleMenuAuthorization)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleMenuAuthorization2");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleMenuAuthorization)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleMenuAuthorization1");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.StateId)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => new { e.State1, e.CountryId })
                    .HasName("UNK_State")
                    .IsUnique();

                entity.Property(e => e.StateId)
                    .HasColumnName("StateID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.State1)
                    .HasColumnName("State")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_State");
            });

            modelBuilder.Entity<SystemConstant>(entity =>
            {
                entity.HasKey(e => e.ConstantId)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.ConstantName)
                    .HasName("UNK_SystemConstant")
                    .IsUnique();

                entity.Property(e => e.ConstantId)
                    .HasColumnName("ConstantID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ConstantName).HasMaxLength(50);

                entity.Property(e => e.ConstantValue).HasMaxLength(50);

                entity.Property(e => e.DisplayName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_Users")
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.Email)
                    .HasName("UNK_Email")
                    .IsUnique();

                entity.HasIndex(e => e.UserName)
                    .HasName("UNK_Users")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users");
            });

            modelBuilder.Entity<UserMenuAccess>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.MenuId })
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.UserMenuAccess)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserMenuAccess2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserMenuAccess)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserMenuAccess1");
            });

            modelBuilder.Entity<UserMenuAuthorization>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.MenuId })
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.UserMenuAuthorization)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserMenuAuthorization2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserMenuAuthorization)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserMenuAuthorization1");
            });
        }
    }
}
