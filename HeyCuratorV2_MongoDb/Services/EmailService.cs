using MimeKit;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using tmherronProfessionalSite.Models;
using tmherronProfessionalSite.Utility;

namespace tmherronProfessionalSite.Services
{
    public class EmailService
    {

        EmailTemplateUtility _responseBuilder;

        public EmailService(EmailTemplateUtility responseBuilder)
        {
            _responseBuilder = responseBuilder;
        }



        public  bool ContactFormEmail(ContactFormModel contactForm)
        {

            MailboxAddress ContactInquiry = new MailboxAddress("Contact Inquiry", "contactinquiry@timherron.dev");

            bool IsSuccess = _responseBuilder.ContactFormAutoResponse(ContactInquiry ,contactForm);

            return IsSuccess;
        }



    }
}