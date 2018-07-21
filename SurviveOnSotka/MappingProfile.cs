using AutoMapper;
using Microsoft.CodeAnalysis;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Categories;
using SurviveOnSotka.ViewModel.CheapPlaces;
using SurviveOnSotka.ViewModel.Cities;
using SurviveOnSotka.ViewModel.TypeFoods;

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

            CreateMap<CheapPlace, CheapPlaceResponse>();
            CreateMap<UpdateCheapPlaceRequest, CheapPlace>();
            CreateMap<CreateCheapPlaceRequest, CheapPlace>();

        }
    }
}

