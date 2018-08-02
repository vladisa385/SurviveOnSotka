using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Logging;
using SurviveOnSotka.DataAccess.Categories;
using SurviveOnSotka.DataAccess.CheapPlaces;
using SurviveOnSotka.DataAccess.Cities;
using SurviveOnSotka.DataAccess.DbImplementation.Categories;
using SurviveOnSotka.DataAccess.DbImplementation.CheapPlaces;
using SurviveOnSotka.DataAccess.DbImplementation.Cities;
using SurviveOnSotka.DataAccess.DbImplementation.Ingredients;
using SurviveOnSotka.DataAccess.DbImplementation.Levels;
using SurviveOnSotka.DataAccess.DbImplementation.RateCheapPlaces;
using SurviveOnSotka.DataAccess.DbImplementation.RateReviews;
using SurviveOnSotka.DataAccess.DbImplementation.Recipies;
using SurviveOnSotka.DataAccess.DbImplementation.Reviews;
using SurviveOnSotka.DataAccess.DbImplementation.Tags;
using SurviveOnSotka.DataAccess.DbImplementation.TypeFoods;
using SurviveOnSotka.DataAccess.DbImplementation.Users;
using SurviveOnSotka.DataAccess.Ingredients;
using SurviveOnSotka.DataAccess.Levels;
using SurviveOnSotka.DataAccess.RateCheapPlaces;
using SurviveOnSotka.DataAccess.RateReviews;
using SurviveOnSotka.DataAccess.Recipies;
using SurviveOnSotka.DataAccess.Reviews;
using SurviveOnSotka.DataAccess.Tags;
using SurviveOnSotka.DataAccess.TypeFoods;
using SurviveOnSotka.DataAccess.Users;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using ICreateCheapPlaceCommand = SurviveOnSotka.DataAccess.CheapPlaces.ICreateCheapPlaceCommand;
using IUpdateCheapPlaceCommand = SurviveOnSotka.DataAccess.CheapPlaces.IUpdateCheapPlaceCommand;


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

            services.AddElmahIo(o =>
            {
                o.ApiKey = "b9e4017a87b944cca841366342d02e89";
                o.LogId = new Guid("7fd15f9f-c859-4c8f-9913-4add9fa832c4");
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
            else
            {
                app.UseHsts();
            }
            // app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseElmahIo();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication(

                );
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();


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
                 .AddScoped<ICityQuery, CityQuery>()
                .AddScoped<ICreateCityCommand, CreateCityCommand>()
                .AddScoped<IUpdateCityCommand, UpdateCityCommand>()
                .AddScoped<IDeleteCityCommand, DeleteCityCommand>()

                .AddScoped<ICheapPlaceQuery, CheapPlaceQuery>()
                .AddScoped<ICheapPlacesListQuery, CheapPlacesListQuery>()
                .AddScoped<ICreateCheapPlaceCommand, CreateCheapPlaceCommand>()
                .AddScoped<IUpdateCheapPlaceCommand, UpdateCheapPlaceCommand>()
                .AddScoped<IDeleteCheapPlaceCommand, DeleteCheapPlaceCommand>()


                .AddScoped<IIngredientQuery, IngredientQuery>()
                .AddScoped<IIngredientsListQuery, IngredientsListQuery>()
                .AddScoped<ICreateIngredientCommand, CreateIngredientCommand>()
                .AddScoped<IUpdateIngredientCommand, UpdateIngredientCommand>()
                .AddScoped<IDeleteIngredientCommand, DeleteIngredientCommand>()

                .AddScoped<ILevelQuery, LevelQuery>()
                .AddScoped<ILevelsListQuery, LevelsListQuery>()
                .AddScoped<ICreateLevelCommand, CreateLevelCommand>()
                .AddScoped<IUpdateLevelCommand, UpdateLevelCommand>()
                .AddScoped<IDeleteLevelCommand, DeleteLevelCommand>()

                .AddScoped<ICreateUserCommand, CreateUserCommand>()
                .AddScoped<ILogOffUserCommand, LogOffUserCommand>()
                .AddScoped<ILoginUserCommand, LoginUserCommand>()
                .AddScoped<IChangeUserPasswordCommand, ChangeUserPasswordCommand>()
                .AddScoped<IUpdateUserCommand, UpdateUserCommand>()
                 .AddScoped<IUserQuery, UserQuery>()
                .AddScoped<IUsersListQuery, UsersListQuery>()
                .AddScoped<IDeleteUserCommand, DeleteUserCommand>()
                .AddScoped<IUpdateUserLevelCommand, UpdateUserLevelCommand>()

                .AddScoped<IRecipeQuery, RecipeQuery>()
                .AddScoped<IRecipiesListQuery, RecipiesListQuery>()
                .AddScoped<ICreateRecipeCommand, CreateRecipeCommand>()
                .AddScoped<IUpdateRecipeCommand, UpdateRecipeCommand>()
                .AddScoped<IDeleteRecipeCommand, DeleteRecipeCommand>()

                .AddScoped<IReviewQuery, ReviewQuery>()
                .AddScoped<IReviewsListQuery, ReviewsListQuery>()
                .AddScoped<ICreateReviewCommand, CreateReviewCommand>()
                .AddScoped<IUpdateReviewCommand, UpdateReviewCommand>()
                .AddScoped<IDeleteReviewCommand, DeleteReviewCommand>()

                .AddScoped<IRateReviewQuery, RateReviewQuery>()
                 .AddScoped<IRateReviewsListQuery, RateReviewsListQuery>()
                .AddScoped<ICreateRateReviewCommand, CreateRateReviewCommand>()
                .AddScoped<IUpdateRateReviewCommand, UpdateRateReviewCommand>()
                .AddScoped<IDeleteRateReviewCommand, DeleteRateReviewCommand>()

                  .AddScoped<IRateCheapPlaceQuery, RateCheapPlaceQuery>()
                .AddScoped<IRateCheapPlacesListQuery, RateCheapPlacesListQuery>()
                .AddScoped<ICreateRateCheapPlaceCommand, CreateRateCheapPlaceCommand>()
                .AddScoped<IUpdateRateCheapPlaceCommand, UpdateRateCheapPlaceCommand>()
                .AddScoped<IDeleteRateCheapPlaceCommand, DeleteRateCheapPlaceCommand>()
                ;
        }
    }


}
