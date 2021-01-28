using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmherronProfessionalSite.Models;
using tmherronProfessionalSite.Services;

namespace tmherronProfessionalSite.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[controller]")]
    public class ContactController : Controller
    {

        private readonly ContactService _contactService;

        public ContactController(ContactService contactService)
        {
            _contactService = contactService;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        [Route("submitcontactform")]
        [HttpPost]
        public ActionResult SubmitContactForm(ContactFormModel formData)
        {
            formData.SubmitTime = DateTime.Now;

            _contactService.Create(formData);
            return Content("Form Succesfully Submitted");
        }
    }
}
