using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR_Demo_With_Both_Ways.Controllers
{
    public class AllowanceController : Controller
    {
        // GET: Allowance
        private IAllowance _allowanceRepository;
        public AllowanceController() : this(new AllowanceRepository())
        {

        }
        public AllowanceController(IAllowance allowanceRepository)
        {
            _allowanceRepository = allowanceRepository;
        }
        public ActionResult Index()
        {
            var list=_allowanceRepository.GetAllowances();
            return View(list);
        }
    }
}