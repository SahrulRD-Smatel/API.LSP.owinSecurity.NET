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
    public class TahunPelajaranController : ApiController
    {
        public HttpResponseMessage GetAll()
        {
            string query = @"
                    SELECT [Tahun_pelajaran]
                    FROM [LSPdb].[dbo].[Tb_Tahun_Pelajaran]";

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
                    SELECT [Tahun_pelajaran]
                    FROM [dbo].[Tb_Tahun_Pelajaran] where Tahun_Pelajaran = '"+ id +"' ";

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

        public string Post(Tb_Tahun_Pelajaran tbtp)
        {
            try
            {
                string query = @"
                        INSERT INTO [dbo].[Tb_Tahun_Pelajaran]
                              ([Tahun_pelajaran])
                        VALUES"
                    + "('" + tbtp.Tahun_pelajaran + "')";

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

        public string Put(Tb_Tahun_Pelajaran tbtp)
        {
            try
            {
                string query = @"UPDATE [dbo].[Tb_Tahun_Pelajaran] SET "
              + "    [Tahun_pelajaran] = '" + tbtp.Tahun_pelajaran + "'"
              + "    WHERE Tahun_pelajaran =''";

                return "Update Successfully";

            }
            catch (Exception err)
            {
                return err.Message;
            }
        }

        public string Delete(string tahun_pelajaran, string userLogin)
        {
            try
            {
                string query = @" UPDATE FROM [dbo].[Tb_Tahun_Pelajaran] SET "
                    + "     ,isDelete = '"+ 0 +"' "
                    + "           ,edited = '" + DateTime.Now.ToString() + "' "
                    + "            ,editor = '" + userLogin + "' "
                    + "            WHERE [Tahun_pelajaran] = '" + userLogin + "' ";

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

        [Route("api/TahunPelajaran/totaldata")]
        public HttpResponseMessage TotalData()
        {
            try
            {
                string csql = @"SELECT count(*) as total FROM [LSPdb].[dbo].[Tb_Tahun_Pelajaran]";

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