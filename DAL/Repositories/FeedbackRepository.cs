using DAL.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class FeedbackRepository : IFeedback
    {
        public DataTable SaveFeedback(Feedback feedback)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert Into Feedback(EmployeeEmail,StartDate,EndDate,Type,Description) Values(@EmployeeEmail,@StartDate,@EndDate,@Type,@Description) SELECt @@Identity as FeedbackId";
            cmd.Parameters.AddWithValue("@EmployeeEmail", feedback.EmployeeEmail);
            cmd.Parameters.AddWithValue("@StartDate", feedback.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", feedback.EndDate);
            cmd.Parameters.AddWithValue("@Type", feedback.Type);
            cmd.Parameters.AddWithValue("@Description", feedback.Description);
            var ds = Connection.GetData(cmd).Tables[0];
            return ds;
        }

        public Feedback GetFeedbackById(int FeedbackId)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from Feedback Where Id=@FeedbackId";
            cmd.Parameters.AddWithValue("@FeedbackId", FeedbackId);
            var con = new SqlConnection(Connection.sqlConStr);
            con.Open();
            cmd.Connection = con;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            return ds.Tables[0].DataTableToList<Feedback>().FirstOrDefault();
        }

        public string SaveFeedbackForm(FeedbackResponse feedbackform)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert Into FeedbackResponse(FeedbackId,AdditionalComment,Review) Values(@FeedbackId,@AdditionalComment,@Review)";
            cmd.Parameters.AddWithValue("@FeedbackId", feedbackform.FeedbackId);
            cmd.Parameters.AddWithValue("@AdditionalComment", feedbackform.AdditionalComment);
            cmd.Parameters.AddWithValue("@Review", feedbackform.Review);
            return Connection.ExecuteNonQuery(cmd);
        }
    }
}
