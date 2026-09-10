using MediLibAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MediLibAPI.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options): base(options) { }
        public DbSet<LabTestBooking> labTests { get; set; }
    }
}
