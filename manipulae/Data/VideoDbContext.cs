using manipulae.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace manipulae.Data
{
    public class VideoDbContext : DbContext
    {

        public VideoDbContext(DbContextOptions<VideoDbContext> opts) : base(opts)
        {
        }

        public DbSet<Video> Videos { get; set; }

    }
}
