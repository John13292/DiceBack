using AutoMapper;
using DiceBack.Contracts.Models;
using DiceBack.Entities;

namespace DiceBack.Application.Mapping
{
    public class EffectDtoMappingEffect : Profile
    {
        public EffectDtoMappingEffect()
        {
            CreateMap<EffectDto, Effect>().ReverseMap();
        }
    }
}
