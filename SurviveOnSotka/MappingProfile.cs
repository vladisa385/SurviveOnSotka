using AutoMapper;
using Microsoft.CodeAnalysis;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Categories;

namespace SurviveOnSotka
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Project mapping to and from
            CreateMap<Category, CategoryResponse>()
                .ForMember(d => d.RecipiesCount, o => o.MapFrom(src => src.Recipies.Count))
                .ForMember(d => d.ParentCategory, o => o.MapFrom(u => u.ParentCategory.Id))
                ;
            CreateMap<UpdateCategoryRequest, Category>();
            CreateMap<CreateCategoryRequest, Category>();

            //Project mapping to and from
            //Task mapping to and from

        }
    }
}

