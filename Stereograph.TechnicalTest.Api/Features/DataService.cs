namespace Stereograph.TechnicalTest.Api.Features;

using CsvHelper;
using Stereograph.TechnicalTest.Api.DataAccess;
using Stereograph.TechnicalTest.Api.Mapping;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

/// <summary>
/// Class of service for manage data in db
/// </summary>
public class DataService : IDataService
{
    /// <summary>
    /// Db context <see cref="ApplicationDbContext"/>
    /// </summary>
    private ApplicationDbContext _dbContext;

    /// <summary>
    /// Constructor of <see cref="DataService"/>
    /// </summary>
    /// <param name="dbContext"><see cref="ApplicationDbContext"/></param>
    public DataService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc/>
    public void InitializeDb(string pathCsv, string fileNameCsv)
    {
        var persons = RetrieveCsvData(pathCsv, fileNameCsv);
        _dbContext.AddRange(persons);
        _dbContext.SaveChanges();
    }

    /// <inheritdoc/>
    public void DropData()
    {
        _dbContext.RemoveRange(_dbContext.Persons);
        _dbContext.SaveChanges();
    }

    /// <summary>
    /// Retrieve list of <see cref="Entities.Person"/> from a csv
    /// </summary>
    /// <param name="pathCsv">Path of csv</param>
    /// <param name="fileNameCsv">File name of csv</param>
    /// <returns>List of <see cref="Entities.Person"/></returns>
    private static List<Entities.Person> RetrieveCsvData(string pathCsv, string fileNameCsv)
    {
        var path = Path.Combine(pathCsv, fileNameCsv);
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<PersonMapCsv>();
        var records = csv.GetRecords<Entities.Person>().ToList();
        return records;
    }
}