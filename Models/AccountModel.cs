using System.ComponentModel.DataAnnotations;
using System.Text;
using System;
using Microsoft.EntityFrameworkCore;


namespace test_Data.Models
{
    public class AccountModel
    {
        [Key]
        public int acID { get; set; }
        [Required(ErrorMessage = "Please Enter A Username")]
        [UniqueUsername]
        public required string acUsername { get; set; }
        [Required(ErrorMessage = "Please Enter A Password")]
        public required string acPassword { get; set; }
        [Required(ErrorMessage = "Please Select Your Position")]
        public required string acPosition { get; set; }
        public string? aID { get; set; }
        public string? tID { get; set; }
        public string? pID { get; set; }
    }




}
