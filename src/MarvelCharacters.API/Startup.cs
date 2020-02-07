using MarvelCharacters.Domain;
using MarvelCharacters.Domain.QueryHandler;
using MarvelCharacters.Domain.Repositories;
using MarvelCharacters.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MarvelCharacters.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IMarvelCatalogContext, MarvelCatalogContext>();
            
            services.AddScoped<CharactersQueryHandler>();
            services.AddScoped<ComicsQueryHandler>();
            services.AddScoped<EventsQueryHandler>();
            services.AddScoped<SeriesQueryHandler>();
            services.AddScoped<StoriesQueryHandler>();

            services.AddScoped<ICharactersRepository, CharactersRepository>();
            services.AddScoped<IComicsRepository, ComicsRepository>();
            services.AddScoped<IEventsRepository, EventsRepository>();
            services.AddScoped<ISeriesRepository, SeriesRepository>();
            services.AddScoped<IStoriesRepository, StoriesRepository>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<IMarvelCatalogContext>();
                ((MarvelCatalogContext)context).Database.EnsureCreated();
            }
        }
    }
}
