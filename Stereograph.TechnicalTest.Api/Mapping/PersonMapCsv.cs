namespace Stereograph.TechnicalTest.Api.Mapping;

using CsvHelper.Configuration;

/// <summary>
/// Class that define the mapping of csv for <see cref="Entities.Person"/>
/// </summary>
public class PersonMapCsv : ClassMap<Entities.Person>
{
    /// <summary>
    /// Constructor by default
    /// </summary>
    public PersonMapCsv()
    {
        Map(m => m.FirstName).Name("first_name");
        Map(m => m.LastName).Name("last_name");
        Map(m => m.Email).Name("email");
        Map(m => m.Address).Name("address");
    }
}
