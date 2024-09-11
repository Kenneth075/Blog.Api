using Application.Features;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Blog, BlogDto>().ReverseMap();
            //CreateMap<Blog, BlogDto>().ForMember(x =>x.Description, opt => opt.MapFrom(y => y.Name));
        }

    }
}
