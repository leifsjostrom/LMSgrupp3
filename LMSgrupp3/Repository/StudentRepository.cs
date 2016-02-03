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

        //***************************************************************************
        // Students

        public StudentModel FindById(string id)
        //Finds and returns a specific vehicle by ID
        {
            List<string> ids = db.Students.Select(s => s.StudentNumber).ToList();
            if (ids.Contains(id))
            {
                var query = db.Students.Where(s => s.StudentNumber == id).First();
                return query;
            }
            else { return null; }
        }

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

        //***************************************************************************
        // Teacher

        public TeacherModel FindByEmpNo(string id)
        //Finds and returns a specific teacher by EmplymentNumber
        {
            List<string> ids = db.Teachers.Select(s => s.EmplymentNumber).ToList();
            if (ids.Contains(id))
            {
                var query = db.Teachers.Where(s => s.EmplymentNumber == id).First();
                return query;
            }
            else { return null; }
        }

        public List<TeacherModel> ShowAllTeachers()
        {
            var query = db.Teachers;
            return query.ToList();
        }

        public bool Create(TeacherModel teacher)
        // Method to create teacher in db, takes teacherModel as argument
        {
            List<String> regs = db.Teachers.Select(sm => sm.EmplymentNumber).ToList();
            if (!regs.Contains(teacher.EmplymentNumber))
            {
                try
                {
                    db.Teachers.Add(teacher);
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


        //***************************************************************************
        // Schemas

        public List<SchemaModel> ShowAllSchemas()
        //Returns a list of all schemas
        {
            var query = db.Schemas;
            return query.ToList();
        }

        //***************************************************************************
        // Files

        public List<FileModel> ShowAllFiles()
        //Returns a list of all schemas
        {
            var query = db.Files;
            return query.ToList();
        }

        public bool Create(FileModel file)
        // Method to create teacher in db, takes fileModel as argument
        {
            List<int> regs = db.Files.Select(fm => fm.Id).ToList();
            if (!regs.Contains(file.Id))
            {
                try
                {
                    db.Files.Add(file);
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