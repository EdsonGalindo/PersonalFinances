using AutoMapper;
using PersonalFinances.Application.Queries.ViewModels;
using PersonalFinances.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalFinances.Application.AutoMapper
{
    public class ReleaseViewModelToReleaseMappingProfile : Profile
    {
        public ReleaseViewModelToReleaseMappingProfile()
        {
            CreateMap<ReleaseViewModel, Release>();
                //.ConstructUsing(r =>
                   // new Release() { Account = r.Account, Date = r.Date, Description = r.Description, Id = r.Id, Type = r.Type, Value = r.Value });
        }
    }
}
