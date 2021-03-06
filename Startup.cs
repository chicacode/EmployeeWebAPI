﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using EmployeeWebAPI.Data;

namespace EmployeeWebAPI
{
    public class Startup
    {
        public Startup ( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices ( IServiceCollection services )
        {

            services.AddCors ( options =>
            {
                options.AddPolicy ( "AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins ( "http://example.com" );


                    } );
                options.AddPolicy ( "AllowSpecificOrigin",

                    builder =>
                    {
                        builder.WithOrigins ( "http://127.0.0.1:5500" )
                        .AllowAnyHeader ()
                        .AllowAnyMethod ();
                    } );
            } );



            services.AddControllers ();

            // Inserción de dependencias
            services.AddDbContext<EmployeeWebAPIContext> ( options =>
                      options.UseSqlServer ( Configuration.GetConnectionString ( "EmployeeWebAPIContext" ) ) );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure ( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if(env.IsDevelopment ())
            {
                app.UseDeveloperExceptionPage ();
            }


            app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseCors ();

            app.UseAuthorization ();

            app.UseEndpoints ( endpoints =>
              {
                  endpoints.MapControllers ();
              } );
        }
    }
}
