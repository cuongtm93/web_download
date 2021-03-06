﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webdownload.Models
{
    public class TblCategory
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string url { get; set; }

        [Required]
        public int order { get; set; }

        public string icon { get; set; }

        public int? ParentID { get; set; }

        public string text { get; set; }
    }
}
