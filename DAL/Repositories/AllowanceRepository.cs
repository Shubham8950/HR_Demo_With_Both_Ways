using DAL.Interfaces;
using DAL.Model;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AllowanceRepository:IAllowance
    {
        public List<Allowance> GetAllowances()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from Allowance";
            return Connection.GetData(cmd).Tables[0].DataTableToList<Allowance>();

        }

        public  void SaveAllowances(Allowance model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert Into Allowance(ALLOWANCE_ID,ALLOWANCE_NAME,MIN_VALUE,MAX_VALUE) Values(@ALLOWANCE_ID,@ALLOWANCE_NAME,@MIN_VALUE,@MAX_VALUE)";
            cmd.Parameters.AddWithValue("@ALLOWANCE_ID", model.ALLOWANCE_ID);
            cmd.Parameters.AddWithValue("@ALLOWANCE_NAME", model.ALLOWANCE_NAME);
            cmd.Parameters.AddWithValue("@MIN_VALUE", model.MIN_VALUE);
            cmd.Parameters.AddWithValue("@MAX_VALUE", model.MAX_VALUE);
            Connection.ExecuteNonQuery(cmd);
        }
        public Allowance GetAllowanceById(int SEQID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from Allowance WHERE SEQID=@SEQID";
            cmd.Parameters.AddWithValue("@SEQID", SEQID);
            return Connection.GetData(cmd).Tables[0].DataTableToList<Allowance>().FirstOrDefault();

        }
        public void UpdateAllowances(Allowance model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Allowance SET ALLOWANCE_NAME=@ALLOWANCE_NAME,MIN_VALUE=@MIN_VALUE,MAX_VALUE=@MAX_VALUE,Allowance_Id=@ALLOWANCE_ID WHERE SEQID=@SEQID";
            cmd.Parameters.AddWithValue("@SEQID", model.SEQID);
            cmd.Parameters.AddWithValue("@ALLOWANCE_ID", model.ALLOWANCE_ID);
            cmd.Parameters.AddWithValue("@ALLOWANCE_NAME", model.ALLOWANCE_NAME);
            cmd.Parameters.AddWithValue("@MIN_VALUE", model.MIN_VALUE);
            cmd.Parameters.AddWithValue("@MAX_VALUE", model.MAX_VALUE);
            Connection.ExecuteNonQuery(cmd);
        }

        public void DeleteAllowance(int SEQID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete FROM Allowance Where SEQID=@SEQID";
            cmd.Parameters.AddWithValue("@SEQID", SEQID);
            Connection.ExecuteNonQuery(cmd);
        }
    }
}
