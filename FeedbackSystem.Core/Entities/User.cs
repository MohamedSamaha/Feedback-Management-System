using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FeedbackSystem.Core.Entities;

[Table("users")]
[Index("Email", Name = "users$users_email_unique", IsUnique = true)]
public partial class User : BaseModel
{

    [Column("name")]
    [StringLength(191)]
    public string Name { get; set; } = null!;

    [Column("email")]
    [StringLength(191)]
    public string Email { get; set; } = null!;

    [Column("email_verified_at", TypeName = "datetime")]
    public DateTime? EmailVerifiedAt { get; set; }

    [Column("password")]
    [StringLength(191)]
    public string Password { get; set; } = null!;

    [Column("two_factor_secret")]
    public string? TwoFactorSecret { get; set; }

    [Column("two_factor_recovery_codes")]
    public string? TwoFactorRecoveryCodes { get; set; }

    [Column("remember_token")]
    [StringLength(100)]
    public string? RememberToken { get; set; }

    [Column("current_team_id")]
    public long? CurrentTeamId { get; set; }

    [Column("profile_photo_path")]
    public string? ProfilePhotoPath { get; set; }

    [Column("role")]
    [StringLength(191)]
    public string Role { get; set; } = null!;

    [Column("activation")]
    public short Activation { get; set; }
}
