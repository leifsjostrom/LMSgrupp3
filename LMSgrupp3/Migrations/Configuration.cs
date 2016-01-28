namespace LMSgrupp3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LMSgrupp3.DataConnection;
    using LMSgrupp3.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LMSgrupp3.DataConnection.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LMSgrupp3.DataConnection.StudentContext context)
        {
            context.Teachers.AddOrUpdate(
                new TeacherModel
                {
                    EmplymentNumber = "1001",
                    Name = "Arwid Nordquist",
                    Adress = "Guldgatan 45",
                    Town = "Umea",
                    ZipCode = "901 56",
                    Email = "AnNord@yahoo.com"
                },
                new TeacherModel
                {
                    EmplymentNumber = "1002",
                    Name = "Molly Melon",
                    Adress = "Snårstigen 11",
                    Town = "Umea",
                    ZipCode = "901 50",
                    Email = "MoMello@yahoo.com"
                }
              );
            context.SaveChanges();

            context.Cources.AddOrUpdate(
                new CourceModel
                {
                    Id = 1,
                    Name = "Datavetenskap grundkurs",
                    TeacherId = "1001",
                    Students = null
                }
                );
            context.SaveChanges();

            context.Files.AddOrUpdate(
                new FileModel
                {
                    Id = 1,
                    Name = "Inlämingsuppgift 1",
                    Subject = "Problembeskrivning",
                    Shared = true,
                    CourceId = 1,
                    Date = DateTime.Now
                }
            );
            context.SaveChanges();


            context.Schemas.AddOrUpdate(
                new SchemaModel
                {
                    CourceId = 1,
                    Id = 101,
                    TeacherId = "1001",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Location = "Aula"
                }
            );

            context.Students.AddOrUpdate
                (
                new StudentModel
                {
                    StudentNumber = "1001",
                    Name = "Arne Arg",
                    Email = "",
                    Adress = "",
                    Town = "",
                    ZipCode = "",
                    FileId = 0
                },
                new StudentModel
                {
                    StudentNumber = "1002",
                    Name = "Bea Borg",
                    Email = "",
                    Adress = "",
                    Town = "",
                    ZipCode = "",
                    FileId = 1
                }
                );
        }
    }
}
