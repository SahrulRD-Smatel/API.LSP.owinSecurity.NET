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
    public class LSPController : ApiController
    {
        public HttpResponseMessage GetAll()
        {

            string query = @"

SELECT [Nomer_Lisensi]
      ,[NPSN]
      ,[Status_Lisensi_LSP]
      ,[Berlaku_Sampai]
  FROM [LSPdb].[dbo].[Tb_LSP]
";

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

        // GET api/values/5

        public HttpResponseMessage GetByID(string id)
        {

            string query = @"

SELECT [Nomer_Lisensi]
      ,[NPSN]
      ,[Status_Lisensi_LSP]
      ,[Berlaku_Sampai]
  FROM [LSPdb].[dbo].[Tb_LSP] where Nomer_Lisensi = '" + id + "'";

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

        public string Post(Tb_LSP tblsp)
        {
            try
            {
                string query = @"

INSERT INTO [LSPdb].[dbo].[Tb_LSP]
           ([Nomer_Lisensi]
           ,[NPSN]
           ,[Status_Lisensi_LSP]
           ,[Berlaku_Sampai])
     VALUES"
    + " ('" + tblsp.Nomer_Lisensi + "','" + tblsp.NPSN + "','" + tblsp.Status_Lisensi_LSP + "','" + tblsp.Berlaku_Sampai + "')";
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

        public string Put(Tb_LSP tblsp)
        {
            try
            {
                string query = @"UPDATE [LSPdb].[dbo].[Tb_LSP] SET "
                    + "      ,[NPSN] = '" + tblsp.NPSN + "'"
                    + "      ,[Status_Lisensi_LSP] = '" + tblsp.Status_Lisensi_LSP + "'"
                    + "      ,[Berlaku_Sampai] = '" + tblsp.Berlaku_Sampai + "'"
                    + "   WHERE [Nomer_Lisensi] = '" + tblsp.Nomer_Lisensi + "'";

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

        public string Delete(string nomer_lisensi, string userLogin)
        {
            try
            {
                // string query = @"DELETE FROM [dbo].[Tb_LSP] WHERE [Nomer_Lisensi] = '" + nomer_lisensi + "' ";

                //rubah jadi update isDelete = 1 dan edited = datetime.now, editor = user yg sedang login
                string query = @" UPDATE FROM [LSPdb].[dbo].[Tb_LSP] SET "
                    + "            ,isDelete = '"+ 0 +"' " 
                    + "           ,edited = '"+ DateTime.Now.ToString() +"' "
                    + "            ,editor = '"+ userLogin + "' "
                    + "            WHERE [Nomer_Lisensi] = '"+ nomer_lisensi +"' ";

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

        [Route("api/LSP/totaldata")]
        public HttpResponseMessage TotalData()
        {
            try
            {
                string csql = @"SELECT count(*) as total FROM [LSPdb].[dbo].[Tb_LSP]";

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

// Created By :
// Sahrul Ramadhani

//Email :
//sahrul.r.dhani@gmail.com