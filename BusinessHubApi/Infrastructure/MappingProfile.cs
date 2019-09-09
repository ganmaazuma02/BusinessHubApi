using AutoMapper;
using BusinessHubApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessHubApi.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BusinessEntity, Business>()
                 .ForMember(dest => dest.Self, opt => opt.MapFrom(src =>
                     Link.To(
                         nameof(Controllers.BusinessesController.GetBusinessById),
                         new { businessId = src.Id })));
        }
    }
}
