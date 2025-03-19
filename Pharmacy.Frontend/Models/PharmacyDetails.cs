using System;
using System.ComponentModel.DataAnnotations;


namespace Pharmacy.Frontend.Models;


public class PharmacyDetails
{
    public int Id{get; set;}
    [Required]
    public required string Image{get; set;}
    [Required]
    
    public required string Name{get; set;}
    [Range (7, 12)]


    public string? Contact{get; set;}
    [Required]

    
    public required string Location{get; set;}
    [Required]
    public required string Description{get; set;} 





}
