namespace Stereograph.TechnicalTest.Api.Features;

using Microsoft.EntityFrameworkCore;
using Stereograph.TechnicalTest.Api.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Class of services for <see cref="Entities.Person"/>
/// </summary>
public class PersonService : IPersonService
{
    /// <summary>
    /// Db context
    /// </summary>
    private readonly ApplicationDbContext _dbContext;

    /// <summary>
    /// Constructor of <see cref="PersonService"/>
    /// </summary>
    /// <param name="dbContext"><see cref="ApplicationDbContext"/></param>
    public PersonService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc/>
    public async Task<IList<Entities.Person>> GetAllPersonAsync()
    {
        return await _dbContext.Persons.ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<Entities.Person?> GetPersonAsync(string? firstName, string? lastName)
    {
        if (firstName == null || lastName == null)
        {
            return null;
        }
        return await _dbContext.Persons.FirstOrDefaultAsync(x => x.FirstName == firstName && x.LastName == lastName);
    }

    /// <inheritdoc/>
    public async Task<int> AddPersonAsync(Entities.Person person)
    {
        _dbContext.Persons.Add(person);
        return await _dbContext.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task<int> UpdatePersonAsync(Entities.Person personDisconnected)
    {
        var personConnected = await GetPersonAsync(personDisconnected.FirstName, personDisconnected.LastName);
        if (personConnected == null)
        {
            return await _dbContext.SaveChangesAsync();
        }
        MapPerson(personDisconnected, personConnected);
        _dbContext.Persons.Update(personConnected);
        return await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Map values of disconnected and connected <see cref="Entities.Person"/>
    /// </summary>
    /// <param name="personDisconnected">Disconnected <see cref="Entities.Person"/></param>
    /// <param name="personConnected">Connected <see cref="Entities.Person"/></param>
    private static void MapPerson(Entities.Person personDisconnected, Entities.Person personConnected)
    {
        personConnected.FirstName = personDisconnected.FirstName;
        personConnected.LastName = personDisconnected.LastName;
        personConnected.Address = personDisconnected.Address;
        personConnected.Email = personDisconnected.Email;
    }
}