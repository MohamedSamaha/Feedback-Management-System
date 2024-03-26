using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace FeedbackSystem.Core.Entities;

[Table("places")]
[Index("Code", Name = "places$places_code_unique", IsUnique = true)]
[Index("BuildingId", Name = "places_building_id_foreign")]
[Index("FloorNumberId", Name = "places_floor_number_id_foreign")]
[Index("PlaceTypeId", Name = "places_place_type_id_foreign")]
[Index("UserId", Name = "places_user_id_foreign")]
[Index("WingId", Name = "places_wing_id_foreign")]
public partial class Place
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("building_id")]
    public long BuildingId { get; set; }

    [Column("place_type_id")]
    public long PlaceTypeId { get; set; }

    [Column("floor_number_id")]
    public long FloorNumberId { get; set; }

    [Column("wing_id")]
    public long WingId { get; set; }

    [Column("code")]
    [StringLength(200)]
    public string Code { get; set; } = null!;

    [Column("description")]
    [StringLength(200)]
    public string Description { get; set; } = null!;

    [Column("activation")]
    public short Activation { get; set; }

    [Column("deleted_at", TypeName = "datetime")]
    public DateTime? DeletedAt { get; set; }

    [Column("user_id")]
    public string? UserId { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}
