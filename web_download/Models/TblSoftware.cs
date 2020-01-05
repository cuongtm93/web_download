using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webdownload.Models
{
    public class TblSoftware
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int rating { get; set; }
        public string provider { get; set; }
        public string version { get; set; }
        public int lience { get; set; }
        public int size { get; set; }
        public int viewed { get; set; }
        public int downloaded { get; set; }
        public string operating_systems { get; set; }
        public string text { get; set; }
        public string main_download { get; set; }

        public string friendly_url { get; set; }

        public TblSoftware related_download { get; set; }
        public string tags { get; set; }

        public TblCategory category { get; set; }

        [DefaultValue(false)]
        public bool Visible { get; set; }
    }
}
