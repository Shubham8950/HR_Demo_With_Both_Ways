using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IFeedback
    {
        DataTable SaveFeedback(Feedback feedback);
        Feedback GetFeedbackById(int id);
        string SaveFeedbackForm(FeedbackResponse feedbackform);
    }
}
