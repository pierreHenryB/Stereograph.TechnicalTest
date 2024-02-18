namespace Stereograph.TechnicalTest.Api.Features;

using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Interface of <see cref="IPersonService"/>
/// </summary>
public interface IPersonService
{
    /// <summary>
    /// Retrieve a list of all <see cref="Entities.Person"/>.
    /// </summary>
    /// <returns>list of <see cref="Entities.Person"/>.</returns>
    Task<IList<Entities.Person>> GetAllPersonAsync();

    /// <summary>
    /// Retrieve one <see cref="Entities.Person"/> by his name
    /// </summary>
    /// <param name="firstName">First name</param>
    /// <param name="lastName">Last name</param>
    /// <returns>entity of <see cref="Entities.Person"/></returns>
    Task<Entities.Person?> GetPersonAsync(string firstName, string lastName);

    /// <summary>
    /// Add a <see cref="Entities.Person"/>
    /// </summary>
    /// <param name="person"><see cref="Entities.Person"/></param>
    /// <returns></returns>
    Task<int> AddPersonAsync(Entities.Person person);

    /// <summary>
    /// Update a <see cref="Entities.Person"/>
    /// </summary>
    /// <param name="person"><see cref="Entities.Person"/></param>
    /// <returns></returns>
    Task<int> UpdatePersonAsync(Entities.Person person);
}
