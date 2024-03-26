using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FeedbackSystem.Core.Entities;

[Table("personal_access_tokens")]
[Index("Token", Name = "personal_access_tokens$personal_access_tokens_token_unique", IsUnique = true)]
[Index("TokenableType", "TokenableId", Name = "personal_access_tokens_tokenable_type_tokenable_id_index")]
public partial class PersonalAccessToken
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("tokenable_type")]
    [StringLength(191)]
    public string TokenableType { get; set; } = null!;

    [Column("tokenable_id")]
    public long TokenableId { get; set; }

    [Column("name")]
    [StringLength(191)]
    public string Name { get; set; } = null!;

    [Column("token")]
    [StringLength(64)]
    public string Token { get; set; } = null!;

    [Column("abilities")]
    public string? Abilities { get; set; }

    [Column("last_used_at", TypeName = "datetime")]
    public DateTime? LastUsedAt { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}
