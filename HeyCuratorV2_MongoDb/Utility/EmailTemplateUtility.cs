using Microsoft.AspNetCore.Hosting;
using MimeKit;
using MimeKit.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using tmherronProfessionalSite.Models;

namespace tmherronProfessionalSite.Utility
{
    public class EmailTemplateUtility
    {

        private IWebHostEnvironment _env;

        public EmailTemplateUtility(IWebHostEnvironment env)
        {
            _env = env;
        }


        public bool ContactFormAutoResponse(MailboxAddress ContactInquiry, ContactFormModel contactForm)
        {
            var message = new MimeMessage();
            try
            {
                message.To.Add(new MailboxAddress(contactForm.Name, contactForm.Email));
            }
            catch (ParseException e)
            {
                // Email parsing failed
                return false;
            }

            message.From.Add(ContactInquiry);
            message.Subject = "Thank you for you Inquiry.";

            var builder = new BodyBuilder();


            var pathToProfile = _env.WebRootPath
                + Path.DirectorySeparatorChar.ToString()
                + "images"
                + Path.DirectorySeparatorChar.ToString()
                + "tmh_hs.png";

            var profile = builder.LinkedResources.Add(pathToProfile);
            profile.ContentId = MimeUtils.GenerateMessageId();

            var pathToLogo = _env.WebRootPath
                + Path.DirectorySeparatorChar.ToString()
                + "images"
                + Path.DirectorySeparatorChar.ToString()
                + "tmherron_logo.png";

            var logo = builder.LinkedResources.Add(pathToLogo);
            logo.ContentId = MimeUtils.GenerateMessageId();

            builder.HtmlBody = string.Format(
                @""

                );


            return true;
        }

    }
}
