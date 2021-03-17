using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMH_ProfPort.Models
{
    public class ContactFormSubmission
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public string Message { get; set; }
        public DateTime DateSubmitted { get; set; }


    }
}
