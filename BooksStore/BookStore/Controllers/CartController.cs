using BussinessLayer.Interface;
using CommonLayer.PostModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {

        ICartBL cartBL;
        public CartController(ICartBL cartBL)
        {
            this.cartBL = cartBL;

        }

        [HttpPost("addBooksInCart")]
        public IActionResult AddBookToCart(CartPostModel cartBook)
        {
            try
            {
                var result = this.cartBL.AddBookToCart(cartBook);
                if (result.Equals("book added in cart successfully"))
                {
                    return this.Ok(new { success = true, message = $"Book added in Cart Successfully " });
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

        [HttpPut("updateCart/{CartId}")]
        public IActionResult UpdateCart(int CartId, int Quantity)
        {
            try
            {
                var result = this.cartBL.UpdateCart(CartId, Quantity);
                if (result.Equals(true))
                {
                    return this.Ok(new { success = true, message = $"Cart updated Successfully ", response = Quantity});
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

        [HttpDelete("deleteCart/{CartId}")]
        public IActionResult DeleteCart(int CartId)
        {
            try
            {
                var result = this.cartBL.DeleteCart(CartId);
                if (result.Equals("Book Deleted in Cart Successfully"))
                {
                    return this.Ok(new { success = true, message = $"Book in Cart deleted Successfully " });
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

        [HttpGet("getallbook/{userId}")]
        public IActionResult GetAllBooksinCart(int userId)
        {
            try
            {
                var result = this.cartBL.GetAllBooksinCart(userId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = $"All Books Displayed in the cart Successfully ", response = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = $"Books are not there " });
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}
