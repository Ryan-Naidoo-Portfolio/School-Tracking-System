using System.ComponentModel.DataAnnotations;
using System.Text;
using System;


namespace test_Data.Models
{
    public class TeacherModel
    {
        [Key]
        public int tID { get; set; }
        [Required(ErrorMessage = "Please Enter The Teachers Name")]
        public required string tName { get; set; }
        [Required(ErrorMessage = "Please Enter The Teachers Surname")]
        public required string tSurname { get; set; }
        [Required(ErrorMessage = "Please Enter The Teachers Form Class")]
        public required string tFormClass { get; set; }
        public string? acID { get; set; }

    }




}
