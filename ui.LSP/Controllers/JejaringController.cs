﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ui.LSP.Models;

namespace ui.LSP.Controllers
{
    public class JejaringController : ApiController
    {
        public HttpResponseMessage GetAll()
        {
            string query = @"
                    SELECT [Kode_Jejaring]
                        ,[Nomer_Lisensi]
                        ,[Kode_KK_Terlisensi]
                        ,[NPSN]
                    FROM [dbo].[Tb_Jejaring]";

            DataTable table = new DataTable();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LSPdb"].ConnectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        da.Fill(table);
                    }
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public HttpResponseMessage GetByID(string id)
        {
            string query = @"

                    SELECT [Kode_Jejaring]
                        ,[Nomer_Lisensi]
                        ,[Kode_KK_Terlisensi]
                        ,[NPSN]
                    FROM [dbo].[Tb_Jejaring] WHERE Kode_Jejaring = '"+ id +"' ";

            DataTable table = new DataTable();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LSPdb"].ConnectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        da.Fill(table);
                    }
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Tb_Jejaring tbjejaring)
        {
            try
            {
                string query = @"
                        INSERT INTO [dbo].[Tb_Jejaring]
                              ([Kode_Jejaring]
                              ,[Nomer_Lisensi]
                              ,[Kode_KK_Terlisensi]
                              ,[NPSN])
                        VALUES"
                + "('" + tbjejaring.Kode_Jejaring + "','" + tbjejaring.Nomer_Lisensi + "','" + tbjejaring.Kode_KK_Terlisensi + "','" + tbjejaring.NPSN + "')";

                DataTable table = new DataTable();
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LSPdb"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;
                            da.Fill(table);
                        }
                    }
                }
                return "Insert Successfully";
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }

        public string Put(Tb_Jejaring tbjejaring)
        {
            try
            {
                string query = @"
                        UPDATE [dbo].[Tb_Jejaring] SET"
                   +"        ,[Nomer_Lisensi] = '"+ tbjejaring.Kode_Jejaring+"'"
                   +"        ,[Kode_KK_Terlisensi] = '"+ tbjejaring.Kode_KK_Terlisensi+"'"
                   +"        ,[NPSN] = '"+ tbjejaring.NPSN+"'"
                   +"     WHERE [Kode_Jejaring] = '"+ tbjejaring.Kode_Jejaring +"'";

                DataTable table = new DataTable();
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LSPdb"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;
                            da.Fill(table);
                        }
                    }
                }
                return "Update Successfully";
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }
        
        public string Delete (string kode_jejaring, string userLogin)
        {
            try
            {
                string query = @"UPDATE FROM [LSPdb].[dbo].[Tb_Jejaring] SET "
                    + "            ,isDelete = '" + 0 + "' "
                    + "           ,edited = '" + DateTime.Now.ToString() + "' "
                    + "            ,editor = '" + userLogin + "' "
                    + "            WHERE [Kode_Jejaring] = '" + kode_jejaring +"'";
                
                DataTable table = new DataTable();
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LSPdb"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;
                            da.Fill(table);
                        }
                    }
                }
                return "Update Successfully";
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }
        
        [Route("api/Jejaring/totaldata")]
        public HttpResponseMessage TotalData()
        {
            try
            {
                string csql = @"SELECT count(*) as total FROM [LSPdb].[dbo].[Tb_Jejaring]";

                DataTable tbl = new DataTable();
                using (var conx = new SqlConnection(ConfigurationManager.ConnectionStrings["LSPdb"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(csql, conx))
                    {
                        using (var dta = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;
                            dta.Fill(tbl);
                        }
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, tbl);
            }
            catch (Exception err)
            {
                return Request.CreateResponse(HttpStatusCode.OK, err.Message);
            }
        }
    }
}


// Sahrul Ramadhani

//Email :
//sahrul.r.dhani@gmail.com
