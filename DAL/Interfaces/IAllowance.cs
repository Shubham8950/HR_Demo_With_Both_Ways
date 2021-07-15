
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAllowance
    {
        List<Allowance> GetAllowances();

        void SaveAllowances(Allowance model);

        Allowance GetAllowanceById(int SEQID);
        void UpdateAllowances(Allowance model);

        void DeleteAllowance(int SEQID);
    }
}
