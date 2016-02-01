using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
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
        {
            var query = db.Students;
               // .Include(m => m.StudentNumber);
            return query.ToList();
        }



        public bool Create(StudentModel student)
        // Method to create student in db, takes studentModel as argument
        {
            List<String> regs = db.Students.Select(sm => sm.StudentNumber).ToList();
            if (!regs.Contains(student.StudentNumber))
            {
                //vehicle.ID = db.Vehicles.Count() + 1;
                try
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
                return true;
            }
            return false;
        }


    }
}