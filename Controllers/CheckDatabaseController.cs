using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Wings21D.Models;
using System.Linq;

namespace Wings21D.Controllers
{
    public class CheckDatabaseController : ApiController
    {
        // GET api/values/5
        public bool Get(string dbName)
        {
            if (!String.IsNullOrEmpty(dbName))
            {
                SqlConnection con = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Data Source=localhost\SQLEXPRESS");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                DataSet ds = new DataSet();
                string qStr = "Select Count(*) from sys.databases Where name='" + dbName + "'";

                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmd.CommandText = qStr;
                    da.SelectCommand = cmd;
                    cmd.ExecuteNonQuery();
                    da.Fill(ds);

                    if (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) > 0)
                    {
                        con.Close();
                        return true;                        
                    }
                    else
                    {
                        con.Close();
                        return false;
                    }
                }
                catch
                {
                    con.Close();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // POST api/values
        public HttpResponseMessage Post(List<Users> usr)
        {
            var re = Request;
            var headers = re.Headers;
            String dbName = String.Empty;

            if (headers.Contains("dbname"))
            {
                dbName = headers.GetValues("dbname").First();
            }

            SqlConnection con = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=" + dbName + @";Data Source=localhost\SQLEXPRESS");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            if (!String.IsNullOrEmpty(dbName))
            {
                try
                {
                    con.Open();
                    foreach (Users users in usr)
                    {
                        cmd.CommandText = "Insert Into CompanyUsers_Table Values('" + users.userName + "','" + users.userPassword + "'," + users.userStatus +  ")";
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
                }
                return new HttpResponseMessage(System.Net.HttpStatusCode.Created);
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            }
        }

    }
}
