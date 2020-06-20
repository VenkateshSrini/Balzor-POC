using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlazorCRUD.Shared.Model;

namespace BlazorCRUD.Server.DomainModel.Mappers
{
    public class ReceipeModelProfile:Profile
    {
        public ReceipeModelProfile()
        {
            CreateMap<ReceipeModel, Receipe>()
                .ForMember(dest => dest.ReceipeID, options =>
                  options.MapFrom(src => src.ReceipeID))
                .ForMember(dest => dest.ReceipeName, options =>
                  options.MapFrom(src => src.ReceipeName))
                .ForMember(dest => dest.Notes, options =>
                  options.MapFrom(src => src.Notes))
                .ForMember(dest => dest.Ingredients, options =>
                  options.MapFrom(src => src.Ingredients))
                .ReverseMap();
        }

    }
}
