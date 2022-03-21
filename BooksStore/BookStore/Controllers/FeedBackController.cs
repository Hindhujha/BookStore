using BussinessLayer.Interface;
using CommonLayer.PostModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedBackController : ControllerBase
    {
        IFeedBackBL feedBackBL;
        public FeedBackController(IFeedBackBL feedBackBL)
        {
            this.feedBackBL = feedBackBL;

        }

        [HttpPost("feedBack")]
        public IActionResult AddFeedBack(FeedBackPostModel feedBackPost)
        {
            try
            {
                var result = this.feedBackBL.AddFeedBack(feedBackPost);
                if (result.Equals("FeedBack added Successfully"))
                {
                    return this.Ok(new { success = true, message = $"FeedBack added Successfully" });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = result });
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpGet("getallFeedBacks/{BookId}")]
        public IActionResult GetAllFeedBacks(int BookId)
        {  
            try
            {
                var result = this.feedBackBL.GetAllFeedBacks(BookId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = $"All FeedBacks from User Displayed Successfully ", response = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = $"FeedBack for this Book is not exist" });
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}
