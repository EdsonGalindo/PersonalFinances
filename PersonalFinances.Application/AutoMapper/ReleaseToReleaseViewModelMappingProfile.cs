using AutoMapper;
using PersonalFinances.Application.Queries.ViewModels;
using PersonalFinances.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalFinances.Application.AutoMapper
{
    public class ReleaseToReleaseViewModelMappingProfile : Profile
    {
        public ReleaseToReleaseViewModelMappingProfile()
        {
            CreateMap<Release, ReleaseViewModel>();
        }
    }
}
