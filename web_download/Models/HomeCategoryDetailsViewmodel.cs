using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webdownload.Models
{
    public class HomeCategoryDetailsViewmodel
    {
        public TblCategory Category { get; set; }

        public List<TblSoftware> Softwares { get; set; }

        public int total_page { get; set; }

        public int page_index { get; set; }
    }
}
