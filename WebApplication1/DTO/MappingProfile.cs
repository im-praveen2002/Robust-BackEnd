using AutoMapper;
namespace WebApplication1.DTO
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {

            CreateMap<Category, CreateCategoryDTO > ().ReverseMap();
        }
    }
}
