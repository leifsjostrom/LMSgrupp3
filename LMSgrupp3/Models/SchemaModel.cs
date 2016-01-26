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
        public string TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual TeacherModel Teacher { get; set; }

        [Required]
        public virtual ICollection<CourceModel> Cources { get; set; }
        public int CourceId { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public DateTime  StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

    }
}