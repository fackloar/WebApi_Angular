using Microsoft.EntityFrameworkCore;
using MyRTEX.DataLayer.Models;

namespace MyRTEX.DataLayer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }
    }
}
