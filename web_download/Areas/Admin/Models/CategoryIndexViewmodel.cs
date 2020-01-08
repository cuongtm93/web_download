using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webdownload.Models;

namespace webdownload.Areas.Admin.Models
{
    public class CategoryIndexViewmodel
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string text { get; set; }
        public string Url { get; set; }
        public TblCategory ParentCategory { get; set; }
        public List<TblCategory> TopCategories { get; set; }
    }
}
