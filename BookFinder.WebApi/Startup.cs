using BookFinder.Application;
using BookFinder.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace BookFinder.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure();

            services.AddLogging();

            services.AddHttpContextAccessor();

            services.AddControllers();
            //.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ITravelContext>()) //verificar para pegar um validator

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "book finder",
                        Version = "v1",
                        Description = "book finder api",
                        Contact = new OpenApiContact
                        {
                            Name = "Book Finder"
                        }
                    });

                var commentFileName = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var commentFilePath = Path.Combine(AppContext.BaseDirectory, commentFileName);

                options.IncludeXmlComments(commentFilePath);
                options.CustomSchemaIds(x => x.ToString().Replace("`1", string.Empty).Replace("[", "<").Replace("]", ">"));
            });

            services.AddSwaggerGenNewtonsoftSupport();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllOrigins");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "APIs - Intelligent Checkouts");
            });
        }
    }
}
