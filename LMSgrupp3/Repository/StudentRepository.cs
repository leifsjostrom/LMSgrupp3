﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMSgrupp3.DataConnection;
using LMSgrupp3.Models;


namespace LMSgrupp3.Repository
{
    public class StudentRepository
    {
        private StudentContext db = new StudentContext();

        public List<StudentModel> ShowAll()
        //Returns a list of all students
        //{
        //    var query = db.Students
        //        .Include(m => m.StudentNumber);
        //    return query.ToList();
        //}
    }
}