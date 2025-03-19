using Pharmacy.Api.Entities;

const string GetPharmacyEndPointName = "GetPharmacy";

List<pharmacy> pharmacies = new()
    {

         new(){
      Id = 1,
         Name = "Pharmacy Ekounou",
         Image = "/images/pharm1.jpg",
         Contact = "222306778",
         Location = "Ekounou",
         Description = "Located at Carefour Ekounou"

         },
         new(){
        Id = 2,
        Name = "Pharmacy Tongolo",
        Image = "/images/pharm2.jpg",
        Contact = "671127349",
        Location = "Tongolo",
        Description = " Located at Tongolo"
        }

    };

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var group = app.MapGroup("/pharmacies");

group.MapGet("/", () => pharmacies);

group.MapGet("/{Id}", (int id) =>
 {

     pharmacy? pharmacie = pharmacies.Find(pharmacy => pharmacy.Id == id);
     if (pharmacie is null)
     {
         return Results.NotFound();
     }
     return Results.Ok(pharmacie);
 })
 .WithName(GetPharmacyEndPointName);
 group.MapPost("/", (pharmacy pharmacie) =>
 {
    pharmacie.Id = pharmacies.Max(pharmacie => pharmacie.Id) + 1;
    pharmacies.Add(pharmacie);

    return Results.CreatedAtRoute(GetPharmacyEndPointName, new {id = pharmacie.Id}, pharmacie);
 });
 group.MapPut("/{id}", (int id, pharmacy updatedPharmacy) => 
 {
    pharmacy? existingPharmacy = pharmacies.Find(pharmacy => pharmacy.Id == id);
     if (existingPharmacy is null)
     {
         return Results.NotFound();
     }
     existingPharmacy.Name = updatedPharmacy.Name;
     existingPharmacy.Image = updatedPharmacy.Image;
     existingPharmacy.Contact = updatedPharmacy.Contact;
     existingPharmacy.Location = updatedPharmacy.Location;
     existingPharmacy.Description = updatedPharmacy.Description;

     return Results.NoContent();

 });
 group.MapDelete("/{id}", (int id) =>
 {
     pharmacy? pharmacie = pharmacies.Find(pharmacy => pharmacy.Id == id);
     if (pharmacie is not null)
     {
         pharmacies.Remove(pharmacie);
     }
     return Results.NoContent();
 });

app.Run();
