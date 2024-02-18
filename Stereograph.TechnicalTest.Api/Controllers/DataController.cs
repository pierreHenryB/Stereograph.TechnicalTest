namespace Stereograph.TechnicalTest.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stereograph.TechnicalTest.Api.Features;

/// <summary>
/// Controller for data manipulation
/// </summary>
[Route("api/data")]
[ApiController]
public class DataController : ControllerBase
{
    /// <summary>
    /// Logger.
    /// </summary>
    private readonly ILogger<DataController> _logger;
    
    /// <summary>
    /// Data service
    /// </summary>
    private readonly IDataService _dataService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="dataService"><see cref="IDataService"/></param>
    /// <param name="logger">logger of <see cref="DataController"/></param>
    public DataController(IDataService dataService, ILogger<DataController> logger)
    {
        _logger = logger;
        _dataService = dataService;
    }

    /// <summary>
    /// POST that init data from csv file into the db
    /// </summary>
    /// <returns></returns>
    [HttpPost("initData")]
    public ActionResult InitializeDb()
    {
        var pathCsv = "./Ressources";
        var fileNameCsv = "Persons.csv";
        _dataService.InitializeDb(pathCsv, fileNameCsv);
        return Ok();
    }

    /// <summary>
    /// POST that truncate data in db
    /// </summary>
    /// <returns></returns>
    [HttpPost("dropData")]
    public ActionResult DropDb()
    {
        _dataService.DropData();
        return Ok();
    }
}
