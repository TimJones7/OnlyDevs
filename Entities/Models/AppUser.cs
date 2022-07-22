using Entities.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    //  Take note of access modifiers on classes in std libraries
    public class AppUser : IdentityUser
    {
        [Key]
        public Guid Id { get; set; }
        //  We need to examine IdentityUser properties to see what custom properties our users should have

        
        //  Type_of_User is going to discriminate between Dev/Recruiter Type
        public UserType Type_of_User { get; set; }


        public DevProfile? DeveloperProfile { get; set; }
        public RecruiterProfile? RecruiterProfile { get; set; }

        
    }
}
