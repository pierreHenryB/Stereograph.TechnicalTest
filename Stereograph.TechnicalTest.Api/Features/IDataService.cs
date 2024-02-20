namespace Stereograph.TechnicalTest.Api.Features;

/// <summary>
/// Interface de <see cref="IDataService"/>
/// </summary>
public interface IDataService
{
    /// <summary>
    /// Initialize data base with csv
    /// </summary>
    /// <param name="pathCsv">Path of csv file</param>
    /// <param name="fileNameCsv">Filenameof csv file</param>
    void InitializeDb(string pathCsv, string fileNameCsv);

    /// <summary>
    /// Truncate data in database
    /// </summary>
    void DropData();
}
