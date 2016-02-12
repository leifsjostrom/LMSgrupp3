using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMSgrupp3.DataConnection;
using LMSgrupp3.Models;
using System.Data.SqlClient;


namespace LMSgrupp3.Controllers
{
    public class SchemViewsController : Controller
    {
        private StudentContext db = new StudentContext();

        // GET: SchemViews
       
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {

            string ui = User.Identity.Name;
            string uui = "";

            if (User.IsInRole("Teacher"))
            {
                Session["Teacher"] = true;

                uui = db.Teachers.Where(s => s.Email == ui).Select(s => s.EmplymentNumber).FirstOrDefault();



            }
            else
            {
                Session["Teacher"] = false;
                uui = db.Students.Where(s => s.Email == ui).Select(s => s.StudentNumber).FirstOrDefault();

            }
            Session["Id"] = "1001";
            if (uui != "") { Session["Id"] = uui; }
            //if (User.IsInRole("Teacher"))
            //{
            //    Session["Teacher"] = true;
            //}
            //else { Session["Teacher"] = false; }
            
            //    Session["Id"] = "1001";

            //Session["Teacher"] = true;
            //Session["Id"] = "1001";

            ViewData["Teacher"] = Convert.ToBoolean(Session["Teacher"]);

            string iid=Convert.ToString(Session["Id"]);
            string nname="";
            if (Convert.ToBoolean(Session["Teacher"]))
            {
                var tn = db.Teachers.Where(s => s.EmplymentNumber == iid);
                
                foreach (var ren in tn)
                { nname = ren.Name; }
            
            }
            else
            {
               var sn = db.Students.Where(s=>s.StudentNumber==iid);
               foreach (var ren in sn)
               { nname = ren.Name; }
            }

            ViewData["Name"] = nname;

            var schema = new List<SchemView>();

            using (LMSgrupp3.DataConnection.StudentContext dc = new LMSgrupp3.DataConnection.StudentContext())
            {
                EmptyDb("SchemViews");
                FillDb();
                Fillschema();

                schema = dc.ShemView.ToList();
            
            
            }
         return View(schema);

            
        }


        public void EmptyDb(string DBname)
        {

            //var sv = db.ShemView;

            //if (sv.Count() > 0)
            //{
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlConnection con = new SqlConnection(constring);
                con.Open();
                string sqlTrunc = "TRUNCATE TABLE " + DBname ;
                SqlCommand cmd = new SqlCommand(sqlTrunc, con);
                cmd.ExecuteNonQuery();
                con.Close();
               // con.Dispose();

            //}
        }




        // GET: Schemata
        public void FillDb()
        {

               



            int stime = 8;
            int etime = 18;
            int total = (etime - stime) * 2;
            double st = stime-0.5;
            
            for (int i = 1; i <= total; i++)
            {
                st = st + 0.5;
                SchemView sw = new SchemView();
                string tm1, tm2=":00";
                if (st - Math.Floor(st) > 0) { tm2 = ":30"; }
                tm1 = Convert.ToString(Math.Floor(st));
                if (tm1.Length < 2) { tm1 = "0" + tm1; }
                sw.time = tm1 + tm2;
                db.ShemView.Add(sw);
             
            
            
            }
          
        db.SaveChanges();
        }



       




        public void Fillschema()
        {

            //fill schema;
            //
        DateTime Today = DateTime.Today;
        int weekday = (int) Today.DayOfWeek;
            // get the current week
        DateTime startweek = Today.AddDays(-1 * (weekday - 1));
        DateTime endweek = Today.AddDays(7-weekday);

        //var schemata = db.Schemas.Include(s =>s.Cources).Include(s => s.TeacherId).Where(s=> s.StartDate<=endweek && s.EndDate>=startweek);

        var schemata = db.Schemas.Where(s => s.StartDate <= endweek && s.EndDate >= startweek);
          

        foreach (var r in schemata)
        {

           
            //for teacher ID = TeacherId
               
            //get student ID

            bool incl = false;
            string Id = Convert.ToString(Session["Id"]);

            if (Convert.ToBoolean(Session["Teacher"]))
            {
                if (Id == r.TeacherId) { incl = true; }
                      
            }
            else
            {
                StudentContext dd = new StudentContext();
                int stid = dd.Cources.Where(s => s.Id == r.CourceId &&  s.StudentNumber==Id).Count();
                if (stid > 0) { incl = true; }
            }

            


            if (incl)

            { 



            DateTime start = r.StartDate;
            DateTime end = r.EndDate;
            int wday = (int)start.DayOfWeek;
            int starttimeh = start.Hour;
            int starttimem = start.Minute;
            int endtimeh = end.Hour;
            int endtimem = end.Minute;
            string txt = r.Location;
        //    string foundtime;
        //    foundtime=starttimeh.ToString();
        //    if (foundtime.Length < 2) { foundtime = "0" + foundtime; }
        //    if (starttimem < 30) { foundtime += ":00"; } else { foundtime += ":30"; }
            int foundid = (starttimeh-7)*2-1;
            if (starttimem >= 30) { foundid+=1;}
            int leclen = (endtimeh - starttimeh)*2;
            if (starttimem > endtimem) { leclen -= 1; }
            if (starttimem < endtimem) { leclen += 1; }

           

            //SchemView sw = db.SchemViews.Find(foundid);

            string sb = "";
            StudentContext dc = new StudentContext();
            CourceModel Subj = dc.Cources.Find(r.CourceId);
             sb = Subj.Name;

          
           
            
            //sw.Day1 = "test";
            //db.Entry(sw).State = EntityState.Modified;

            //db.SaveChanges();



            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection con = new SqlConnection(constring);








            for (int i = 0; i < leclen; i++)
            {


                con.Open();


                string sqlUpdt = "UPDATE SchemViews " + " SET Day" + wday.ToString() + "=@Day " + "WHERE Idp=@Idp ";

                SqlCommand cmd = new SqlCommand(sqlUpdt, con);

                cmd.Parameters.AddWithValue("@Idp", foundid);

                string sqlSelect = "SELECT Day" + wday.ToString() + " AS Day FROM SchemViews WHERE Idp=@Idp ";
                SqlCommand cmd1 = new SqlCommand(sqlSelect, con);
                cmd1.Parameters.AddWithValue("@Idp", foundid);

                SqlDataReader reader;
                reader = cmd1.ExecuteReader();

                string ress = "";
                while (reader.Read())
                {
                    if (String.IsNullOrEmpty(reader["Day"].ToString())) { ress = ""; } else { ress = (string)reader["Day"]; }
                }

                reader.Close();



                // System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + reader.ToString()+ "')</SCRIPT>");
                con.Close();

                string info;
                string inf = starttimeh.ToString();
                if (inf.Length < 2) { inf = "0" + inf; }
                info = inf;
                inf = starttimem.ToString();
                if (inf.Length < 2) { inf = "0" + inf; }
                info = info + ":" + inf;

                inf = endtimeh.ToString();
                if (inf.Length < 2) { inf = "0" + inf; }

                info += "-" + inf;
                inf = endtimem.ToString();
                if (inf.Length < 2) { inf = "0" + inf; }
                info = info + ":" + inf + " \n " + sb;

                info = info + "\n" + txt;




                if (!String.IsNullOrEmpty(ress)) { info = ress + "\n" + "!+!" + "\n" + info; }



                info = info.Replace("\n", Environment.NewLine);


                cmd.Parameters.AddWithValue("@Day", info);

                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();


                foundid += 1;

            }


              
              

               
            






            
            }

           


        }



        }

        
    }

    







        
    }

