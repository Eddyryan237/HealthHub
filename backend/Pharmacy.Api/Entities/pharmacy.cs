using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Api.Entities;
public class pharmacy
{
    public int Id { get; set; }

    [Url]
    [StringLength(50)]
    public required string Name { get; set; }

    [Required]
    [StringLength(50)]
    public required string Image { get; set; }

    [Required]
    [StringLength(20)]
    public required string Contact { get; set; }

    [Required]
    [StringLength(50)]
    public required string Location { get; set; }

    [Required]
    [StringLength(100)]
    public required string Description { get; set; }
}