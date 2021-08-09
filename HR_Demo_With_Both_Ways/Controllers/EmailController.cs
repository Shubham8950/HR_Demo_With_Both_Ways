using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DAL.Repositories;
using Email.Models.DTO;
using Email.Service;
using Newtonsoft.Json;
using DAL.Interfaces;
using DAL.Models;
using HR_Demo_With_Both_Ways.Models;

namespace HR_Demo_With_Both_Ways.Controllers
{
    public class EmailController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IFeedback _feedbackService;
        public EmailController() : this(new MailService(), new FeedbackRepository())
        {

        }
        public EmailController(IMailService mailService, IFeedback feedbackService)
        {
            _mailService = mailService;
            _feedbackService = feedbackService;
        }

        // GET: Email
        public ActionResult Index()
        {
            return View("Feedback");
        }

        [HttpPost]
        public async Task<ActionResult> Feedback(FeedbackDto feedbackModel)
        {
            try
            {
                var feedback = new Feedback
                {
                    StartDate = feedbackModel.StartDate,
                    EndDate = feedbackModel.EndDate,
                    Type = feedbackModel.TrainingType,
                    EmployeeEmail = feedbackModel.EmpId,
                    Description=feedbackModel.Description
                };
                var dt = _feedbackService.SaveFeedback(feedback);
                var request = new WelcomeRequest()
                {
                    ToEmail = feedbackModel.EmpId,
                    UserName = feedbackModel.EmpId,
                    FeedbackId = Convert.ToInt32(dt.Rows[0][0])
                };

                await _mailService.SendWelcomeEmailAsync(request);
            }
            catch (Exception ex)
            {

            }

            return Json(feedbackModel);
        }

        public ActionResult FeedbackForm(int id)
        {
            var data = _feedbackService.GetFeedbackById(id);


            return View("FeedbackForm", data);
        }

        [HttpPost]
        public async Task<ActionResult> UserFeedback(FeedbackFormDto feedbackForm)
        {
            try
            {
                var feedbackResponse = new FeedbackResponse
                {
                    FeedbackId = feedbackForm.FeedbackId,
                    AdditionalComment = feedbackForm.AdditionalComment,
                    Review = feedbackForm.Review,
                };
                var dt = _feedbackService.SaveFeedbackForm(feedbackResponse);
            }
            catch (Exception ex)
            {

            }

            return Json(feedbackForm);
        }
    }
}