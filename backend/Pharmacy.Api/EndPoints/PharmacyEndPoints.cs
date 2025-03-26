using System;
using Pharmacy.Api.Dtos;

namespace Pharmacy.Api.EndPoints;

public static class PharmacyEndPoints
{
    const string GetPharmacyEndPointName = "GetPharmacy";

    private static readonly List<PharmacyDto> pharmacies = [
         new(
          1,
          "Pharmacy Ekounou",
          "/images/pharm1.jpg",
          "222306778",
          "Ekounou",
          "Located at Carefour Ekounou"

     ),
     new(
         2,
         "Pharmacy Tongolo",
         "/images/pharm2.jpg",
         "671127349",
         "Tongolo",
         " Located at Tongolo"
     )
    ];
    public static RouteGroupBuilder MapPharmacyEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("pharmacies")
                       .WithParameterValidation();
        group.MapGet("/", () => pharmacies);

        group.MapGet("/{id})", (int id) =>
          {
              PharmacyDto? pharmacy = pharmacies.Find(pharmacy => pharmacy.Id == id);
              return pharmacy is null ? Results.NotFound() : Results.Ok(pharmacy);
          })
           .WithName(GetPharmacyEndPointName);

        //POST
       group.MapPost("/", (CreatePharmacyDto newPharmacy) =>
        {
    
            PharmacyDto pharmacy = new(
         pharmacies.Count + 1,
         newPharmacy.Name,
         newPharmacy.Image,
         newPharmacy.Contact,
         newPharmacy.Location,
         newPharmacy.Description
    );
            pharmacies.Add(pharmacy);
            return Results.CreatedAtRoute("GetPharmacy", new { id = pharmacy.Id }, pharmacy);
        })
        .WithParameterValidation();
        group.MapPut("/{id}", (int id, UpdatePharmacyDto updatedPharmacy) =>
        {
            var index = pharmacies.FindIndex(pharmacy => pharmacy.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }


            pharmacies[index] = new PharmacyDto(
         id,
         updatedPharmacy.Name,
         updatedPharmacy.Image,
         updatedPharmacy.Contact,
         updatedPharmacy.Location,
         updatedPharmacy.Description
    );

            return Results.NoContent();
        });
        group.MapDelete("/{id}", (int id) =>
        {
            pharmacies.RemoveAll(pharmacy => pharmacy.Id == id);
            return Results.NoContent();
        });
        return group;
    }
    



}
