using System.ComponentModel.DataAnnotations;
using System.Text;
using System;


namespace test_Data.Models
{
    public class ParentModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Please enter Username")]
        public required string Surname { get; set; }
        [Required(ErrorMessage = "Get big boy")]
        public required int PhoneNumber { get; set; }
        public required string SpouseName { get; set; }
        public required int SpousePhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter contact")]
        public required string EmergencyContactName { get; set; }
        [Required(ErrorMessage = "Get big boy")]
        public required int EmergencyContactPhoneNumber { get; set; }

    }




}

