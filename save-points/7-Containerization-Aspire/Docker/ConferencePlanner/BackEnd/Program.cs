using BackEnd.Data;
using BackEnd.Endpoints;

namespace BackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
               ?? "Data Source=conferences.db";

            builder.Services.AddSqlite<BackEnd.Data.ApplicationDbContext>(connectionString);

            builder.Services.AddHealthChecks()
                            .AddDbContextCheck<ApplicationDbContext>();

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.MapHealthChecks("/health");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapSpeakerEndpoints();
            app.MapAttendeeEndpoints();
            app.MapSessionEndpoints();
            app.MapSearchEndpoints();

            app.Run();
        }
    }
}
