using AutoMapper;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.Categories;
using SurviveOnSotka.ViewModel.Implementanion.Ingredients;
using SurviveOnSotka.ViewModel.Implementanion.IngredientToRecipe;
using SurviveOnSotka.ViewModel.Implementanion.RateReviews;
using SurviveOnSotka.ViewModel.Implementanion.Recipies;
using SurviveOnSotka.ViewModel.Implementanion.Reviews;
using SurviveOnSotka.ViewModel.Implementanion.Steps;
using SurviveOnSotka.ViewModel.Implementanion.Tags;
using SurviveOnSotka.ViewModel.Implementanion.TagsInRecipe;
using SurviveOnSotka.ViewModel.Implementanion.TypeFoods;
using SurviveOnSotka.ViewModel.Implementanion.Users;

namespace SurviveOnSotka
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // mapping to and from
            CreateMap<Category, CategoryResponse>()
                .ForMember(d => d.RecipiesCount, o => o.MapFrom(src => src.Recipies.Count))
                .ForMember(d => d.CategoriesCount, o => o.MapFrom(src => src.Categories.Count));

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
                .ForMember(d => d.Avatar, o => o.MapFrom(src => src.Avatar))
                .ForMember(d => d.Gender, o => o.MapFrom(src => src.Gender))
                .ForMember(d => d.AboutYourself, o => o.MapFrom(src => src.AboutYourself))
                 .ForMember(d => d.LastName, o => o.MapFrom(src => src.LastName))
                 .ForMember(d => d.Gender, o => o.MapFrom(src => src.Gender))
                .ForAllOtherMembers(opts => opts.Ignore());
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();

            CreateMap<Tag, TagResponse>()
               .ForMember(d => d.RecipiesCount, o => o.MapFrom(src => src.Recipies.Count));

            CreateMap<TagsInRecipe, TagsInRecipeResponse>();

            CreateMap<Ingredient, IngredientResponse>()
                .ForMember(d => d.RecipiesCount, o => o.MapFrom(src => src.Recipies.Count));

            CreateMap<UpdateIngredientRequest, Ingredient>();
            CreateMap<CreateIngredientRequest, Ingredient>();

            CreateMap<Step, StepResponse>();
            CreateMap<UpdateStepRequest, Step>();
            CreateMap<CreateStepRequest, Step>();

            CreateMap<IngredientToRecipe, IngredientToRecipeResponse>();
            CreateMap<CreateIngredientToRecipeRequest, IngredientToRecipe>()
                   .ForMember(u => u.RecipeId, pt => pt.Ignore());

            CreateMap<UpdateRecipeRequest, Recipe>().
                 ForMember(d => d.Tags, pt => pt.Ignore()).
                 ForMember(d => d.UserId, pt => pt.MapFrom(x => x.GetUserId()));
            CreateMap<CreateRecipeRequest, Recipe>()
                 .ForMember(d => d.Tags, pt => pt.Ignore())
                 .ForMember(d => d.UserId, pt => pt.MapFrom(x => x.GetUserId()));
            CreateMap<Review, ReviewResponse>();
            CreateMap<UpdateReviewRequest, Review>().
                  ForMember(d => d.UserId, pt => pt.MapFrom(x => x.GetUserId()));

            CreateMap<CreateReviewRequest, Review>().
                 ForMember(d => d.UserId, pt => pt.MapFrom(x => x.GetUserId()));

            CreateMap<RateReview, RateReviewResponse>();
            CreateMap<UpdateRateReviewRequest, RateReview>().
              ForMember(d => d.UserId, pt => pt.MapFrom(x => x.GetUserId()));
            CreateMap<CreateRateReviewRequest, RateReview>()
                .ForMember(d => d.UserId, pt => pt.MapFrom(x => x.GetUserId()));
        }
    }
}