using CommonLayer.PostModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

        public string Adminlogin(string MailId, string Password)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("BookStore"));

            try
            {
                using (sqlConnection)
                {
                  
                    SqlCommand cmd = new SqlCommand("sp_LoginAdmin", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MailId", MailId);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                          MailId = reader["MailId"].ToString();
                          Password = reader["Password"].ToString();
                        }
                        string token = GenerateToken(MailId);
                        return token;
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

        private static string GenerateToken(string MailId)
        {
            if (MailId == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("MailId", MailId),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string AdminsBook(AdminsBookPostModel adminBookPost)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("BookStore"));

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("sp_AdminsBook", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AdminId", adminBookPost.AdminId);
                    cmd.Parameters.AddWithValue("@BookName", adminBookPost.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", adminBookPost.AuthorName);
                    cmd.Parameters.AddWithValue("@DiscountPrice", adminBookPost.DiscountPrice);
                    cmd.Parameters.AddWithValue("@OriginalPrice", adminBookPost.OriginalPrice);
                    cmd.Parameters.AddWithValue("@BookDescription", adminBookPost.BookDescription);
                    cmd.Parameters.AddWithValue("@Rating ", adminBookPost.Rating);
                    cmd.Parameters.AddWithValue("@Reviewer", adminBookPost.Reviewer);
                    cmd.Parameters.AddWithValue("@Image", adminBookPost.Image);
                    cmd.Parameters.AddWithValue("@BookCount", adminBookPost.BookCount);


                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    return "book added successfully";

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

        public bool UpdateAdminsBook(int AdminsBookId, AdminsBookPostModel adminBook)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("BookStore"));

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdateAdminsBooks", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AdminsBookId", AdminsBookId);
                    cmd.Parameters.AddWithValue("@AdminId", adminBook.AdminId);
                    cmd.Parameters.AddWithValue("@BookName", adminBook.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", adminBook.AuthorName);
                    cmd.Parameters.AddWithValue("@DiscountPrice", adminBook.DiscountPrice);
                    cmd.Parameters.AddWithValue("@OriginalPrice", adminBook.OriginalPrice);
                    cmd.Parameters.AddWithValue("@BookDescription", adminBook.BookDescription);
                    cmd.Parameters.AddWithValue("@Rating", adminBook.Rating);
                    cmd.Parameters.AddWithValue("@Image", adminBook.Image);
                    cmd.Parameters.AddWithValue("@Reviewer", adminBook.Reviewer);
                    cmd.Parameters.AddWithValue("@BookCount", adminBook.BookCount);
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
        public List<AdminsBookModel> GetAdminsBooks()
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("BookStore"));
            try
            {
                using (sqlConnection)
                {
                    List<AdminsBookModel> book = new List<AdminsBookModel>();
                    SqlCommand cmd = new SqlCommand("sp_GetAllAdminsBooks", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader fetch = cmd.ExecuteReader();
                    if (fetch.HasRows)
                    {
                        while (fetch.Read())
                        {
                            AdminsBookModel data = new AdminsBookModel();
                            data.AdminsBookId = Convert.ToInt32(fetch["AdminsBookId"]);
                            data.AdminId = Convert.ToInt32(fetch["AdminId"]);
                            data.BookName = fetch["BookName"].ToString();
                            data.AuthorName = fetch["AuthorName"].ToString();
                            data.DiscountPrice = Convert.ToInt32(fetch["DiscountPrice"]);
                            data.OriginalPrice = Convert.ToInt32(fetch["OriginalPrice"]);
                            data.BookDescription = fetch["BookDescription"].ToString();
                            data.Rating = Convert.ToInt32(fetch["Rating"]);
                            data.Reviewer = Convert.ToInt32(fetch["Reviewer"]);
                            data.Image = fetch["Image"].ToString();
                            data.BookCount = Convert.ToInt32(fetch["BookCount"]);
                            book.Add(data);
                        }
                        return book;
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

        public bool DeleteAdminsBook(int AdminsBookId)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("BookStore"));

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("sp_DeleteAdminsBook", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AdminBookId", AdminsBookId);
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
    }
}
