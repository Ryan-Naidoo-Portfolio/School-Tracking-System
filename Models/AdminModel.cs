using System.ComponentModel.DataAnnotations;
using System.Text;
using System;


namespace test_Data.Models
{
    public class AdminModel
    {
        [Key]
        public int aID { get; set; }
        [Required(ErrorMessage = "Please Enter Admin Name")]
        public required string aName { get; set; }
        [Required(ErrorMessage = "Please Enter Admin Surname")]
        public required string aSurname { get; set; }
        public string? acID { get; set; }


    }




}
