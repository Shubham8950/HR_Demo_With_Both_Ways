using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Email.Models.DTO
{
    public class FeedbackDto
    {
        public string TrainingType { get; set; }
        public string EmpId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
         
    }
}