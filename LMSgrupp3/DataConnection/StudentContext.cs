using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LMSgrupp3.DataConnection
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("DefaultConnection") { }

        public DbSet<Models.TeacherModel> Teachers { get; set; }
        public DbSet<Models.CourceModel> Cources { get; set; }
        public DbSet<Models.FileModel> Files { get; set; }
        public DbSet<Models.SchemaModel> Schemas { get; set; }
        public DbSet<Models.StudentModel> Students { get; set; }
    }
}