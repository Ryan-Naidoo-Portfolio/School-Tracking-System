using System.ComponentModel.DataAnnotations;
using System.Text;
using System;


namespace test_Data.Models
{
    public class ChildModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter The Students Name")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Students Surname")]
        public required string Surname { get; set; }
        [Required(ErrorMessage = "Please Enter Students Form Class")]
        public required string FormClass { get; set; }

    }




}
