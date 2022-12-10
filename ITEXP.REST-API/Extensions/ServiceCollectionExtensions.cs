
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

public static class Extensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) =>
               services
                   .AddDbContext<ITEXPContext>(options =>
                   {
                       var sqliteConnection = configuration.GetConnectionString("SQLiteConnection");

                       if (!string.IsNullOrWhiteSpace(sqliteConnection))
                       {
                           options.UseSqlite(sqliteConnection);
                       }
                   });
}