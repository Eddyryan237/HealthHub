using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Api.Dtos;

public record class CreatePharmacyDto(
    [Required] [StringLength(50)]string Name,    
   [Required] [StringLength(50)] string Image,
    [Required] [StringLength(20)]string Contact,
   [Required] [StringLength(50)] string Location,
    [Required] [StringLength(100)]string Description
);

