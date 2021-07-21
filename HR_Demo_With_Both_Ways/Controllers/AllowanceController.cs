using DAL.Interfaces;
using DAL.Repositories;
using HR_Demo_With_Both_Ways.Models;
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
        public ActionResult Index(int? id)
        {
            var model = new Allowance();
            if (id > 0)
            {
              model=   _allowanceRepository.GetAllowanceById(Convert.ToInt32(id));
            }
            var list=_allowanceRepository.GetAllowances();
            var obj = new AllowanceViewModel();
            obj.AllowanceList = list;
            obj.Allowance = model;
            return View(obj);
        }

        [HttpPost]
        public ActionResult Save(AllowanceViewModel model)
        {
            if (model.Allowance.SEQID > 0)
            {
                _allowanceRepository.UpdateAllowances(model.Allowance);
            }
            else
            _allowanceRepository.SaveAllowances(model.Allowance);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult GetAllowanceById(int id)
        {
            var model = new Allowance();
            if (id > 0)
            {
                model = _allowanceRepository.GetAllowanceById(Convert.ToInt32(id));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int id)
        {
            _allowanceRepository.DeleteAllowance(id);
            return RedirectToAction("Index");
        }


    }
}