using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webdownload.Models;

namespace webdownload.Areas.Admin.Models
{
    public class subcategorylist_viewmodel
    {
        public int? CategoryID { get; set; }

        public List<TblSoftware> softwares { get; set; }

        public int page_count { get; set; }

        public int page { get; set; }
    }
}
