using Microsoft.EntityFrameworkCore;
using API.Data;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            string connectionString = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
            builder.Services.AddDbContext<TodoDbContext>(options =>
                options.UseSqlServer(connectionString ?? throw new InvalidOperationException("Connection string is not found.")));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            WebApplication app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
