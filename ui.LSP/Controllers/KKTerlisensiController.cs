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
    public class KKTerlisensiController : ApiController
    {
        public HttpResponseMessage GetAll()
        {
            string query = @"
  SELECT [Kode_KK_Terlisensi]
      ,[Nomer_Lisensi]
      ,[Kode_KK]
      ,[Status_KK_Terlisensi]
      ,[Jumlah_asesor]
  FROM [dbo].[Tb_Kompetensi_Keahlian_Terlisensi]";

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
  SELECT [Kode_KK_Terlisensi]
      ,[Nomer_Lisensi]
      ,[Kode_KK]
      ,[Status_KK_Terlisensi]
      ,[Jumlah_asesor]
  FROM [dbo].[Tb_Kompetensi_Keahlian_Terlisensi] where Kode_KK_Terlisensi = '"+ id +"'";

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

        public string Post (Tb_Kompetensi_Keahlian_Terlisensi tbkkt )
        {
            try
            {
                string query = @"
                            INSERT INTO [dbo].[Tb_Kompetensi_Keahlian_Terlisensi]
                                   ([Kode_KK_Terlisensi]
                                   ,[Nomer_Lisensi]
                                   ,[Kode_KK]
                                   ,[Status_KK_Terlisensi]
                                   ,[Jumlah_asesor])
                             VALUES"
                       + "('"+ tbkkt.Kode_KK_Terlisensi +"','"+ tbkkt.Nomer_Lisensi +"','"+ tbkkt.Kode_KK +"','"+ tbkkt.Status_KK_Terlisensi+"','"+ tbkkt.Jumlah_asesor+"')";

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

        public string Put (Tb_Kompetensi_Keahlian_Terlisensi tbkkt)
        {
            try
            {
                string query = @"UPDATE [dbo].[Tb_Kompetensi_Keahlian_Terlisensi] SET "
                            
                   + "       ,[Nomer_Lisensi] = '"+ tbkkt.Nomer_Lisensi +"'"
                   + "          ,[Kode_KK] = '"+ tbkkt.Kode_KK +"'"
                   + "          ,[Status_KK_Terlisensi] = '"+ tbkkt.Status_KK_Terlisensi +"'"
                   + "          ,[Jumlah_asesor] = '"+ tbkkt.Jumlah_asesor +"'"
                   + "     WHERE [Kode_KK_Terlisensi] = '"+ tbkkt.Kode_KK_Terlisensi+"' ";

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

        public string Delete (string kode_kk_terlisensi, string userLogin)
        {
            try
            {
                string query = @"UPDATE FROM [LSPdb].[dbo].[Tb_Kompetensi_Keahlian_Terlisensi] SET "
                    + "            ,isDelete = '" + 0 + "' "
                    + "           ,edited = '" + DateTime.Now.ToString() + "' "
                    + "            ,editor = '" + userLogin + "' "
                    + "            WHERE [Kode_KK_Terlisensi] = '" + kode_kk_terlisensi + "' ";

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

        [Route("api/KKTerlisensi/totaldata")]

        public HttpResponseMessage TotalData()
        {
            try
            {
                string csql = @"SELECT count(*) as total FROM [LSPdb].[dbo].[Tb_Kompetensi_Keahlian_Terlisensi]";

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