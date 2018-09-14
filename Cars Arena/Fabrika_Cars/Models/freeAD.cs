using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Fabrika_Cars.Models
{
    public class freeAD
    {
        public int id { get; set; }
        public string title { get; set; }

        [MaxLength(9000)]
        public string description { get; set; }
        public string car_cat { get; set; }
        public string city { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string mail { get; set; }
        public string price { get; set; }
    }
}