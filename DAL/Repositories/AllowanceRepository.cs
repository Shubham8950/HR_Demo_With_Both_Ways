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
    }
}
