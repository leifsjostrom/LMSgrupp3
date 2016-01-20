using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LMSgrupp3.Models
{
    public class SchemaModel
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public TeacherModel Teacher { get; set; }

        [Required]
        public CourceModel Cource { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public DateTime  StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

    }
}