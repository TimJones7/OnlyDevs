using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class RecruiterProfile
    {
        [Key]
        public Guid Id { get; set; }
        //  This is where all the information about a Recruiter user will be store
        //  We will use custom validations in order to ensure only a developer
        //  user has a DevProfile, and only a Recruiter user has a RecruiterProfile
    }
}
