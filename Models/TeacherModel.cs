using System.ComponentModel.DataAnnotations;
using System.Text;
using System;


namespace test_Data.Models
{
    public class TeacherModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter The Teachers Name")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Please Enter The Teachers Surname")]
        public required string Surname { get; set; }
        [Required(ErrorMessage = "Please Enter The Teachers Form Class")]
        public required string FormClass { get; set; }

    }




}
