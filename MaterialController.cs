using Material.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Material.Controllers
{
    public class MaterialController : ApiController
    {
        [HttpGet]
        [Route("api/Material")]
        public List<Mater> GetMaterial()
        {
            List<Mater> mat = new List<Mater>();
            Mater material = new Mater();
            SqlConnection con = new SqlConnection("data source=DESKTOP-UNUTNRR SQLEXPRESS;database=company1,integrated security=SSPI");
            try
            {
                con.Open();
                string query = "select * from Material";
                SqlCommand cm = new SqlCommand(query, con);
                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    material = new Mater();
                    material.material = dr["material"].ToString();
                    material.Question = dr["Question"].ToString();
                    material.Assignment = dr["Assignment"].ToString();

                    mat.Add(material);
                }

            }
            catch (Exception ex)
            {

            }

            return mat;
        }



        // GET: api/Material
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Material/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Material
        [HttpPost]
        [Route("api/insertMaterial")]

        public string insertMaterial([FromBody] Mater obj)

        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source =.;database=company1,integrated security=SSPI");
                con.Open();
                SqlCommand cm = new SqlCommand
               ("insert into Coursedetails1 values (" + obj.material + ",'" + obj.Question + "'," + obj.Assignment + ");", con);
                SqlDataReader dr = cm.ExecuteReader();


            }
            catch (Exception ex)
            {

            }
            return "inserted data successfully";


        }


        // PUT: api/Material/5
        [HttpPut]
        [Route("api/updateMaterial")]

        public string updateMater(int id, [FromBody] Mater Msdata)
        {
            SqlConnection con = new SqlConnection("data source=.;database=company1,integrated security=SSPI");
            con.Open();
            SqlCommand cm = new SqlCommand("update Msdata set material='" + Msdata.material + "',Coursename = '" + Msdata.Question + "' where id=2", con);
            cm.ExecuteNonQuery();
            con.Close();
            return "updated";
        }


        // DELETE: api/Material/5
        public void Delete(int id)
        {
        }
    }
}
