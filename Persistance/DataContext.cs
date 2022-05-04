using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Domain;
using Activity = Domain.Activity;

namespace Persistance;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Activity> Activities { get; set; }
}
