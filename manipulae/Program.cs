using manipulae.Data;
using manipulae.Services;
using Microsoft.EntityFrameworkCore;

namespace manipulae
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connection = builder.Configuration["ConnectionStrings:SqlitePath"];

            // Add services to the container.

            builder.Services.AddControllers();

            // Add Database
            builder.Services.AddDbContext<VideoDbContext>(opts => opts.UseSqlite(connection));
            builder.Services.AddHttpClient<IVideosSeederService, YoutubeSeederService>();
            builder.Services.AddTransient<VideoSeeder>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<VideoDbContext>();
                db.Database.Migrate();
            }

            using (var scope = app.Services.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<VideoSeeder>();
                seeder.Execute();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}