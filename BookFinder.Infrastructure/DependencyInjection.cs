using BookFinder.Domain.Repositories;
using BookFinder.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookFinder.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
