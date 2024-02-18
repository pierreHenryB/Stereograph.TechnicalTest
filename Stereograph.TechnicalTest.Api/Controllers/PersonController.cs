namespace Stereograph.TechnicalTest.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/persons")]
[ApiController]
public class PersonController : ControllerBase
{

    public PersonController()
    {
    }

    [HttpGet]
    public async Task<ActionResult<IList<Contracts.Person>>> GetPersonsAsync()
    {
        throw new NotImplementedException();
    }

    [HttpPost()]
    public async Task<ActionResult<Contracts.Person>> AddPersonAsync(Contracts.Person person)
    {
        throw new NotImplementedException();
    }

    [HttpPut()]
    public async Task<ActionResult<Contracts.Person>> UpdatePersonAsync(Contracts.Person person)
    {
        throw new NotImplementedException();
    }

    [HttpDelete()]
    public async Task<ActionResult<int>> DeletePersonAsync(Contracts.Person person)
    {
        throw new NotImplementedException();
    }
}
