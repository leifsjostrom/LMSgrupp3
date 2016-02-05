using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LMSgrupp3.Models
{
    
        public class SchemView
        {
            [Key]
            public int Idp { get; set; }

            public string time { get; set; }
            public string Day1 { get; set; }
            public string Day2 { get; set; }
            public string Day3 { get; set; }
            public string Day4 { get; set; }
            public string Day5 { get; set; }
            public string Day6 { get; set; }
            public string Day7 { get; set; }
        }
    }
