using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LMSgrupp3.Models
{
    public class FileModel
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public TeacherModel Teacher { get; set; }

        [Required]
        public CourceModel Cource { get; set; }

        [Required]
        public bool Shared { get; set; }

    }
}