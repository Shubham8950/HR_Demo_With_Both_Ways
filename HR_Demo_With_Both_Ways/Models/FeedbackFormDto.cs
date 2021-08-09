using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR_Demo_With_Both_Ways.Models
{
    public class FeedbackFormDto
    {
        public int FeedbackId { get; set; }
        public string AdditionalComment { get; set; }
        public string Review { get; set; }
    }
}