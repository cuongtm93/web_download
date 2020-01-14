using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webdownload.Models
{
    public class TblAccount
    {

        [Key]
        public int ID { get; set; }
        public int role { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        public int activated { get; set; }

        public int deleted { get; set; }

        public string mobile { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        public DateTime date_of_birth { get; set; }
    }
}
