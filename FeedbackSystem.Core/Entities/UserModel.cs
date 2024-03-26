using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.Core.Entities
{
    public class UserModel : IdentityUser
    {
        [PersonalData]
        public string Fullname { get; set; }
        [PersonalData]
        public short? Activation { get; set; } = 0;
        [PersonalData]
        public DateTime CreatedAt { get; set; }
        [PersonalData]
        public string? CreatedBy { get; set; }
        [PersonalData]
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        [PersonalData]
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
        [PersonalData]
        public string? UserRole { get; set; }
    }
}
