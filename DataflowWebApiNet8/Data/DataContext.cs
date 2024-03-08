using DataflowWebApiNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace DataflowWebApiNet8.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {   
        }
        public DbSet<Products> products { get; set; }
    }
}
