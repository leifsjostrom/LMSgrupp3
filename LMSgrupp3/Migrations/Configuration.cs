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
                    Email ="AnNord@yahoo.com"
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
                    Teacher = null,
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
                    Cource = null,
                    Date = DateTime.Now
                }
            );
            context.SaveChanges();
        }
    }
}
