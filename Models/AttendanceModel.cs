﻿using System.ComponentModel.DataAnnotations;
using System.Text;
using System;


namespace test_Data.Models
{
    public class AttendanceModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter TimeIn")]
        public required string TimeIn { get; set; }
        [Required(ErrorMessage = "Please enter TimeOut")]
        public required string TimeOut { get; set; }
        [Required(ErrorMessage = "Please enter Date")]
        public required string Date { get; set; }
        [Required(ErrorMessage = "Please enter Present")]
        public required string Present { get; set; }

    }




}
