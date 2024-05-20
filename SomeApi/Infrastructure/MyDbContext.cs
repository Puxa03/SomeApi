using Microsoft.EntityFrameworkCore;
using SomeApi.Models;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
}