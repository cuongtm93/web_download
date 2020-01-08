using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webdownload.Models;

namespace webdownload.Areas.Admin.Models
{
    public class IndexSearchViewmodel
    {
        public string Keyword { get; set; }

        public int found { get; set; }
        public int total { get; set; }
        public List<TblSoftware> Softwares { get; set; }
        public List<TblSoftware> Categories { get; set; }
    }
}
