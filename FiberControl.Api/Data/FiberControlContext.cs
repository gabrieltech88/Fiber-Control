
using FiberControlApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FiberControlApi.Data;

public class FiberControlContext : DbContext
{
    public DbSet<Olt> Olts { get; set; }
    public FiberControlContext(DbContextOptions<FiberControlContext> options) : base(options) { }
}