using AutoMapper;
using DiceBack.Contracts.Models;
using DiceBack.Entities;

namespace DiceBack.Application.Mapping;

public class ImageDtoMappingImage : Profile
{
    public ImageDtoMappingImage()
    {
        CreateMap<ImageDto, Image>().ReverseMap();
    }
}