using System.ComponentModel.DataAnnotations;
using System.Text;
using System;

namespace test_Data.Models
{
    public class QRCodes
    {
        public int Id { get; set; }
        public required string SId { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string DateScan { get; set; }
        public string FormClass { get; set; }
        public string Present { get; set; }
    }

}
