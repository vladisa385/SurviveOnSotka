using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Rewrite;
using SurviveOnSotka.DataAccess.Categories;
using SurviveOnSotka.DataAccess.CheapPlaces;
using SurviveOnSotka.DataAccess.Cities;
using SurviveOnSotka.DataAccess.DbImplementation.Categories;
using SurviveOnSotka.DataAccess.DbImplementation.CheapPlaces;
using SurviveOnSotka.DataAccess.DbImplementation.Cities;
using SurviveOnSotka.DataAccess.DbImplementation.Tags;
using SurviveOnSotka.DataAccess.DbImplementation.TypeFoods;
using SurviveOnSotka.DataAccess.DbImplementation.Users;
using SurviveOnSotka.DataAccess.Tags;
using SurviveOnSotka.DataAccess.TypeFoods;
using SurviveOnSotka.DataAccess.Users;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;


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
            services.AddHttpContextAccessor();
            services.AddMvc();
            services.AddAutoMapper(typeof(Startup));
            //services.AddAutoMapper();
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
            services.AddIdentity<User, IdentityRole>()
             .AddEntityFrameworkStores<AppDbContext>();

            services.ConfigureApplicationCookie(options =>
       {
           options.Events.OnRedirectToLogin = context =>
           {
               context.Response.StatusCode = 401;
               return Task.CompletedTask;
           };
           options.Events.OnRedirectToAccessDenied = context =>
          {
              context.Response.StatusCode = 403;
              return Task.CompletedTask;
          };
       });
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
            app.UseAuthentication(

                );
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

                .AddScoped<ITypeFoodQuery, TypeFoodQuery>()
                .AddScoped<ITypeFoodsListQuery, TypeFoodsListQuery>()
                .AddScoped<ICreateTypeFoodCommand, CreateTypeFoodCommand>()
                .AddScoped<IUpdateTypeFoodCommand, UpdateTypeFoodCommand>()
                .AddScoped<IDeleteTypeFoodCommand, DeleteTypeFoodCommand>()

                .AddScoped<ICitiesListQuery, CitiesListQuery>()

                .AddScoped<ICheapPlaceQuery, CheapPlaceQuery>()
                .AddScoped<ICheapPlacesListQuery, CheapPlacesListQuery>()
                .AddScoped<ICreateCheapPlaceCommand, CreateCheapPlaceCommand>()
                .AddScoped<IUpdateCheapPlaceCommand, UpdateCheapPlaceCommand>()
                .AddScoped<IDeleteCheapPlaceCommand, DeleteCheapPlaceCommand>()


                .AddScoped<ICreateUserCommand, CreateUserCommand>()
                .AddScoped<ILogOffUserCommand, LogOffUserCommand>()
                .AddScoped<ILoginUserCommand, LoginUserCommand>()
                .AddScoped<IUpdateUserCommand, UpdateUserCommand>()
                 .AddScoped<IUserQuery, UserQuery>()
                .AddScoped<IUsersListQuery, UsersListQuery>()
                .AddScoped<IDeleteUserCommand, DeleteUserCommand>()

                ;
        }
    }


}
