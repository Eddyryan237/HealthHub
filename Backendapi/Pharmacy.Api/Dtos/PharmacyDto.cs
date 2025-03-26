namespace Pharmacy.Api.Dtos;

public record class PharmacyDto(
    int Id,
    string Name,    
    string Image,
    string Contact,
    string Location,
    string Description
);

