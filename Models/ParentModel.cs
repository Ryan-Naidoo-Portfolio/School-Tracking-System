using System.ComponentModel.DataAnnotations;
using System.Text;
using System;


namespace test_Data.Models
{
    public class ParentModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Parent/Gaurdian Name")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Parent Surname")]
        public required string Surname { get; set; }
        [Required(ErrorMessage = "Please Enter A Valid Phone Number")]
        public required int? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Your Spouses' Name")]
        public required string SpouseName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Spouses' Phone Number")]
        public required int? SpousePhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter An Emergency Contact")]
        public required string EmergencyContactName { get; set; }
        [Required(ErrorMessage = "Please Enter An Emergency Contact Phone Number")]
        public required int? EmergencyContactPhoneNumber { get; set; }

    }




}

