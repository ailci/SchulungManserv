using AutoMapper;
using Domain.Entities;
using Shared.DataTransferObjects;

namespace Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Quote, QuoteOfTheDayDto>();
        CreateMap<Author, AuthorDto>();
        CreateMap<QuoteForCreateDto, Quote>();

        //TODO: Anpassung Mapping
        CreateMap<AuthorForCreateDto, Author>();
    }
}