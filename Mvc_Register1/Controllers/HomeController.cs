using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Register1.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace Mvc_Register1.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con1 = new SqlConnection("Data Source=OPTILIZA0077\\SQLEXPRESS;Initial Catalog=MVC;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
        // GET: Home
        public ActionResult Index() 
        {
            FruitModel fruit = new FruitModel();
            fruit.Fruits = PopulateFruits();
            return View(fruit);
        }
        [HttpPost]
        public ActionResult Index(FruitModel fruit)
        {
            fruit.Fruits = PopulateFruits();
            var selectedItem = fruit.Fruits.Find(p => p.Value == fruit.FruitId.ToString());
            string gen = "";
            if(fruit.Gender==false)
            {
                gen = "Male";
            }
            else
            {
                gen = "Female";
            }
            string nm = fruit.StudentName.ToString();
            //string gen = fruit.Gender.ToString();
            string crs = selectedItem.Text.ToString();
            con1.Open();
            SqlCommand cmd = new SqlCommand("insert into Students values('" + nm + "','" + gen + "','" + crs + "')", con1);
            int i = cmd.ExecuteNonQuery();
            if(i>0)
            {
                ViewBag.Message = "Insert Successfully...";
            }
            
            con1.Close();
           
            //if (selectedItem != null)
            //{
            //    selectedItem.Selected = true;
            //    ViewBag.Message = "Fruit: " + selectedItem.Text;
            //    //ViewBag.Message += "\\nQuantity: " + fruit.Quantity;
            //}

            return View(fruit);
        }
        private static List<SelectListItem> PopulateFruits()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string constr = "Data Source=OPTILIZA0077\\SQLEXPRESS;Initial Catalog=MVC;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = " SELECT * FROM StudCourse";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = sdr["Course"].ToString(),
                                Value = sdr["StudCorseId"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }

            return items;
        }
    }
}
