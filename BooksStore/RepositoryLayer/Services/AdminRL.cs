using CommonLayer.PostModel;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
  public class AdminRL:IAdminRL
    {
        private SqlConnection sqlConnection;

        public AdminRL(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       
        public string AddAdmin(AdminPostModel adminPost)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("BookStore"));
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("sp_AddAdmin", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AdminName", adminPost.AdminName);
                    cmd.Parameters.AddWithValue("@MailId", adminPost.MailId);
                    cmd.Parameters.AddWithValue("@Password", adminPost.Password);              
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    return "Admin Added  successfully";

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

       
        public bool UpdateAdmin(int AdminId, AdminPostModel adminPost)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("BookStore"));
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdateAdmin", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AdminId",AdminId);
                    cmd.Parameters.AddWithValue("@AdminName", adminPost.AdminName);
                    cmd.Parameters.AddWithValue("@MailId", adminPost.MailId);
                    cmd.Parameters.AddWithValue("@Password", adminPost.Password);
                    sqlConnection.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result != 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public List<AdminModel> GetAdminDetails()
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("BookStore"));
            try
            {
                using (sqlConnection)
                {
                    List<AdminModel> model = new List<AdminModel>();
                    SqlCommand cmd = new SqlCommand("sp_GetAdminDetails", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader fetch = cmd.ExecuteReader();
                    if (fetch.HasRows)
                    {
                        while (fetch.Read())
                        {
                            AdminModel admin = new AdminModel();
                            admin.AdminId = Convert.ToInt32(fetch["AdminId"]);                       
                            admin.AdminName = fetch["AdminName"].ToString();
                            admin.MailId = fetch["MailId"].ToString();
                            admin.Password = fetch["Password"].ToString();              
                            model.Add(admin);
                        }
                        return model;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

    }
}
