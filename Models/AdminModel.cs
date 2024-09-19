using System.ComponentModel.DataAnnotations;
using System.Text;
using System;


namespace test_Data.Models
{
    public class AdminModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Admin Name")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Admin Surname")]
        public required string Surname { get; set; }


    }




}
