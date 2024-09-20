using System.ComponentModel.DataAnnotations;
using System.Text;
using System;


namespace test_Data.Models
{
    public class AttendanceModel
    {
        [Key]
        public int atID { get; set; }
        [Required(ErrorMessage = "Please Enter Student TimeIn")]
        public required string atTimeIn { get; set; }
        [Required(ErrorMessage = "Please Enter Student TimeOut")]
        public required string atTimeOut { get; set; }
        [Required(ErrorMessage = "Please Enter Date")]
        public required string atDate { get; set; }
        [Required(ErrorMessage = "Please Enter Attendance Status")]
        public required string atPresent { get; set; }
        public string? sID { get; set; }

    }




}
