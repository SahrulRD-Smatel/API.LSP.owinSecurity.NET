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
    public class PenerimaSertifikatController : ApiController
    {
        public HttpResponseMessage GetAll()
        {
            string query = @"
                    SELECT [Kode_Penerima_Sertifikat]
                        ,[Nomer_Lisensi]
                        ,[Kode_KK]
                        ,[Tahun_pelajaran]
                        ,[Jumlah_penerima_sertifikat]
                    FROM [dbo].[Tb_Penerima_Sertifikat]";

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

        public HttpResponseMessage GetByID (string id)
        {
            string query = @"
                   SELECT [Kode_Penerima_Sertifikat]
                        ,[Nomer_Lisensi]
                        ,[Kode_KK]
                        ,[Tahun_pelajaran]
                        ,[Jumlah_penerima_sertifikat]
                    FROM [dbo].[Tb_Penerima_Sertifikat] where Kode_Penerima_Sertifikat = '"+ id +"'";

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

        public string Post (Tb_Penerima_Sertifikat tbps)
        {
            try
            {
                string query = @"
                        INSERT INTO [dbo].[Tb_Penerima_Sertifikat]
                              ([Kode_Penerima_Sertifikat]
                              ,[Nomer_Lisensi]
                              ,[Kode_KK]
                              ,[Tahun_pelajaran]
                              ,[Jumlah_penerima_sertifikat])
                        VALUES"
                    + "('" + tbps.Kode_Penerima_Sertifikat + "','" + tbps.Nomer_Lisensi + "','" + tbps.Kode_KK + "','" + tbps.Tahun_pelajaran + "','" + tbps.Jumlah_penerima_sertifikat + "')";

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

        public string Put (Tb_Penerima_Sertifikat tbps)
        {
            try
            {
                string query = @"
                        UPDATE [dbo].[Tb_Penerima_Sertifikat] SET "
                  + "           ,[Nomer_Lisensi] = '"+ tbps.Nomer_Lisensi +"'"
                  + "           ,[Kode_KK] = '"+ tbps.Kode_KK +"'"
                  + "           ,[Tahun_pelajaran] = '"+ tbps.Tahun_pelajaran +"'"
                  + "           ,[Jumlah_penerima_sertifikat] = '"+ tbps.Jumlah_penerima_sertifikat +"'"
                  + "      WHERE [Kode_Penerima_Sertifikat] = '"+ tbps.Kode_Penerima_Sertifikat +"' ";

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

        public string Delete (string kode_penerima_sertifikat, string userLogin)
        {
            try
            {
                string query = @" UPDATE FROM [LSPdb].[dbo].[Tb_Penerima_Sertifikat] SET "
                    + "            ,isDelete = '" + 0 + "' "
                    + "           ,edited = '" + DateTime.Now.ToString() + "' "
                    + "            ,editor = '" + userLogin + "' "
                    + "            WHERE [Kode_Penerima_Sertifikat] = '" + kode_penerima_sertifikat + "' ";

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

        [Route("api/PenerimaSertifikat/totaldata")]

        public HttpResponseMessage TotalData()
        {
            try
            {
                string csql = @"SELECT count(*) as total FROM [LSPdb].[dbo].[Tb_Penerima_Sertifikat]";

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