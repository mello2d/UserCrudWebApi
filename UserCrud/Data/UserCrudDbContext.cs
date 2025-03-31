using Microsoft.EntityFrameworkCore;
using UserCrud.Models;

namespace UserCrud.Data;

public class UserCrudDbContext : DbContext
{
    public DbSet<UserModel> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString: "Data Source=usercrud.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}