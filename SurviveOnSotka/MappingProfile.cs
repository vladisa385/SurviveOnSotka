﻿using System.Linq;
using AutoMapper;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Categories;
using SurviveOnSotka.ViewModel.CheapPlaces;
using SurviveOnSotka.ViewModel.Cities;
using SurviveOnSotka.ViewModel.Ingredients;
using SurviveOnSotka.ViewModel.Levels;
using SurviveOnSotka.ViewModel.RateCheapPlaces;
using SurviveOnSotka.ViewModel.RateReviews;
using SurviveOnSotka.ViewModel.Recipies;
using SurviveOnSotka.ViewModel.Reviews;
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
                .ForMember(d => d.RateCheapPlacesCount, o => o.MapFrom(src => src.RateCheapPlaces.Count));
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();

            CreateMap<Ingredient, IngredientResponse>()
                .ForMember(d => d.RecipiesCount, o => o.MapFrom(src => src.Recipies.Count));

            CreateMap<UpdateIngredientRequest, Ingredient>();
            CreateMap<CreateIngredientRequest, Ingredient>();


            CreateMap<Level, LevelResponse>();
            CreateMap<UpdateLevelRequest, Level>();
            CreateMap<CreateLevelRequest, Level>();

            CreateMap<Recipe, RecipeResponse>().
            ForMember(d => d.User, o => o.MapFrom(src => Mapper.Map<User, UserResponse>(src.User)));

            CreateMap<UpdateRecipeRequest, Recipe>();
            CreateMap<CreateRecipeRequest, Recipe>();

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

