﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime Date { get; set; }

        [Required]
        public bool Shared { get; set; }

        public virtual ICollection<CourceModel> Cources { get; set; }
        public int CourceId { get; set; }

        public virtual ICollection<StudentModel> Students { get; set; }
        public string StudentNumber { get; set; }

    }
}