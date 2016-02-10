using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace LMSgrupp3.Views
{
    public class FileTransfer
    {
        public void Download(HttpPostedFileBase file)
        {
            try
            {
                Stream inStream = file.InputStream;

                using (FileStream fs = File.OpenWrite("C:\\download\\" + file.FileName))
                {
                    inStream.CopyTo(fs);
                    fs.Flush();
                }
            }
            catch (Exception e)
            {
                string errMsg = e.Message;
            }


            /*
            try
            {
                // set the http content type to "APPLICATION/OCTET-STREAM
                System.Web.HttpContext.Current.Response.ContentType = "APPLICATION/OCTET-STREAM";

                // initialize the http content-disposition header to
                // indicate a file attachment with the default filename
                // "myFile.txt"
                string disHeader = "Attachment; Filename=\"" + file.FileName +  "\"";
                System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", disHeader);

                // transfer the file byte-by-byte to the response object
                System.IO.FileInfo fileToDownload = new
                    System.IO.FileInfo("C:\\download\\" + file.FileName);
                System.Web.HttpContext.Current.Response.Flush();
                System.Web.HttpContext.Current.Response.WriteFile(fileToDownload.FullName);
            }
            catch (System.Exception e)
            {
               Console.WriteLine(e.Message);
            }
             */ 
        }


        public void Upload(HttpPostedFileBase file)
        {
            try
            {
                Stream inStream = file.InputStream;

                using (FileStream fs = File.OpenWrite("C:\\upload\\" + file.FileName))
                {
                    inStream.CopyTo(fs);
                    fs.Flush();
                }
            }
            catch (Exception e)
            {
                string errMsg = e.Message;
            }
        }


    }
}