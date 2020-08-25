using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using VideoClubWebApi.Models;

using System.Reflection;
using System.IO;

//hace respetar la convencion en la que cada request tiene sus status code respectivo
[assembly: ApiConventionType(typeof(DefaultApiConventions))]

namespace VideoClubWebApi
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

            services.AddControllers();

            //configurar el dbcontext con la base de datos, esta en secrets.json
            services.AddDbContext<VideoClubDbContext>(options =>
     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionLocal")));

            //agregar servicio Swagger Generation
            services.AddSwaggerGen(config =>
            {

                config.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Version = "v1", Title = "Mi API Version 1", //campos mas usados
                    Description = "Esta es una descripción del Web API",
                    TermsOfService = new Uri("https://www.udemy.com/user/felipegaviln/"),
                    License = new OpenApiLicense()
                    {
                        Name = "MIT",
                        Url = new Uri("http://bfy.tw/4nqh")
                    },
                    Contact = new OpenApiContact()
                    {
                        Name = "Felipe Gavilán",
                        Email = "felipe_gavilan887@hotmail.com",
                        Url = new Uri("https://gavilan.blog/")
                    }
                });// fin swagger doc

                //se configura (junto al archivo csproj, propertygroup) para poder escribir 
                //documentacion en formato xml
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //configurar Swagger
            app.UseSwagger();
            app.UseSwaggerUI(config=>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API Version 1");
            });



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
