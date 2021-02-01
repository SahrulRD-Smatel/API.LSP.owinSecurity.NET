using System;
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
    public class KKeahlianController : ApiController
    {
        public HttpResponseMessage GetAll()
        {
            string query = @"
                SELECT [Kode_KK]
                    ,[Nama_KK]
                FROM [dbo].[Tb_Kompetensi_Keahlian]";

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
                SELECT [Kode_KK]
                    ,[Nama_KK]
                FROM [dbo].[Tb_Kompetensi_Keahlian] where Kode_KK = '"+ id +"'";

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

        public string Post(Tb_Kompetensi_Keahlian tbkk)
        {
            try
            {
                string query = @"
                        INSERT INTO [dbo].[Tb_Kompetensi_Keahlian]
                              ([Kode_KK]
                              ,[Nama_KK])
                        VALUES"
                + "('" + tbkk.Kode_KK + "','" + tbkk.Nama_KK + "')";

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

        public string Put(Tb_Kompetensi_Keahlian tbkk)
        {
            try
            {
                string query = @"UPDATE [dbo].[Tb_Kompetensi Keahlian] SET "
                   + "   ,[Nama_KK] = '"+ tbkk.Nama_KK +"'"
                   + "     WHERE [Kode_KK] = '"+ tbkk.Kode_KK +"'";

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

        public string Delete(string kode_kk, string userLogin)
        {
            try
            {
                string query = @"UPDATE FROM [LSPdb].[dbo].[Tb_Kompetensi_Keahlian] SET "
                    + "            ,isDelete = '" + 0 + "' "
                    + "           ,edited = '" + DateTime.Now.ToString() + "' "
                    + "            ,editor = '" + userLogin + "' "
                    + "            WHERE [Kode_KK] = '" + kode_kk + "' ";

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

        [Route("api/KKeahlian/totaldata")]

        public HttpResponseMessage TotalData()
        {
            try
            {
                string csql = @"SELECT count(*) as total FROM [LSPdb].[dbo].[Tb_Kompetensi Keahlian]";

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