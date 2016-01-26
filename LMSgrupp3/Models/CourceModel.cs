using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSgrupp3.Models
{
    public class CourceModel
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public TeacherModel Teacher { get; set; }
        public string TeacherId { get; set; }

        [Required]
        public virtual ICollection<StudentModel> Students { get; set; }
        public string StudentNumber { get; set; }

    }
}