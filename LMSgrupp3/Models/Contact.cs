using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LMSgrupp3.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace LMSgrupp3.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
    }



}