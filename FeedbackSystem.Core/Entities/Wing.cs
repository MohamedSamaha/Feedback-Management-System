using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FeedbackSystem.Core.Entities;

[Table("wings")]
[Index("NameAr", Name = "wings$wings_name_ar_unique", IsUnique = true)]
[Index("NameEn", Name = "wings$wings_name_en_unique", IsUnique = true)]
[Index("UserId", Name = "wings_user_id_foreign")]
public partial class Wing
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name_en")]
    [StringLength(200)]
    public string NameEn { get; set; } = null!;

    [Column("name_ar")]
    [StringLength(200)]
    public string NameAr { get; set; } = null!;

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
