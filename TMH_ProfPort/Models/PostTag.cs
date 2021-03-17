using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TMH_ProfPort.Models
{
    public class PostTag
    {
        [Key]
        public int TagId { get; set; }

        public int PostId { get; set; }

        public string Tag { get; set; }

    }
}
