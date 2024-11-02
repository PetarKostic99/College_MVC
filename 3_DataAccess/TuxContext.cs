using BusinessObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace DataAccess
{
    public class TuxContext : DbContext
    {
        public DbSet<College> College { get; set; }
        public DbSet<HighSchool> HighSchool { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Admin> Admin { get; set; }

        public TuxContext() : base("name=TuxDatabase")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Mapping type entinty to table name from db
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<UserRole>().ToTable("UserRole");

            //Mapping by Discriminator
            modelBuilder.Entity<Professor>()
                .Map<Professor>(m => m.Requires("TypeOfUser").HasValue("Professor"));
            modelBuilder.Entity<HighSchool>()
                .Map<HighSchool>(m => m.Requires("TypeOfUser").HasValue("HighSchool"));
            modelBuilder.Entity<College>()
                .Map<College>(m => m.Requires("TypeOfUser").HasValue("College"));
            modelBuilder.Entity<Admin>()
                .Map<Admin>(m => m.Requires("TypeOfUser").HasValue("Admin"));

            //Defining Key
            modelBuilder.Entity<UserRole>()
                .HasKey(c => new { c.UserId, c.RoleId });
            modelBuilder.Entity<Users>()
                .HasKey(u => u.UserId);
            modelBuilder.Entity<Role>()
                .HasKey(u => u.RoleId);

            //Defininig DatabaseGeneratedOption
            modelBuilder.Entity<Users>()
                .Property(u => u.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Role>()
                .Property(u => u.RoleId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Definig many-to-many relationship
            modelBuilder.Entity<Users>()
                 .HasMany(c => c.UserRole)
                 .WithRequired()
                 .HasForeignKey(c => c.UserId)
                 .WillCascadeOnDelete(true);
            modelBuilder.Entity<Role>()
                 .HasMany(c => c.UserRole)
                 .WithRequired()
                 .HasForeignKey(c => c.RoleId)
                 .WillCascadeOnDelete(true);

            Database.SetInitializer<TuxContext>(null);
        }
    }
}
