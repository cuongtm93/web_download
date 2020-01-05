using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web_download.Models
{
    public class tblTop
    {
        [Key]
        public int ID { get; set; }
        public string Week { get; set; }
        public string Top { get; set; }
    }
}
