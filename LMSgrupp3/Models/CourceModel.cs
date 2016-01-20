using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LMSgrupp3.Models
{
    public class CourceModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public TeacherModel Teacher { get; set; }

        [Required]
        public List<StudentModel> Students { get; set; }

    }
}