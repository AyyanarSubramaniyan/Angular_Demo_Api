using ApplicationLibrary.Model;
using AutoMapper;
using Entity;
using SampleProject.Application.Model;

namespace ApplicationLibrary
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryMasterModel>(MemberList.None).ReverseMap();
            CreateMap<Country, CountryReadModel>(MemberList.None).ReverseMap();            
            CreateMap<State, StateMasterModel>(MemberList.None).ReverseMap();
            CreateMap<State, StateReadModel>(MemberList.None).ReverseMap();

            //CreateMap<State, StateReadModel>()
            //.ForMember(dest => dest.CountryName, o => o.MapFrom(src => src.Country.Name));
            //.ReverseMap();

            //  CreateMap<Entity.Country.CountryDetail, CountryModel>()
            //.ForMember(dest => dest.Name, o => o.MapFrom(src => src.Name))
            //.ForMember(dest => dest.IsOke, o => o.MapFrom(src => src.Name));
            // //.ReverseMap();
        }
    }
}
