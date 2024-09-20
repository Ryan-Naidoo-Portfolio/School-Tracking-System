using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace test_Data.Models 
{
    public class UniqueUsernameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var db = new DemoContext();
            var username = value as string;

            if (db.Account.Any(u => u.acUsername == username))
            {
                return new ValidationResult("Username is already taken.");
            }

            return ValidationResult.Success;
        }
    }
}

