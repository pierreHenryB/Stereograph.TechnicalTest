using Microsoft.EntityFrameworkCore;
using Stereograph.TechnicalTest.Api.DataAccess;
using Stereograph.TechnicalTest.Api.Features;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Stereograph.TechnicalTest.Tests;

[Collection("Person service testing")]
public class PersonServiceTest
{
    private DbContextOptions<ApplicationDbContext> SetUpDbContextOptions()
    {
        return new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "testing_person").Options;
    }

    [Fact]
    public async Task ShouldGetPersons()
    {
        var expectedPersons = new List<Api.Entities.Person>
        {
            new Api.Entities.Person
            {
                FirstName = "firstname",
                LastName = "lastname",
                Address = "address",
                Email = "email",
                Reference = 123,
            }
        };

        using (var context = new ApplicationDbContext(SetUpDbContextOptions()))
        {
            context.Persons.AddRange(expectedPersons);
            context.SaveChanges();
        }
        
        using (var context = new ApplicationDbContext(SetUpDbContextOptions()))
        {
            var personService = new PersonService(context);

            var personsResult = await personService.GetAllPersonAsync();

            Assert.Equal(expectedPersons.Count, personsResult.Count);
            Assert.Equal(expectedPersons[0].FirstName, personsResult[0].FirstName);
            Assert.Equal(expectedPersons[0].LastName, personsResult[0].LastName);
            Assert.Equal(expectedPersons[0].Address, personsResult[0].Address);
            Assert.Equal(expectedPersons[0].Email, personsResult[0].Email);
            Assert.Equal(expectedPersons[0].Reference, personsResult[0].Reference);
        }
    }
    
    [Fact]
    public async Task ShouldGetOnePerson()
    {
        var expectedPerson = new Api.Entities.Person
        {
            FirstName = "firstname",
            LastName = "lastname",
            Address = "address",
            Email = "email",
            Reference = 123,
        };

        var firstNametoSearch = "firstname";
        var lastNametoSearch = "lastname";

        using (var context = new ApplicationDbContext(SetUpDbContextOptions()))
        {
            context.Persons.Add(expectedPerson);
            context.SaveChanges();
        }
        
        using (var context = new ApplicationDbContext(SetUpDbContextOptions()))
        {
            var personService = new PersonService(context);

            var personsResult = await personService.GetPersonAsync(firstNametoSearch, lastNametoSearch);

            Assert.Equal(expectedPerson.FirstName, personsResult.FirstName);
            Assert.Equal(expectedPerson.LastName, personsResult.LastName);
            Assert.Equal(expectedPerson.Address, personsResult.Address);
            Assert.Equal(expectedPerson.Email, personsResult.Email);
            Assert.Equal(expectedPerson.Reference, personsResult.Reference);
        }
    }
    
    [Fact]
    public async Task ShouldAddPerson()
    {
        var expectedPerson = new Api.Entities.Person
        {
            FirstName = "firstname",
            LastName = "lastname",
            Address = "address",
            Email = "email",
            Reference = 123,
        };

        using (var context = new ApplicationDbContext(SetUpDbContextOptions()))
        {
            var personService = new PersonService(context);

            var result = await personService.AddPersonAsync(expectedPerson);

            Assert.Equal(1, result);
        }
    }

    [Fact]
    public async Task ShouldUpdatePerson()
    {
        var actualPerson = new Api.Entities.Person
        {
            FirstName = "firstname",
            LastName = "lastname",
            Address = "address",
            Email = "email",
            Reference = 123,
        };

        var firstNametoSearch = "firstname";
        var lastNametoSearch = "lastname";

        var modifiedPerson = new Api.Entities.Person
        {
            FirstName = "firstnameModified",
            LastName = "lastnameModified",
            Address = "addressModified",
            Email = "emailModified",
            Reference = 123,
        };
        
        var expectedPerson = new Api.Entities.Person
        {
            FirstName = "firstnameModified",
            LastName = "lastnameModified",
            Address = "addressModified",
            Email = "emailModified",
            Reference = 123,
        };

        using (var context = new ApplicationDbContext(SetUpDbContextOptions()))
        {
            context.Persons.Add(actualPerson);
            context.SaveChanges();
        }

        using (var context = new ApplicationDbContext(SetUpDbContextOptions()))
        {
            var personService = new PersonService(context);

            var result = await personService.UpdatePersonAsync(modifiedPerson, firstNametoSearch, lastNametoSearch);
            Assert.Equal(1, result);

            var personResult = await context.Persons.FirstOrDefaultAsync();
            Assert.Equal(expectedPerson.FirstName, personResult.FirstName);
            Assert.Equal(expectedPerson.LastName, personResult.LastName);
            Assert.Equal(expectedPerson.Address, personResult.Address);
            Assert.Equal(expectedPerson.Email, personResult.Email);
            Assert.Equal(expectedPerson.Reference, personResult.Reference);
        }
    }
    
    [Fact]
    public async Task ShouldDeletePerson()
    {
        var actualPerson = new Api.Entities.Person
        {
            FirstName = "firstname",
            LastName = "lastname",
            Address = "address",
            Email = "email",
            Reference = 123,
        };

        var firstNametoSearch = "firstname";
        var lastNametoSearch = "lastname";

        using (var context = new ApplicationDbContext(SetUpDbContextOptions()))
        {
            context.Persons.Add(actualPerson);
            context.SaveChanges();
        }

        using (var context = new ApplicationDbContext(SetUpDbContextOptions()))
        {
            var personService = new PersonService(context);

            var result = await personService.DeletePersonAsync(firstNametoSearch, lastNametoSearch);
            Assert.Equal(1, result);

            var personResult = await context.Persons.FirstOrDefaultAsync();
            Assert.Null(personResult);
        }
    }
}
