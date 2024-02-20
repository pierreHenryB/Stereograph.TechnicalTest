namespace Stereograph.TechnicalTest.Api.Mapping;

using AutoMapper;

/// <summary>
/// Class define profile automapper
/// </summary>
public class PersonProfile : Profile
{
    /// <summary>
    /// Constructor by default
    /// </summary>
    public PersonProfile()
    {
        CreateMap<Contracts.Person, Entities.Person>()
            .ForMember(d => d.Id, s => s.Ignore())
            .ReverseMap();
    }
}
