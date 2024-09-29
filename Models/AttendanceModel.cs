using System.ComponentModel.DataAnnotations;
using System.Text;
using System;


namespace test_Data.Models
{
    public class AttendanceModel
    {
       
        public int? ID { get; set; }
        
        public string atTimeIn { get; set; }
      
        public string? atTimeOut { get; set; }
      
        public string atDate { get; set; }
       
        public string atPresent { get; set; }
        public string sID { get; set; }

    }




}
