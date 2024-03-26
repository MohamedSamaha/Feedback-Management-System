using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FeedbackSystem.Core.Entities;

[Table("media")]
[Index("ModelType", "ModelId", Name = "media_model_type_model_id_index")]
public partial class Medium
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("model_type")]
    [StringLength(255)]
    public string? ModelType { get; set; }

    [Column("model_id")]
    public long? ModelId { get; set; }

    [Column("filename")]
    [StringLength(255)]
    public string Filename { get; set; } = null!;

    [Column("mime_type")]
    [StringLength(255)]
    public string MimeType { get; set; } = null!;

    [Column("size")]
    public long Size { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}
