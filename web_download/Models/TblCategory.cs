using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web_download.Models
{
    public class TblCategory
    {
        [Key]
        public int ID { get; set; }

        public string name { get; set; }
        public string url { get; set; }
        public int order { get; set; }

        public string icon { get; set; }

        public TblCategory Parent { get; set; }

        public string text { get; set; }
    }
}
