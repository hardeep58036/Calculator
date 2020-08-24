using CalculatorApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CalculatorApi.DBContext
{
    public class CalculatorDBContext : DbContext
    {
        public CalculatorDBContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Audit> Audits { get; set; }
    }
}
