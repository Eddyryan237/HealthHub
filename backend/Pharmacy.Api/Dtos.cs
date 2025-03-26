using System.ComponentModel.DataAnnotations;

namespace Gamestore.Api.Dtos;

public record PharmacyDto(
    int Id,
    string Name,    
    string Image,
    string Contact,
    string Location,
    string Description
);
public record CreatePharmacyDto(
    [Required] [StringLength(50)]string Name,    
   [Required] [StringLength(50)] string Image,
    [Required] [StringLength(20)]string Contact,
   [Required] [StringLength(50)] string Location,
    [Required] [StringLength(100)]string Description
);
public record UpdatePharmacyDto(

); 
