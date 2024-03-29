﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static Toto_Simulator.Data.DataConstants.User;
namespace Toto_Simulator.Data.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(MaxUserFirstName)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(MaxUserLastName)]
        public string LastName { get; set; }

        public decimal Earnings { get; set; }

    }
}
