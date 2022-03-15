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
   public class FeedBackRL:IFeedBackRL
    {
        private SqlConnection sqlConnection;

        public FeedBackRL(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public string AddFeedBack(FeedBackPostModel feedBackPost)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("BookStore"));

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("sp_AddFeedBack", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@userId", feedBackPost.userId);
                    cmd.Parameters.AddWithValue("@BookId", feedBackPost.BookId);
                    cmd.Parameters.AddWithValue("@FeedBackFromUserName", feedBackPost.FeedBackFromUserName);
                    cmd.Parameters.AddWithValue("@Comments", feedBackPost.Comments);
                    cmd.Parameters.AddWithValue("@Ratings", feedBackPost.Ratings);
                    
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    return "FeedBack added Successfully";

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

        public List<FeedBackModel> GetAllFeedBacks(int BookId)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("BookStore"));
            try
            {
                using (sqlConnection)
                {
                    List<FeedBackModel> order = new List<FeedBackModel>();
                    SqlCommand cmd = new SqlCommand("sp_GetAllFeedBacks", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", BookId);
                    sqlConnection.Open();
                    SqlDataReader fetch = cmd.ExecuteReader();
                    if (fetch.HasRows)
                    {
                        while (fetch.Read())
                        {
                            FeedBackModel model = new FeedBackModel();
                           // BookPostModel bookModel = new BookPostModel();
                            model.FeedbackId = Convert.ToInt32(fetch["FeedbackId"]);
                            model.userId = Convert.ToInt32(fetch["userId"]);
                            model.BookId= Convert.ToInt32(fetch["BookId"]);
                            //bookModel.BookName = fetch["BookName"].ToString();
                            //bookModel.AuthorName = fetch["AuthorName"].ToString();
                            //bookModel.DiscountPrice = Convert.ToInt32(fetch["DiscountPrice"]);
                            //bookModel.OriginalPrice = Convert.ToInt32(fetch["OriginalPrice"]);
                            //bookModel.BookDescription = fetch["BookDescription"].ToString();
                            //bookModel.Rating = Convert.ToInt32(fetch["Rating"]);
                            //bookModel.Reviewer = Convert.ToInt32(fetch["Reviewer"]);
                            //bookModel.Image = fetch["Image"].ToString();
                            //bookModel.BookCount = Convert.ToInt32(fetch["BookCount"]);                          
                            model.FeedBackFromUserName = fetch["FeedBackFromUserName"].ToString();
                            model.Comments = fetch["Comments"].ToString();
                            model.Ratings= Convert.ToInt32(fetch["Ratings"]);
                            //model.bookModel = bookModel;
                            order.Add(model);

                        }
                        return order;
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

