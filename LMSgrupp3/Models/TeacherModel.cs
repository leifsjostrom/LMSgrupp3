﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LMSgrupp3.Models
{
    public class TeacherModel
    {
        [Required]
        [Key]
        public string EmplymentNumber { get; set; }

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

        public virtual ICollection<CourceModel> Cources { get; set; }
        public int CourceId { get; set; }
    }
}