using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Bright_Future.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ContactInquiry> ContactInquiries { get; set; }
    }
}