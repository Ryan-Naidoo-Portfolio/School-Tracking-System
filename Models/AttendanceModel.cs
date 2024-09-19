using System.ComponentModel.DataAnnotations;
using System.Text;
using System;


namespace test_Data.Models
{
    public class AttendanceModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Student Name")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Student TimeIn")]
        public required string TimeIn { get; set; }
        [Required(ErrorMessage = "Please Enter Student TimeOut")]
        public required string TimeOut { get; set; }
        [Required(ErrorMessage = "Please Enter Date")]
        public required string Date { get; set; }
        [Required(ErrorMessage = "Please Enter Attendance Status")]
        public required string Present { get; set; }
        [Required(ErrorMessage = "Please Enter Students Surname")]
        public required string Surname { get; set; }
        [Required(ErrorMessage = "Please Enter Student Form Class")]
        public required string FormClass { get; set; }

    }




}
