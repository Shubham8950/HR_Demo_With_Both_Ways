using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Email.Service
{
    public class WelcomeRequest
    {
        public string ToEmail { get; set; }
        public string UserName { get; set; }
        public int FeedbackId { get; set; }
    }
}