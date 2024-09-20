
using System.ComponentModel.DataAnnotations;
using System.Text;
using System;


namespace test_Data.Models
{
    public class ParentModel
    {
        [Key]
        public int pID { get; set; }
        [Required(ErrorMessage = "Please Enter Parent/Gaurdian Name")]
        public required string pName { get; set; }
        [Required(ErrorMessage = "Please Enter Parent Surname")]
        public required string pSurname { get; set; }
        [Required(ErrorMessage = "Please Enter A Valid Phone Number")]
        public required int? pPhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Your Spouses' Name")]
        public required string pSpouseName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Spouses' Phone Number")]
        public required int? pSpousePhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter An Emergency Contact")]
        public required string pEmergencyContactName { get; set; }
        [Required(ErrorMessage = "Please Enter An Emergency Contact Phone Number")]
        public required int? pEmergencyPhoneNumber { get; set; }
        public string? acID { get; set; }
        public string? sID { get; set; }

    }




}

