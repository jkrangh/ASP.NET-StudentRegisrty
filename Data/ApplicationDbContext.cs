using ASP.NET_StudentRegisrty.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_StudentRegisrty.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
