using FilterValidation.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilterValidation.Data;
public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
}
