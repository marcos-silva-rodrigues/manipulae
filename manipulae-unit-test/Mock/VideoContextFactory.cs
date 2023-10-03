using manipulae.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manipulae_unit_test.Mock
{
    public class VideoContextFactory: IDbContextFactory<VideoDbContext>
    {

        public VideoDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<VideoDbContext>()
                .UseInMemoryDatabase($"InMemoryTestDb-{DateTime.Now.ToFileTimeUtc()}")
                .Options;

            return new VideoDbContext(options);
        }
    }
}
