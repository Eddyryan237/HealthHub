using System;
using Pharmacy.Frontend.Models;

namespace Pharmacy.Frontend.Clients;

public class PharmacyClients
{
    private List<PharmacySummary> pharmacies =
    [

         new(){
  Id = 1,
Image = "/images/pharm1.jpg",
Name = "Pharmacy Ekounou",
Contact = "222306778",
Location = "Ekounou",
Description = "Located at Carefour Ekounou"

},
new(){
    Id = 2,
Image = "/images/pharm2.jpg",
Name = "Pharmacy Tongolo",
Contact = "671127349",
Location = "Tongolo",
Description = " Located at Tongolo"}

    ];
    public PharmacySummary[] Getpharmacies() => pharmacies.ToArray();
    public void AddPharmacy(PharmacyDetails pharmacy)
    {
        var pharmacySummary = new PharmacySummary
        {
            Id = pharmacy.Id,
            Image = pharmacy.Image,
            Name = pharmacy.Name,
            Contact = pharmacy.Contact,
            Location = pharmacy.Location,
            Description = pharmacy.Description
        };
        pharmacies.Add(pharmacySummary);

    }
    public required PharmacySummary selectedPharmacy{get; set;} 
    public void SelectPharmacy(PharmacySummary pharmacy){
        selectedPharmacy = pharmacy;
    }


}



