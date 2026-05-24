using Microsoft.EntityFrameworkCore;
using HigienizeMVC.Models;

namespace HigienizeMVC.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }

    public DbSet<Comment> Comments { get; set; }
}