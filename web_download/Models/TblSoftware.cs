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

        [Required]
        public string short_url { get; set; }

        [Required]
        public DateTime DateAdd { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string icon { get; set; }

        public float rating { get; set; }
        public string provider { get; set; }
        public string version { get; set; }
        public int lience { get; set; }
        public int size { get; set; }
        public int viewed { get; set; }
        public int downloaded { get; set; }
        public string operating_systems { get; set; }
        public string text { get; set; }
        public string main_download { get; set; }

        public int? related_downloadID { get; set; }
        public string tags { get; set; }

        [Required]
        public int categoryID { get; set; }

        public int Visible { get; set; }
    }
}
