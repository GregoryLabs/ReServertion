using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerReservation.Areas.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string MiddleName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get { return FirstName + " " + LastName; } }

        [PersonalData]
        public string EmployeeId { get; set; }

        [PersonalData]
        public string Title { get; set; }

        [PersonalData, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-yy}", ApplyFormatInEditMode = false)]
        public DateTime? HireDate { get; set; }

        [PersonalData, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-yy}", ApplyFormatInEditMode = false)]
        public DateTime? DateOfBirth { get; set; }

        [PersonalData]
        public byte[] Photo { get; set; }
    }
}
