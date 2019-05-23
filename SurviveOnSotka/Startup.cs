using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SurviveOnSotka.DataAccess.CQRSOperation;
using SurviveOnSotka.DataAccess.DbImplementation.Categories;
using SurviveOnSotka.DataAccess.DbImplementation.Ingredients;
using SurviveOnSotka.DataAccess.DbImplementation.RateReviews;
using SurviveOnSotka.DataAccess.DbImplementation.Recipies;
using SurviveOnSotka.DataAccess.DbImplementation.Reviews;
using SurviveOnSotka.DataAccess.DbImplementation.Tags;
using SurviveOnSotka.DataAccess.DbImplementation.TypeFoods;
using SurviveOnSotka.DataAccess.DbImplementation.Users;
using SurviveOnSotka.DataAccess.Users;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.Filters;
using SurviveOnSotka.Middlewares;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.Categories;
using SurviveOnSotka.ViewModel.Implementanion.Ingredients;
using SurviveOnSotka.ViewModel.Implementanion.RateReviews;
using SurviveOnSotka.ViewModel.Implementanion.Recipies;
using SurviveOnSotka.ViewModel.Implementanion.Reviews;
using SurviveOnSotka.ViewModel.Implementanion.Tags;
using SurviveOnSotka.ViewModel.Implementanion.TypeFoods;


namespace SurviveOnSotka
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

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
                .AddScoped<Command<CreateCategoryRequest, CategoryResponse>, CreateCategoryCommand>()
                .AddScoped<Command<UpdateCategoryRequest, CategoryResponse>, UpdateCategoryCommand>()
                .AddScoped<Command<SimpleDeleteRequest,CategoryResponse>, DeleteCategoryCommand>()

                .AddScoped<ListQuery<TagResponse,TagFilter>, TagsListQuery>()
                .AddScoped<Command<SimpleDeleteRequest,TagResponse>, DeleteTagCommand>()

                .AddScoped<Query<IngredientResponse>, IngredientQuery>()
                .AddScoped<ListQuery<IngredientResponse,IngredientFilter>, IngredientsListQuery>()
                .AddScoped<Command<CreateIngredientRequest,IngredientResponse>, CreateIngredientCommand>()
                .AddScoped<Command<UpdateIngredientRequest,IngredientResponse>, UpdateIngredientCommand>()
                .AddScoped<Command<SimpleDeleteRequest,IngredientResponse>, DeleteIngredientCommand>()

                 .AddScoped<Query<TypeFoodResponse>, TypeFoodQuery>()
                .AddScoped<ListQuery<TypeFoodResponse, TypeFoodFilter>, TypeFoodsListQuery>()
                .AddScoped<Command<CreateTypeFoodRequest, TypeFoodResponse>, CreateTypeFoodCommand>()
                .AddScoped<Command<UpdateTypeFoodRequest, TypeFoodResponse>, UpdateTypeFoodCommand>()
                .AddScoped<Command<SimpleDeleteRequest,TypeFoodResponse>, DeleteTypeFoodCommand>()


                .AddScoped<ICreateUserCommand, CreateUserCommand>()
                .AddScoped<ILogOffUserCommand, LogOffUserCommand>()
                .AddScoped<ILoginUserCommand, LoginUserCommand>()
                .AddScoped<IChangeUserPasswordCommand, ChangeUserPasswordCommand>()
                .AddScoped<IUpdateUserCommand, UpdateUserCommand>()
                .AddScoped<IUserQuery, UserQuery>()
                .AddScoped<IUsersListQuery, UsersListQuery>()
                .AddScoped<IDeleteUserCommand, DeleteUserCommand>()

                .AddScoped<Query<RecipeResponse>, RecipeQuery>()
                .AddScoped<ListQuery<RecipeResponse,RecipeFilter>, RecipiesListQuery>()
                .AddScoped<Command<CreateRecipeRequest,RecipeResponse>, CreateRecipeCommand>()
                .AddScoped<Command<UpdateRecipeRequest,RecipeResponse>, UpdateRecipeCommand>()
                .AddScoped<Command<SimpleDeleteRequest,RecipeResponse>, DeleteRecipeCommand>()

                .AddScoped<Query<ReviewResponse>, ReviewQuery>()
                .AddScoped<ListQuery<ReviewResponse, ReviewFilter>, ReviewsListQuery>()
                .AddScoped<Command<CreateReviewRequest,ReviewResponse>, CreateReviewCommand>()
                .AddScoped<Command<UpdateReviewRequest,ReviewResponse>, UpdateReviewCommand>()
                .AddScoped<Command<SimpleDeleteRequest,ReviewResponse>, DeleteReviewCommand>()

                .AddScoped<Query<RateReviewResponse>, RateReviewQuery>()
                .AddScoped<ListQuery<RateReviewResponse, RateReviewFilter>, RateReviewsListQuery>()
                .AddScoped<Command<CreateRateReviewRequest, RateReviewResponse>, CreateRateReviewCommand>()
                .AddScoped<Command<UpdateRateReviewRequest, RateReviewResponse>, UpdateRateReviewCommand>()
                .AddScoped<Command<SimpleDeleteRequest, RateReviewResponse>, DeleteRateReviewCommand>()

                .AddScoped<ModelValidationAttribute>()
                .AddScoped<InjectUserId>()
            ;
        }
    }


}
