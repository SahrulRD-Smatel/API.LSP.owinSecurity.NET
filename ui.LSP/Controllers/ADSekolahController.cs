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
    public class ADSekolahController : ApiController
    {
        public HttpResponseMessage GetAll()
        {
            string query = @"
                SELECT [Username]
                    ,[Password]
                    ,[NPSN]
                FROM [dbo].[Tb_Admin_Sekolah]";

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
        SELECT [Username]
            ,[Password]
            ,[NPSN]
        FROM [dbo].[Tb_Admin_Sekolah] where Username = '"+ id +"' ";

            DataTable table = new DataTable();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LSPdb"].ConnectionString))
            {
                using (var cmd= new SqlCommand(query, conn))
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

        public string Post(Tb_Admin_Sekolah tbadsklh)
        {
            try
            {
                string query = @"
                    INSERT INTO [dbo].[Tb_Admin_Sekolah]
                          ([Username]
                          ,[Password]
                          ,[NPSN])
                    VALUES"
                + "('" + tbadsklh.Username + "','" + tbadsklh.Password + "','" + tbadsklh.NPSN + "') ";

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

        public string Put (Tb_Admin_Sekolah tbadsklh)
        {
            try
            {
                string query = @"UPDATE [dbo].[Tb_Admin_Sekolah] SET "
              +"      ,[Password] = '"+ tbadsklh.Password+"'"
              +"      ,[NPSN] = '"+ tbadsklh.NPSN+"'"
              +"  WHERE [Username] = '"+ tbadsklh.Username+"'";

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
            catch ( Exception err)
            {
                return err.Message;
            }
        }
        public string Delete (string username, string userLogin)
        {
            try
            {
                string query = @"UPDATE FROM [LSPdb].[dbo][Tb_Admin_Sekolah] SET "
                    + "            ,isDelete = '" + 0 + "' "
                    + "           ,edited = '" + DateTime.Now.ToString() + "' "
                    + "            ,editor = '" + userLogin + "' "
                    + "             WHERE [Username]= '" + username +"'";

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

        [Route("api/ADSekolah/totaldata")]
        public HttpResponseMessage TotalData()
        {
            try
            {
                string csql = @"SELECT count(*) as total FROM [LSPdb].[dbo].[Tb_Admin_Sekolah]";

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
