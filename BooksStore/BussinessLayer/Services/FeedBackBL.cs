using BussinessLayer.Interface;
using CommonLayer.PostModel;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
  public  class FeedBackBL:IFeedBackBL
    {

        IFeedBackRL feedBackRL;

        public FeedBackBL(IFeedBackRL feedBackRL)
        {
            this.feedBackRL = feedBackRL;
        }

        public string AddFeedBack(FeedBackPostModel feedBackPost)
        {
            try
            {
                return feedBackRL.AddFeedBack(feedBackPost);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<FeedBackModel> GetAllFeedBacks(int BookId)
        {
            try
            {
                return feedBackRL.GetAllFeedBacks(BookId);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
