using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class FeedbackResponse
    {
        public int Id { get; set; }
        public int FeedbackId { get; set; }
        public string AdditionalComment { get; set; }
        public string Review { get; set; }
    }
}
