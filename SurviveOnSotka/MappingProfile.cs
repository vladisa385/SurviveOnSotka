using System.Linq;
using AutoMapper;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Categories;
using SurviveOnSotka.ViewModel.CheapPlaces;
using SurviveOnSotka.ViewModel.Cities;
using SurviveOnSotka.ViewModel.Ingredients;
using SurviveOnSotka.ViewModel.IngredientToRecipe;
using SurviveOnSotka.ViewModel.Levels;
using SurviveOnSotka.ViewModel.RateCheapPlaces;
using SurviveOnSotka.ViewModel.RateReviews;
using SurviveOnSotka.ViewModel.Recipies;
using SurviveOnSotka.ViewModel.Reviews;
using SurviveOnSotka.ViewModel.Steps;
using SurviveOnSotka.ViewModel.TypeFoods;
using SurviveOnSotka.ViewModel.Users;


namespace SurviveOnSotka
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // mapping to and from
            CreateMap<Category, CategoryResponse>()
                .ForMember(d => d.RecipiesCount, o => o.MapFrom(src => src.Recipies.Count))
                .ForMember(d => d.ParentCategory, o => o.MapFrom(u => u.ParentCategory.Id))
                ;
            CreateMap<UpdateCategoryRequest, Category>();
            CreateMap<CreateCategoryRequest, Category>();

            CreateMap<TypeFood, TypeFoodResponse>()
                .ForMember(d => d.IngredientsCount, o => o.MapFrom(src => src.Ingredients.Count));
            CreateMap<UpdateTypeFoodRequest, TypeFood>();
            CreateMap<CreateTypeFoodRequest, TypeFood>();

            CreateMap<City, CityResponse>()
               .ForMember(d => d.CheapPlacesCount, o => o.MapFrom(src => src.CheapPlaces.Count));
            CreateMap<CreateCityRequest, City>();
            CreateMap<UpdateCityRequest, City>();

            CreateMap<CheapPlace, CheapPlaceResponse>().
                ForMember(d => d.Author, o => o.MapFrom(src => Mapper.Map<User, UserResponse>(src.User))).
            ForMember(d => d.Likes, o => o.MapFrom(src => src.RateCheapPlaces.Count(u => u.IsCool == true))).
            ForMember(d => d.DisLikes, o => o.MapFrom(src => src.RateCheapPlaces.Count(u => u.IsCool != true)));

            CreateMap<UpdateCheapPlaceRequest, CheapPlace>();
            CreateMap<CreateCheapPlaceRequest, CheapPlace>();

            CreateMap<User, UserResponse>()
                .ForMember(d => d.RecipiesCount, o => o.MapFrom(src => src.Recipies.Count))
                .ForMember(d => d.CheapPlacesCount, o => o.MapFrom(src => src.CheapPlaces.Count))
                .ForMember(d => d.RateReviewsCount, o => o.MapFrom(src => src.RateReviews.Count))
                .ForMember(d => d.ReviewsCount, o => o.MapFrom(src => src.Reviews.Count))
                .ForMember(d => d.RateCheapPlacesCount, o => o.MapFrom(src => src.RateCheapPlaces.Count))
                .ForMember(d => d.Id, o => o.MapFrom(src => src.Id))
                .ForMember(d => d.Email, o => o.MapFrom(src => src.Email))
                .ForMember(d => d.UserName, o => o.MapFrom(src => src.UserName))
                .ForMember(d => d.FirstName, o => o.MapFrom(src => src.FirstName))
                .ForMember(d => d.LastName, o => o.MapFrom(src => src.LastName))
                .ForMember(d => d.PathToAvatar, o => o.MapFrom(src => src.PathToAvatar))
                .ForMember(d => d.LevelId, o => o.MapFrom(src => src.LevelId))
                .ForMember(d => d.Gender, o => o.MapFrom(src => src.Gender))
                .ForMember(d => d.AboutYourself, o => o.MapFrom(src => src.AboutYourself))
                 .ForMember(d => d.LastName, o => o.MapFrom(src => src.LastName))
                 .ForMember(d => d.Gender, o => o.MapFrom(src => src.Gender))



                .ForAllOtherMembers(opts => opts.Ignore());
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();

            CreateMap<Ingredient, IngredientResponse>()
                .ForMember(d => d.RecipiesCount, o => o.MapFrom(src => src.Recipies.Count));

            CreateMap<UpdateIngredientRequest, Ingredient>();
            CreateMap<CreateIngredientRequest, Ingredient>();


            CreateMap<Level, LevelResponse>();
            CreateMap<UpdateLevelRequest, Level>();
            CreateMap<CreateLevelRequest, Level>();

            CreateMap<Step, StepResponse>();
            CreateMap<UpdateStepRequest, Step>();
            CreateMap<CreateStepRequest, Step>();

            CreateMap<IngredientToRecipe, IngredientToRecipeResponse>();
            CreateMap<UpdateIngredientToRecipeRequest, IngredientToRecipe>()
                .ForMember(u => u.RecipeId, pt => pt.Ignore());
            CreateMap<CreateIngredientToRecipeRequest, IngredientToRecipe>()
                   .ForMember(u => u.RecipeId, pt => pt.Ignore());
            CreateMap<Recipe, RecipeResponse>().
            ForMember(d => d.User, o => o.MapFrom(src => Mapper.Map<User, UserResponse>(src.User)))
              .ForMember(dest => dest.Tags, opt => opt.MapFrom(so => so.Tags.Select(t => t.Tag.Name).ToList()));
            CreateMap<UpdateRecipeRequest, Recipe>().
            ForMember(d => d.Tags, pt => pt.Ignore());
            CreateMap<CreateRecipeRequest, Recipe>().
            ForMember(d => d.Tags, pt => pt.Ignore());
            CreateMap<Review, ReviewResponse>().
                ForMember(d => d.Author, o => o.MapFrom(src => Mapper.Map<User, UserResponse>(src.Author))).
                ForMember(d => d.Likes, o => o.MapFrom(src => src.RateReviews.Count(u => u.IsCool == true))).
            ForMember(d => d.DisLikes, o => o.MapFrom(src => src.RateReviews.Count(u => u.IsCool != true)));
            CreateMap<UpdateReviewRequest, Review>();
            CreateMap<CreateReviewRequest, Review>();

            CreateMap<RateReview, RateReviewResponse>();
            CreateMap<UpdateRateReviewRequest, RateReview>();
            CreateMap<CreateRateReviewRequest, RateReview>();

            CreateMap<RateCheapPlace, RateCheapPlaceResponse>();

            CreateMap<UpdateRateCheapPlaceRequest, RateCheapPlace>();
            CreateMap<CreateRateCheapPlaceRequest, RateCheapPlace>();


        }
    }



}

