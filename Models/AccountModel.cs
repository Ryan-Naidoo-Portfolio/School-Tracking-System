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
        [Required(ErrorMessage = "Please Enter A Valid Username")]
        [UniqueUsername]
        public required string acUsername { get; set; }
        [Required(ErrorMessage = "Please Enter A Valid Password")]
        public required string acPassword { get; set; }
        [Required(ErrorMessage = "Please Select A Valid Position")]
        public required string acPosition { get; set; }
    }




}
