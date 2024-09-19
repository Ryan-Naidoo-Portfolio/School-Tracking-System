using System.ComponentModel.DataAnnotations;
using System.Text;
using System;
using Microsoft.EntityFrameworkCore;


namespace test_Data.Models
{
    public class AccountModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter A Username")]
        [UniqueUsername]
        public required string Username { get; set; }
        [Required(ErrorMessage = "Please Enter A Password")]
        public required string Password { get; set; }
        [Required(ErrorMessage = "Please Select Your Position")]
        public required string Position { get; set; }

    }




}
