using Application.Interfaces;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
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

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped(typeof(IRepositoryAsync<,>), typeof(RepositoryAsync<,>))
            .AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
    }
}