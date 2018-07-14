﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using SurviveOnSotka.DataAccess.Categories;
using SurviveOnSotka.DataAccess.DbImplementation.Categories;
using SurviveOnSotka.DataAccess.DbImplementation.Tags;
using SurviveOnSotka.DataAccess.Tags;
using SurviveOnSotka.Db;


namespace SurviveOnSotka
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
            RegisterQueriesAndCommands(services);
            services.AddMvc();
            services.AddAutoMapper(typeof(Startup));
            //services.AddAutoMapper();
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "App recipes API",
                    Version = "v1",
                    Description = "API for movile app about recipe",
                    TermsOfService = "None",
                    License = new License { Name = "Use under MIT" },
                    Contact = new Contact { Name = "vladisa385", Url = "https://github.com/vladisa385" }
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseMvc();


        }

        private void RegisterQueriesAndCommands(IServiceCollection services)
        {
            services
                .AddScoped<ICategoryQuery, CategoryQuery>()
                .AddScoped<ICategoriesListQuery, CategoriesListQuery>()
                .AddScoped<ICreateCategoryCommand, CreateCategoryCommand>()
                .AddScoped<IUpdateCategoryCommand, UpdateCategoryCommand>()
                .AddScoped<IDeleteCategoryCommand, DeleteCategoryCommand>()

                .AddScoped<ITagsListQuery, TagsListQuery>()
                .AddScoped<IDeleteTagCommand, DeleteTagCommand>()
                ;
        }
    }


}
