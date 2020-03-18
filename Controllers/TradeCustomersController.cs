﻿using System;
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
    public class TradeCustomersController : ApiController
    {

        // GET api/values
        //public IEnumerable<string> Get()
        public HttpResponseMessage Get(string dbName, string beatName)
        {   
            if (!String.IsNullOrEmpty(dbName))
            {
                SqlConnection con = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=" + dbName + @";Data Source=localhost\SQLEXPRESS");
                DataSet ds = new DataSet();
                List<string> mn = new List<string>();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable Customers = new DataTable();
                SqlCommand cmd = new SqlCommand();

                try
                {
                    cmd.Connection = con;
                    con.Open();

                    if (!String.IsNullOrEmpty(beatName))
                    {
                        cmd.CommandText = "Select a.CustomerName, a.BeatName, a.ProfitCenterName, ISNULL(a.CustomerCity,'Not Set') CustomerCity, " +
                                          "ISNULL(a.GSTNumber,'Not Set') GSTNumber, ISNULL(Sum(b.PendingValue),0) TotalDue " +
                                          "From Trade_Customers_Table a LEFT Join Trade_CustomerPendingBills_Table b " +
                                          "On a.CustomerName = b.CustomerName Where a.BeatName='" + beatName.Trim() + "'" +
                                          "Group by a. CustomerName, b.CustomerName, a.BeatName, a.ProfitCenterName, a.GSTNumber, a.CustomerCity " +
                                          "Order by a.CustomerName, a.BeatName";
                    }
                    else
                    {
                        cmd.CommandText = "Select a.CustomerName, a.BeatName, a.ProfitCenterName, ISNULL(a.CustomerCity,'Not Set') CustomerCity, " +
                                          "ISNULL(a.GSTNumber,'Not Set') GSTNumber, ISNULL(Sum(b.PendingValue),0) TotalDue " +
                                          "From Trade_Customers_Table a LEFT Join Trade_CustomerPendingBills_Table b " +
                                          "On a.CustomerName = b.CustomerName "  +
                                          "Group by a. CustomerName, b.CustomerName, a.BeatName, a.ProfitCenterName, a.GSTNumber, a.CustomerCity " +
                                          "Order by a.CustomerName, a.BeatName";
                    }
                    da.SelectCommand = cmd;
                    Customers.TableName = "Customers";
                    da.Fill(Customers);
                    con.Close();

                }
                catch (Exception ex)
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }

                var returnResponseObject = new
                {
                    Customers = Customers
                };

                var response = Request.CreateResponse(HttpStatusCode.OK, returnResponseObject, MediaTypeHeaderValue.Parse("application/json"));

                return response;
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        // GET api/values/5

        // POST api/values
        public HttpResponseMessage Post(List<TradeCustomers> customers)
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
                    foreach (TradeCustomers cust in customers)
                    {
                        cmd.CommandText = "Insert Into Trade_Customers_Table Values('" + cust.customerName + "', '" +
                        cust.beatName + "','" + cust.profitCenterName + "','" + cust.gstNumber + "','" + cust.customerCity +
                        "'," + cust.activeStatus + ")";
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }

                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

        }

    }
}