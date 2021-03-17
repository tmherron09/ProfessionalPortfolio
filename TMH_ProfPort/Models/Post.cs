using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TMH_ProfPort.Models
{
    public class Post
    {

        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostBreifText { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime PostedOn { get; set; }
        public string HTML { get; set; }

    }
}
