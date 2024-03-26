using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.Core.Dtos
{
    public class UserDto
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime? EmailVerifiedAt { get; set; }
        public string Password { get; set; } = null!;
        public string? TwoFactorSecret { get; set; }
        public string? TwoFactorRecoveryCodes { get; set; }
        public string? RememberToken { get; set; }
        public long? CurrentTeamId { get; set; }
        public string? ProfilePhotoPath { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Role { get; set; } = null!;
        public short Activation { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long UserId { get; set; }
    }
}
