using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FeedbackSystem.Core.Entities;

[Keyless]
[Table("password_resets")]
[Index("Email", Name = "password_resets_email_index")]
public partial class PasswordReset
{
    [Column("email")]
    [StringLength(191)]
    public string Email { get; set; } = null!;

    [Column("token")]
    [StringLength(191)]
    public string Token { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
}
