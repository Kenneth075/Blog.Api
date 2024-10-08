﻿using Application.Features;
using Application.Features.Authors.Commands.CreateAuthor;
using Application.Features.Blogs.Commands.CreateBlog;
using Application.Features.Blogs.Commands.UpdateBlog;
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
            CreateMap<Blog, CreateBlogRequestDto>().ReverseMap();
            CreateMap<Blog, CreateBlogResponse>().ReverseMap();
            CreateMap<Blog, UpdateBlogRequestDto>().ReverseMap();
            CreateMap<Blog, UpdateBlogResponse>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, CreateAuthorRequestDto>().ReverseMap();
        }

    }
}
