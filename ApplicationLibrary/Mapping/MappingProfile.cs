using ApplicationLibrary.Model;
using AutoMapper;
using Entity.Country;
using Entity.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLibrary
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CountryDetail, CountryModel>(MemberList.None).ReverseMap();
            CreateMap<StateDetail, StateModel>(MemberList.None).ReverseMap();

            //  CreateMap<Entity.Country.CountryDetail, CountryModel>()
            //.ForMember(dest => dest.Name, o => o.MapFrom(src => src.Name))
            //.ForMember(dest => dest.IsOke, o => o.MapFrom(src => src.Name));
            // //.ReverseMap();
        }
    }
}
