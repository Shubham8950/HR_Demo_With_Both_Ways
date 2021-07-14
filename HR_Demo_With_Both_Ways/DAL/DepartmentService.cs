using HR_Demo_With_Both_Ways.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR_Demo_With_Both_Ways.DAL
{
    public class DepartmentService
    {
        private HR_DEMOEntities _dbcontext;
        public DepartmentService()
        {

        }
        public DepartmentService(HR_DEMOEntities dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<DEPARTMENT> GetDEPARTMENTS()
        {
            using (var dbContext= new HR_DEMOEntities())
            {
               return    dbContext.DEPARTMENTs.ToList();
            }
        }

    }
}