using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lsg.Sitdown.Models
{
    public class DailyEntry
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(2000)] 
        public string Yesterday { get; set; }
        [StringLength(2000)] 
        public string Today { get; set; }
        [StringLength(2000)] 
        public string Obstacles { get; set; }
        public DateTime CreatedDate { get; set; }
        //public bool IsCriticalSupportWork { get; set; }
    }
}
