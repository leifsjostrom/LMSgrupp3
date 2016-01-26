using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LMSgrupp3.Models
{
    public class SchemaModel
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string TeacherEmplymentNumber { get; set; }
        [ForeignKey("TeacherEmplymentNumber")]
        public virtual TeacherModel Teacher { get; set; }

        [Required]
        public int CourceId { get; set; }
        [ForeignKey("CourceId")]
        public CourceModel Cource { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public DateTime  StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

    }
}