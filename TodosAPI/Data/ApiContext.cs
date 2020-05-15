
using Microsoft.EntityFrameworkCore;
using TodosAPI.Helpers;
using TodosAPI.Models;

namespace TodosAPI.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
          : base(options)
        {}
        
        public DbSet<Todo> Todos { get; set; }

        public DbSet<TodoList> TodoLists { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // initial user. password must be changed later.
    modelBuilder.Entity<User>()
      .HasData(new User { Id = 1, Username = "admin", Password = AuthenticationHelper.ComputeHash("123"), Role = User.RoleEnum.admin.ToString() });

    // set uUsername as Unique
    modelBuilder.Entity<User>()
      .HasIndex(u => u.Username)
      .IsUnique();
}
        
    }
}