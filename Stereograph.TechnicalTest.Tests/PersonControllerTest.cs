namespace Stereograph.TechnicalTest.Tests;

using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Stereograph.TechnicalTest.Api.Controllers;
using Stereograph.TechnicalTest.Api.Features;
using Stereograph.TechnicalTest.Api.Mapping;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

public class PersonControllerTest
{
    private readonly Mapper _mapper;

    public PersonControllerTest()
    {
        var mapperConfiguration = new MapperConfiguration(mc => mc.AddProfile(new PersonProfile())).CreateMapper().ConfigurationProvider;
        _mapper = new Mapper(mapperConfiguration);
    }

    [Fact]
    public async Task ShouldReturnAllPersons()
    {
        var expectedPersons = new List<Api.Contracts.Person>
        {
            new Api.Contracts.Person
            {
                FirstName = "firstname",
                LastName = "lastname",
                Address = "address",
                Email = "email",
                Reference = 123
            },
            new Api.Contracts.Person
            {
                FirstName = "firstname2",
                LastName = "lastname2",
                Address = "address2",
                Email = "email2",
                Reference = 123123
            }
        };
        var mockedPersons = new List<Api.Entities.Person>
        {
            new Api.Entities.Person
            {
                FirstName = "firstname",
                LastName = "lastname",
                Address = "address",
                Email = "email",
                Reference = 123,
            },
            new Api.Entities.Person
            {
                FirstName = "firstname2",
                LastName = "lastname2",
                Address = "address2",
                Email = "email2",
                Reference = 123123,
            }
        };

        var mockPersonService = new Mock<IPersonService>();
        mockPersonService.Setup(s => s.GetAllPersonAsync()).ReturnsAsync(mockedPersons);
        var mockLogger = new Mock<ILogger<PersonController>>();

        var personController = new PersonController(mockPersonService.Object, _mapper, mockLogger.Object);

        var result = await personController.GetPersonsAsync();
        var objectResult = result as OkObjectResult;
        
        Assert.NotNull(result);
        Assert.IsType<List<Api.Contracts.Person>>(objectResult.Value);
        
        var personsResult = objectResult.Value as List<Api.Contracts.Person>;
        
        Assert.Equal(expectedPersons.Count, personsResult.Count);
        Assert.Equal(expectedPersons[0].FirstName, personsResult[0].FirstName);
        Assert.Equal(expectedPersons[0].LastName, personsResult[0].LastName);
        Assert.Equal(expectedPersons[0].Address, personsResult[0].Address);
        Assert.Equal(expectedPersons[0].Email, personsResult[0].Email);
        Assert.Equal(expectedPersons[0].Reference, personsResult[0].Reference);
        Assert.Equal(expectedPersons[1].FirstName, personsResult[1].FirstName);
        Assert.Equal(expectedPersons[1].LastName, personsResult[1].LastName);
        Assert.Equal(expectedPersons[1].Address, personsResult[1].Address);
        Assert.Equal(expectedPersons[1].Email, personsResult[1].Email);
        Assert.Equal(expectedPersons[1].Reference, personsResult[1].Reference);
    }
    
    [Fact]
    public async Task ShouldReturnOnePerson()
    {
        var firstNametoSearch = "firstname";
        var lastNametoSearch = "lastname";
        var expectedPerson = new Api.Contracts.Person
        {
            FirstName = "firstname",
            LastName = "lastname",
            Address = "address",
            Email = "email",
            Reference = 123,
        };

        var mockedPerson = new Api.Entities.Person
        {
            FirstName = "firstname",
            LastName = "lastname",
            Address = "address",
            Email = "email",
            Reference = 123,
        };

        var mockPersonService = new Mock<IPersonService>();
        mockPersonService.Setup(s => s.GetPersonAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(mockedPerson);
        var mockLogger = new Mock<ILogger<PersonController>>();

        var personController = new PersonController(mockPersonService.Object, _mapper, mockLogger.Object);

        var result = await personController.GetPersonByNameAsync(firstNametoSearch, lastNametoSearch);
        var objectResult = result as OkObjectResult;
        
        Assert.NotNull(result);
        Assert.IsType<Api.Contracts.Person>(objectResult.Value);
        
        var personResult = objectResult.Value as Api.Contracts.Person;
        
        Assert.Equal(expectedPerson.FirstName, personResult.FirstName);
        Assert.Equal(expectedPerson.LastName, personResult.LastName);
        Assert.Equal(expectedPerson.Address, personResult.Address);
        Assert.Equal(expectedPerson.Email, personResult.Email);
        Assert.Equal(expectedPerson.Reference, personResult.Reference);
    }

    [Fact]
    public async Task ShouldAddPerson()
    {
        var expectedPerson = new Api.Contracts.Person
        {
            FirstName = "firstname",
            LastName = "lastname",
            Address = "address",
            Email = "email",
            Reference = 123,
        };

        var person = new Api.Contracts.Person
        {
            FirstName = "firstname",
            LastName = "lastname",
            Address = "address",
            Email = "email",
            Reference = 123,
        };

        var mockPersonService = new Mock<IPersonService>();
        mockPersonService.Setup(s => s.AddPersonAsync(It.IsAny<Api.Entities.Person>())).ReturnsAsync(1);
        var mockLogger = new Mock<ILogger<PersonController>>();

        var personController = new PersonController(mockPersonService.Object, _mapper, mockLogger.Object);

        var result = await personController.AddPersonAsync(person);
        var objectResult = result as OkObjectResult;
        
        Assert.NotNull(result);
        Assert.IsType<Api.Contracts.Person>(objectResult.Value);
        
        var personsResult = objectResult.Value as Api.Contracts.Person;

        Assert.Equal(expectedPerson.FirstName, personsResult.FirstName);
        Assert.Equal(expectedPerson.LastName, personsResult.LastName);
        Assert.Equal(expectedPerson.Address, personsResult.Address);
        Assert.Equal(expectedPerson.Email, personsResult.Email);
        Assert.Equal(expectedPerson.Reference, personsResult.Reference);
    }
    
    [Fact]
    public async Task ShouldNotAddPerson()
    {
        var expectedPerson = new Api.Contracts.Person
        {
            FirstName = "firstname",
            LastName = "lastname",
            Address = "address",
            Email = "email",
            Reference = 123,
        };

        var person = new Api.Contracts.Person
        {
            FirstName = "firstname",
            LastName = "lastname",
            Address = "address",
            Email = "email",
            Reference = 123,
        };

        var mockPersonService = new Mock<IPersonService>();
        mockPersonService.Setup(s => s.AddPersonAsync(It.IsAny<Api.Entities.Person>())).ReturnsAsync(0);
        var mockLogger = new Mock<ILogger<PersonController>>();

        var personController = new PersonController(mockPersonService.Object, _mapper, mockLogger.Object);

        var result = await personController.AddPersonAsync(person);
        Assert.NotNull(result);

        var objectResult = result as BadRequestResult;
        Assert.Equal((int)HttpStatusCode.BadRequest, objectResult.StatusCode);
    }

    [Fact]
    public async Task ShouldUpdateOnePerson()
    {
        var expectedPerson = new Api.Contracts.Person
        {
            FirstName = "firstnameModified",
            LastName = "lastnameModified",
            Address = "addressModified",
            Email = "emailModified",
            Reference = 123,
        };

        var actualPerson = new Api.Contracts.Person
        {
            FirstName = "firstnameModified",
            LastName = "lastnameModified",
            Address = "addressModified",
            Email = "emailModified",
            Reference = 123,
        };

        var mockPersonService = new Mock<IPersonService>();
        mockPersonService.Setup(s => s.UpdatePersonAsync(It.IsAny<Api.Entities.Person>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(1);
        var mockLogger = new Mock<ILogger<PersonController>>();

        var personController = new PersonController(mockPersonService.Object, _mapper, mockLogger.Object);

        var result = await personController.UpdatePersonAsync(actualPerson, actualPerson.FirstName, actualPerson.LastName);
        var objectResult = result as OkObjectResult;
        
        Assert.NotNull(result);
        Assert.IsType<Api.Contracts.Person>(objectResult.Value);
        
        var personsResult = objectResult.Value as Api.Contracts.Person;

        Assert.Equal(expectedPerson.FirstName, personsResult.FirstName);
        Assert.Equal(expectedPerson.LastName, personsResult.LastName);
        Assert.Equal(expectedPerson.Address, personsResult.Address);
        Assert.Equal(expectedPerson.Email, personsResult.Email);
        Assert.Equal(expectedPerson.Reference, personsResult.Reference);
    }
    
    [Fact]
    public async Task ShouldNotUpdateOnePerson()
    {
        var actualperson = new Api.Contracts.Person
        {
            FirstName = "firstnameModified",
            LastName = "lastnameModified",
            Address = "addressModified",
            Email = "emailModified",
            Reference = 123,
        };

        var mockPersonService = new Mock<IPersonService>();
        mockPersonService.Setup(s => s.UpdatePersonAsync(It.IsAny<Api.Entities.Person>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(0);
        var mockLogger = new Mock<ILogger<PersonController>>();

        var personController = new PersonController(mockPersonService.Object, _mapper, mockLogger.Object);

        var result = await personController.UpdatePersonAsync(actualperson, actualperson.FirstName, actualperson.LastName);
        Assert.NotNull(result);

        var objectResult = result as BadRequestResult;
        Assert.Equal((int)HttpStatusCode.BadRequest, objectResult.StatusCode);
    }
    
    [Fact]
    public async Task ShouldDeleteOnePerson()
    {
        var actualperson = new Api.Contracts.Person
        {
            FirstName = "firstname",
            LastName = "lastname",
            Address = "address",
            Email = "email",
            Reference = 123,
        };

        var mockPersonService = new Mock<IPersonService>();
        mockPersonService.Setup(s => s.DeletePersonAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(1);
        var mockLogger = new Mock<ILogger<PersonController>>();

        var personController = new PersonController(mockPersonService.Object, _mapper, mockLogger.Object);

        var result = await personController.DeletePersonAsync(actualperson.FirstName, actualperson.LastName);
        Assert.NotNull(result);

        var objectResult = result as OkResult;
        Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
    }
    
    [Fact]
    public async Task ShouldNotDeleteOnePerson()
    {
        var actualperson = new Api.Contracts.Person
        {
            FirstName = "firstname",
            LastName = "lastname",
            Address = "address",
            Email = "email",
            Reference = 123,
        };

        var mockPersonService = new Mock<IPersonService>();
        mockPersonService.Setup(s => s.DeletePersonAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(0);
        var mockLogger = new Mock<ILogger<PersonController>>();

        var personController = new PersonController(mockPersonService.Object, _mapper, mockLogger.Object);

        var result = await personController.DeletePersonAsync(actualperson.FirstName, actualperson.LastName);
        Assert.NotNull(result);

        var objectResult = result as BadRequestResult;
        Assert.Equal((int)HttpStatusCode.BadRequest, objectResult.StatusCode);
    }
}