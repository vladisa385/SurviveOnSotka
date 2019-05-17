using System.Linq;
using AutoMapper;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Categories;
using SurviveOnSotka.ViewModel.Ingredients;
using SurviveOnSotka.ViewModel.IngredientToRecipe;
using SurviveOnSotka.ViewModel.RateReviews;
using SurviveOnSotka.ViewModel.Recipies;
using SurviveOnSotka.ViewModel.Reviews;
using SurviveOnSotka.ViewModel.Steps;
using SurviveOnSotka.ViewModel.Tags;
using SurviveOnSotka.ViewModel.TagsInRecipe;
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

            CreateMap<User, UserResponse>()
                .ForMember(d => d.RecipiesCount, o => o.MapFrom(src => src.Recipies.Count))
                .ForMember(d => d.RateReviewsCount, o => o.MapFrom(src => src.RateReviews.Count))
                .ForMember(d => d.ReviewsCount, o => o.MapFrom(src => src.Reviews.Count))
                .ForMember(d => d.Id, o => o.MapFrom(src => src.Id))
                .ForMember(d => d.Email, o => o.MapFrom(src => src.Email))
                .ForMember(d => d.UserName, o => o.MapFrom(src => src.UserName))
                .ForMember(d => d.FirstName, o => o.MapFrom(src => src.FirstName))
                .ForMember(d => d.LastName, o => o.MapFrom(src => src.LastName))
                .ForMember(d => d.PathToAvatar, o => o.MapFrom(src => src.PathToAvatar))
                .ForMember(d => d.Gender, o => o.MapFrom(src => src.Gender))
                .ForMember(d => d.AboutYourself, o => o.MapFrom(src => src.AboutYourself))
                 .ForMember(d => d.LastName, o => o.MapFrom(src => src.LastName))
                 .ForMember(d => d.Gender, o => o.MapFrom(src => src.Gender))



                .ForAllOtherMembers(opts => opts.Ignore());
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();

            CreateMap<Tag, TagResponse>()
               .ForMember(d => d.RecipiesCount, o => o.MapFrom(src => src.Recipies.Count))
               ;

            CreateMap<TagsInRecipe, TagsInRecipeResponse>();

            CreateMap<Ingredient, IngredientResponse>()
                .ForMember(d => d.RecipiesCount, o => o.MapFrom(src => src.Recipies.Count));

            CreateMap<UpdateIngredientRequest, Ingredient>();
            CreateMap<CreateIngredientRequest, Ingredient>();


            CreateMap<Step, StepResponse>();
            CreateMap<UpdateStepRequest, Step>();
            CreateMap<CreateStepRequest, Step>();

            CreateMap<IngredientToRecipe, IngredientToRecipeResponse>();
            CreateMap<UpdateIngredientToRecipeRequest, IngredientToRecipe>()
                .ForMember(u => u.RecipeId, pt => pt.Ignore());
            CreateMap<CreateIngredientToRecipeRequest, IngredientToRecipe>()
                   .ForMember(u => u.RecipeId, pt => pt.Ignore());
             CreateMap<UpdateRecipeRequest, Recipe>().
            ForMember(d => d.Tags, pt => pt.Ignore());
            CreateMap<CreateRecipeRequest, Recipe>().
            ForMember(d => d.Tags, pt => pt.Ignore());
                 CreateMap<UpdateReviewRequest, Review>();
            CreateMap<CreateReviewRequest, Review>();

            CreateMap<RateReview, RateReviewResponse>();
            CreateMap<UpdateRateReviewRequest, RateReview>();
            CreateMap<CreateRateReviewRequest, RateReview>();

        }
    }



}

