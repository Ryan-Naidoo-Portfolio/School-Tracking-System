using System.ComponentModel.DataAnnotations;
using System.Text;
using System;
using Microsoft.EntityFrameworkCore;


namespace test_Data.Models
{
    public class AccountModel
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Username")]
        public required string Username { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        public required string Password { get; set; }
        [Required(ErrorMessage = "Please enter Position")]
        public required string Position { get; set; }

    }




}
