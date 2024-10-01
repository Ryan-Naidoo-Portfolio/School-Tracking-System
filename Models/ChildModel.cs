using System.ComponentModel.DataAnnotations;
using System.Text;
using System;


namespace test_Data.Models
{
    public class ChildModel
    {
        [Key]
        public int sID { get; set; }
        [Required(ErrorMessage = "Please Enter The Students Name")]
        public required string sName { get; set; }
        [Required(ErrorMessage = "Please Enter Students Surname")]
        public required string sSurname { get; set; }
        [Required(ErrorMessage = "Please Enter Students Form Class")]
        public required string sFormClass { get; set; }
        public string? sQrcode { get; set; }
 
        public string? atID { get; set; }

        public string? pID { get; set; }

        public string? TimeIn { get; set; }
        public string? TimeOut { get; set; }
        public string? DateScan { get; set; }
        public string? Present { get; set; }

    }




}
