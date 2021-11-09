﻿using Microsoft.AspNetCore.Identity;

namespace Student.IdentityServer.Model
{
    public enum TypeCivility
    {
        Monsieur,
        Madamn,
        Other
    }
    class StudentUser : IdentityUser
    {
        public TypeCivility GenderCivility { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string TelNumber { get; set; }

        public string Country { get; set; }

    }
}
