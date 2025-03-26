using System;

namespace Pharmacy.Api.Entities;

public class Pharmacy
{
   public int Id {get; set;}
    public required string Name {get; set;}
    public required string Image {get; set;}
    public required string Contact {get; set;}
    public required string Location {get; set;}
    public required string Description {get; set;}

}
