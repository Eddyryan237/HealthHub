using System;
using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Api.Data;

public class PharmacyContext(DbContextOptions<PharmacyContext> options) : DbContext
{

}
