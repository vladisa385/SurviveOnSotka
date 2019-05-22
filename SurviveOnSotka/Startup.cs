﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.CrudOperation;
using SurviveOnSotka.DataAccess.DbImplementation.Categories;
using SurviveOnSotka.DataAccess.DbImplementation.Ingredients;
using SurviveOnSotka.DataAccess.DbImplementation.RateReviews;
using SurviveOnSotka.DataAccess.DbImplementation.Recipies;
using SurviveOnSotka.DataAccess.DbImplementation.Reviews;
using SurviveOnSotka.DataAccess.DbImplementation.Tags;
using SurviveOnSotka.DataAccess.DbImplementation.TypeFoods;
using SurviveOnSotka.DataAccess.DbImplementation.Users;
using SurviveOnSotka.DataAccess.RateReviews;
using SurviveOnSotka.DataAccess.Recipies;
using SurviveOnSotka.DataAccess.Reviews;
using SurviveOnSotka.DataAccess.Users;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.Filters;
using SurviveOnSotka.Middlewares;
using SurviveOnSotka.ViewModel.Implementanion.Categories;
using SurviveOnSotka.ViewModel.Implementanion.Ingredients;
using SurviveOnSotka.ViewModel.Implementanion.Tags;
using SurviveOnSotka.ViewModel.Implementanion.TypeFoods;


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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddHttpContextAccessor();
            services.AddMvc();
            services.AddAutoMapper(typeof(Startup));
            RegisterQueriesAndCommands(services);
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
            services.AddIdentity<User, Role>()
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
            app.ConfigureCustomExceptionMiddleware();
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
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
                .AddScoped<Query<CategoryResponse>, CategoryQuery>()
                .AddScoped<ListQuery<CategoryResponse, CategoryFilter>, CategoriesListQuery>()
                .AddScoped<CreateCommand<CreateCategoryRequest, CategoryResponse>, CreateCategoryCommand>()
                .AddScoped<UpdateCommand<UpdateCategoryRequest, CategoryResponse>, UpdateCategoryCommand>()
                .AddScoped<DeleteCommand<CategoryResponse>, DeleteCategoryCommand>()

                .AddScoped<ListQuery<TagResponse,TagFilter>, TagsListQuery>()
                .AddScoped<DeleteCommand<TagResponse>, DeleteTagCommand>()

                .AddScoped<Query<IngredientResponse>, IngredientQuery>()
                .AddScoped<ListQuery<IngredientResponse,IngredientFilter>, IngredientsListQuery>()
                .AddScoped<CreateCommand<CreateIngredientRequest,IngredientResponse>, CreateIngredientCommand>()
                .AddScoped<UpdateCommand<UpdateIngredientRequest,IngredientResponse>, UpdateIngredientCommand>()
                .AddScoped<DeleteCommand<IngredientResponse>, DeleteIngredientCommand>()

                 .AddScoped<Query<TypeFoodResponse>, TypeFoodQuery>()
                .AddScoped<ListQuery<TypeFoodResponse, TypeFoodFilter>, TypeFoodsListQuery>()
                .AddScoped<CreateCommand<CreateTypeFoodRequest, TypeFoodResponse>, CreateTypeFoodCommand>()
                .AddScoped<UpdateCommand<UpdateTypeFoodRequest, TypeFoodResponse>, UpdateTypeFoodCommand>()
                .AddScoped<DeleteCommand<TypeFoodResponse>, DeleteTypeFoodCommand>()


                .AddScoped<ICreateUserCommand, CreateUserCommand>()
                .AddScoped<ILogOffUserCommand, LogOffUserCommand>()
                .AddScoped<ILoginUserCommand, LoginUserCommand>()
                .AddScoped<IChangeUserPasswordCommand, ChangeUserPasswordCommand>()
                .AddScoped<IUpdateUserCommand, UpdateUserCommand>()
                .AddScoped<IUserQuery, UserQuery>()
                .AddScoped<IUsersListQuery, UsersListQuery>()
                .AddScoped<IDeleteUserCommand, DeleteUserCommand>()

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

                .AddScoped<ModelValidationAttribute>();
            ;
        }
    }


}
