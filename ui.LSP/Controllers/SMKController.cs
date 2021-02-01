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
    public class SMKController : ApiController
    {
        public HttpResponseMessage GetAll()
        {

            string query = @"
SELECT  [NPSN]
      ,[Kode_Kabupaten]
      ,[Nama_Sekolah]
      ,[Status_Sekolah]
      ,[Status_LSP]
      ,[Kode_KK]
  FROM [LSPdb].[dbo].[Tb_SMK]
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
                SELECT  [NPSN]
                    ,[Kode_Kabupaten]
                    ,[Nama_Sekolah]
                    ,[Status_Sekolah]
                    ,[Status_LSP]
                    ,[Kode_KK]
                      FROM [LSPdb].[dbo].[Tb_SMK] where  NPSN = '" + id + "'";

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

        public string Post(Tb_SMK tbsmk)
        {
            try
            {
                //string query = @"Insert Into Anggota([Type_Insurance] ,[Perusahaan] ,[Telp] ,[Fax] ,[Email] ,[CP] ,[KuasaKhusus1] ,[KuasaKhusus2] ,[KuasaKhusus3])"
                //+ "values ('" + ang.Type_Insurance + "' ,'" + ang.Perusahaan + "','" + ang.Telp + "','" + ang.Fax + "','" + ang.Email + "','" + ang.CP + "','" + ang.KuasaKhusus1 + "','" + ang.KuasaKhusus2 + "','" + ang.KuasaKhusus3 + "' )";

                string query = @"
           INSERT INTO [LSPdb].[dbo].[Tb_SMK]
           ([NPSN]
           ,[Kode_Kabupaten]
           ,[Nama_Sekolah]
           ,[Status_Sekolah]
           ,[Status_LSP]
           ,[Kode_KK])
            VALUES "
        + " ('" + tbsmk.NPSN + "','" + tbsmk.Kode_Kabupaten + "','" + tbsmk.Nama_Sekolah + "','" + tbsmk.Status_Sekolah + "','" + tbsmk.Status_LSP + "','" + tbsmk.Kode_KK + "')";


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

        public string Put(Tb_SMK tbsmk)
        {
            try
            {
                //string query = @"Update Anggota set Type_Insurance = '" + ang.Type_Insurance + "' ,Perusahaan ='" + ang.Perusahaan + "', Telp = '" + ang.Telp + "'"
                //+ ", Fax = '" + ang.Telp + "'"
                //+ ", Email = '" + ang.Telp + "'"
                //+ ", CP = '" + ang.Telp + "'"
                //+ ", KuasaKhusus1 = '" + ang.Telp + "'"
                //+ ", KuasaKhusus2 = '" + ang.Telp + "'"
                //+ ", KuasaKhusus3 = '" + ang.Telp + "'"
                //+ " where idAnggota = '" + ang.idAnggota + "'";


                string query = @"UPDATE [LSPdb].[dbo].[Tb_SMK] SET   "
               + "    ,[Kode_Kabupaten] =  '" + tbsmk.Kode_Kabupaten + "'"
               + "    ,[Nama_Sekolah] =     '" + tbsmk.Nama_Sekolah + "'"
               + "    ,[Status_Sekolah] =  '" + tbsmk.Status_Sekolah + "'"
               + "    ,[Status_LSP] =      '" + tbsmk.Status_LSP + "'"
               + "    ,[Kode_KK] =    '" + tbsmk.Kode_KK + "'"
               + "     WHERE [NPSN] = '" + tbsmk.NPSN + "' ";


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

        public string Delete(string npsn, string userLogin)
        {
            try
            {
                //string query = @"Delete from Anggota where idAnggota ='" + idAnggota + @"'";

                string query = @"UPDATE FROM [LSPdb].[dbo].[Tb_SMK] SET "
                    + "            ,isDelete = '" + 0 + "' "
                    + "           ,edited = '" + DateTime.Now.ToString() + "' "
                    + "            ,editor = '" + userLogin + "' "
                    + "            WHERE [Nomer_Lisensi] = '" + userLogin + "' ";

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

        [Route("api/SMK/totaldata")]
        public HttpResponseMessage TotalData()
        {
            try
            {
                string csql = @"SELECT count(*) as total  FROM [LSPdb].[dbo].[Tb_SMK]";

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