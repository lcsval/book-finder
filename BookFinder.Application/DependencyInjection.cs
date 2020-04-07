using AutoMapper;
using BookFinder.Application.Book.Queries.GetBooks;
using BookFinder.Application.Shared;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookFinder.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetAssembly(typeof(GetBookQueryHandler)));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }
    }
}
