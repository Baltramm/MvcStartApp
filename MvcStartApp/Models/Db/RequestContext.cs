using Microsoft.EntityFrameworkCore;

namespace MvcStartApp.Models.Db
{
    public class RequestContext:DbContext
    {
        public DbSet<Request> Requests { get; set; }
        public RequestContext(DbContextOptions<RequestContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
