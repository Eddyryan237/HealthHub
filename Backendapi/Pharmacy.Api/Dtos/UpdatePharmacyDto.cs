namespace Pharmacy.Api.Dtos;

public record class UpdatePharmacyDto(
    string Name,    
    string Image,
    string Contact,
    string Location,
    string Description
);

