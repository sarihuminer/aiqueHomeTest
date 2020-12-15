using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DistanceController : Controller
    {

       
        //public ActionResult Index()
        //{
        //    ZipCodes objuser = new ZipCodes();
        //    List<ZipCodes> userlist = new List<ZipCodes>();
        //    DataSet ds = new DataSet();
        //    using (SqlConnection con = new SqlConnection("Data Source=Suresh;Integrated Security=true;Initial Catalog=MySamplesDB"))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("usercrudoperations", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@status", "GET");
        //            con.Open();
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            da.Fill(ds);

        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                ZipCodes uobj = new ZipCodes();
        //                uobj.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
        //                uobj.zip = ds.Tables[0].Rows[i]["zip"].ToString();
        //                userlist.Add(uobj);
        //            }
        //        }
        //        con.Close();
        //    }
        //    return View(objuser);
        //}

        // GET: Distance
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            
           List<ZipCodes> ziplist = new List<ZipCodes>();
            ViewBag.Message = "Address: " + form["txtAddress"];
            ViewBag.Message += "\\nLatitude: " + form["txtLatitude"];
            ViewBag.Message += "\\nLongitude: " + form["txtLongitude"];

            string cs = @"server=35.187.52.149;userid=root;password=hUdj53D45E6;database=tustus_db";

             var con = new MySqlConnection(cs);
            con.Open();

            string sql = "SELECT *  FROM tustus_db.WCMS_ZipCodes limit 10;";
             var cmd = new MySqlCommand(sql, con);

             MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                ZipCodes objZip = new ZipCodes();
                objZip.ID = rdr.GetInt32(0);
                objZip.zip = rdr.GetString(2);
                ziplist.Add(objZip);
            }
            return View(ziplist);
        }
    }
}