namespace Stereograph.TechnicalTest.Api.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stereograph.TechnicalTest.Api.Features;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Controller ...
/// </summary>
[Route("api/persons")]
[ApiController]
public class PersonController : ControllerBase
{
    /// <summary>
    /// Logger of <see cref="PersonController"/>.
    /// </summary>
    private readonly ILogger<PersonController> _logger;
    
    /// <summary>
    /// Mapper.
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Instance of <see cref="IPersonService"/>
    /// </summary>
    private readonly IPersonService _personService;

    /// <summary>
    /// Constructor of <see cref="PersonController"/>.
    /// </summary>
    /// <param name="personService">Instance of <see cref="IPersonService"/>.</param>
    /// <param name="mapper">Mapper.</param>
    /// <param name="logger">Logger.</param>
    public PersonController(IPersonService personService, IMapper mapper, ILogger<PersonController> logger)
    {
        _logger = logger;
        _personService = personService;
        _mapper = mapper;
    }

    /// <summary>
    /// GET that retrieve a list of <see cref="Contracts.Person"/>.
    /// </summary>
    /// <returns>List of <see cref="Contracts.Person"/>.</returns>
    [HttpGet]
    public async Task<IActionResult> GetPersonsAsync()
    {
        var connectedPersons = await _personService.GetAllPersonAsync();
        var contractPersons = _mapper.Map<List<Contracts.Person>>(connectedPersons);
        return Ok(contractPersons);
    }

    /// <summary>
    /// GET that retrieve one <see cref="Contracts.Person"/> by its first name and last name.
    /// </summary>
    /// <param name="firstname">First name.</param>
    /// <param name="lastname">Last name.</param>
    /// <returns>Contract of <see cref="Contracts.Person"/>.</returns>
    [HttpGet("byFirstAndLastName")]
    public async Task<IActionResult> GetPersonByNameAsync(string firstname, string lastname)
    {
        var connectedPerson = await _personService.GetPersonAsync(firstname, lastname);
        if (connectedPerson == null)
        {
            return NotFound();
        }

        var contractPerson = _mapper.Map<Contracts.Person>(connectedPerson);
        return Ok(contractPerson);
    }
    
    /// <summary>
    /// POST that add a <see cref="Contracts.Person"/>.
    /// </summary>
    /// <param name="person">Contract of <see cref="Contracts.Person"/></param>
    /// <returns>Contract of <see cref="Contracts.Person"/></returns>
    [HttpPost()]
    public async Task<IActionResult> AddPersonAsync(Contracts.Person person)
    {
        if (person == null)
        {
            return BadRequest();
        }

        var personDisconnected = _mapper.Map<Entities.Person>(person);
        var success = await _personService.AddPersonAsync(personDisconnected);
        if (success != 1)
        {
            return BadRequest();
        }

        var personAdded = _mapper.Map<Contracts.Person>(personDisconnected);
        return Ok(personAdded);
    }

    /// <summary>
    /// PUT that update a <see cref="Contracts.Person"/>
    /// </summary>
    /// <param name="person">Contract of <see cref="Contracts.Person"/>.</param>
    /// <returns>Contract of <see cref="Contracts.Person"/>.</returns>
    [HttpPut()]
    public async Task<IActionResult> UpdatePersonAsync(Contracts.Person person, string firstName, string lastName)
    {
        if (person == null)
        {
            return BadRequest();
        }

        var personDisconnected = _mapper.Map<Entities.Person>(person);
        var success = await _personService.UpdatePersonAsync(personDisconnected, firstName, lastName);
        if (success != 1)
        {
            return BadRequest();
        }

        var personUpdated = _mapper.Map<Contracts.Person>(personDisconnected);
        return Ok(personUpdated);
    }

    /// <summary>
    /// DELETE that delete a <see cref="Contracts.Person"/>.
    /// </summary>
    /// <param name="person">Contract of <see cref="Contracts.Person"/>.</param>
    /// <returns></returns>
    [HttpDelete()]
    public async Task<IActionResult> DeletePersonAsync(string firstName, string lastName)
    {
        var success = await _personService.DeletePersonAsync(firstName, lastName);
        if (success != 1)
        {
            return BadRequest();
        }

        return Ok();
    }
}
