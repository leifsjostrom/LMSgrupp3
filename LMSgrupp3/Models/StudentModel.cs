using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSgrupp3.Models
{
    public class StudentModel
    {
        [Required]
        [Key]
        public string StudentNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public string Town { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        public virtual ICollection<FileModel > Files { get; set; }
        public int FileId { get; set; }
    }
}