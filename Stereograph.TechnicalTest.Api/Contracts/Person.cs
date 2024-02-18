﻿namespace Stereograph.TechnicalTest.Api.Contracts;

/// <summary>
/// Contract of <see cref="Person"/>
/// </summary>
public class Person
{
    /// <summary>
    /// FirstName.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// LastName.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Email.
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// Address.
    /// </summary>
    public string? Address { get; set; }
}