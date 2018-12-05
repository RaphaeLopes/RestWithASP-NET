using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestWithASP_NET.Model.Context;
using Microsoft.EntityFrameworkCore;
using Tapioca.HATEOAS;
using RestWithASP_NET.HyperMedia;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Rewrite;

namespace RestWithASP_NET
{
    public class Startup
    {
        private readonly ILogger _logger;
        public IConfiguration _configuration { get; }
        public IHostingEnvironment _environment { get; }
        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;
            _logger = logger;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySqlContext>(options => options.UseMySql(connectionString));

            if (_environment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                    var evolve = new Evolve.Evolve("Evolve.json", evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<string> { "db/migrations" },
                        IsEraseDisabled = true,
                    };
                    evolve.Migrate();
                }
                catch (System.Exception ex)
                {
                    _logger.LogCritical("DataBase migrations failed.", ex);
                    throw;
                }
            }

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Enricher
            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ObjectContentResponseEnricherList.Add(new PersonEnricher());
            filterOptions.ObjectContentResponseEnricherList.Add(new BookEnricher());
            services.AddSingleton(filterOptions);

            services.AddApiVersioning();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "RESTful API With ASP.NET Core 2.1", Version = "v1" });
            });

            //Dependency Injection
            services.AddScoped<Business.IPersonBusiness, Business.Implementations.PersonBusinessImpl>();
            services.AddScoped<Repository.IPersonRepository, Repository.Implementations.PersonRepositoryImpl>();
            services.AddScoped<Business.IBookBusiness, Business.Implementations.BookBusinessImpl>();
            services.AddScoped(typeof(Repository.Generic.IRepository<>), typeof(Repository.Generic.GenericRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseHsts();
            //}
            //app.UseHttpsRedirection();
            //Iniciando o swagger
            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("../swagger/v1/swagger.json", "My API V1");
            //});
          
            app
            .UseSwagger()
            .UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("v1/swagger.json", "Data Archiving API V1");
            });

            //Redireciona para a pagina do swagger
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "DefaultApi",
                  template: "{controller=Values}/{id?}"
                );
            });
        }
    }
}
