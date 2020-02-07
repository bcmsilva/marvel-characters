using MarvelCharacters.Domain;
using MarvelCharacters.Domain.Repositories;
using MarvelCharacters.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MarvelCharacters.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MarvelCatalogContext>();
            services.AddScoped<ICharactersRepository, CharactersRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            //using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetRequiredService<MarvelCatalogContext>();
            //    context.Database.EnsureCreated();


            //    var aa3 = serviceScope.ServiceProvider.GetService<ICharactersRepository>();

            //    var resultado = aa3.GetCharactersAsync(new Domain.Queries.GetPagedCharactersQuery { });

            //    var bla = resultado.Result;
            //}

            //var cc = aa.Events.AsNoTracking().Include(i => i.Characters).ThenInclude(i => i.Character).ToList();
            ////var dd = aa.Characters.Include(i => i.Events).ToList();

            //var bb = aa.Characters.Select(a => new
            //{
            //    a.Id,
            //    a.Name,
            //    ComicTitle = a.Events[0]
            //}).FirstOrDefault();
        }
    }
}
