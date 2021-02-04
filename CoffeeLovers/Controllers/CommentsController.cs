using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeeLovers.Models;
using CoffeeLovers.Helpers;
using System.Text;
using CoffeeLovers.Properties;

namespace CoffeeLovers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CoffeeLoversContext _context;

        public CommentsController(CoffeeLoversContext context)
        {
            _context = context;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TComment>>> GetTComments()
        {
            using (var con = _context)
            {
                return await con.TComments.ToListAsync();
            }
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TComment>> GetTComment(int id)
        {
            using (var con = _context)
            {

                var tComment = await con.TComments.FindAsync(id);

                if (tComment == null)
                {
                    return NotFound();
                }

                return tComment;
            }
        }


        // POST: api/Comments
        [HttpPost]
        public async Task<ActionResult<TComment>> PostTComment(CommentRating commentRating)
        {

            //validate comment and rating.
            var errStr = new StringBuilder();
            if (string.IsNullOrWhiteSpace(commentRating.Comment))
            {
                errStr.Append(Resources.BlankComment);
            }
            else if (!string.IsNullOrWhiteSpace(commentRating.Comment) && commentRating.Comment.Length > 200)
            {
                errStr.Append(Resources.CommentTooLong);

            }
            else if (commentRating.Rating < 1 || commentRating.Rating > 5)
            {
                errStr.Append(Resources.RatingOutOfRange);
            }


            try
            {
                using (var conn = _context)
                {
                    //check coffee exists
                    var coffee = await conn.TCoffees.FirstAsync(x => x.CoffeeId == commentRating.CoffeeID);
                    if (coffee == null)
                    {
                        errStr.Append(Resources.NoCoffeeFound);
                    }

                    //send error back
                    if (!string.IsNullOrEmpty(errStr.ToString()))
                    {
                        ValidationProblemDetails vpd = new ValidationProblemDetails();
                        vpd.Detail = errStr.ToString();
                        return ValidationProblem(vpd);
                    }
                    var newRating = new TRating(commentRating.Rating, commentRating.CoffeeID);
                    conn.TRatings.Add(newRating);
                    await conn.SaveChangesAsync();
                    var newComment = new TComment(commentRating.Comment, commentRating.CoffeeID);
                    newComment.RatingId = newRating.RatingId;
                    conn.TComments.Add(newComment);
                    await conn.SaveChangesAsync();
                    return CreatedAtAction("GetTComment", new { id = newComment.CommentId }, newComment);
                }
            }
            catch (Exception e)
            {
                return Problem(Resources.ErrorSavingComment, $"Comment: {commentRating.Comment}. Rating: {commentRating.Rating}. CoffeeID: {commentRating.CoffeeID}. {e.Message}", null, Resources.ErrorSavingCommentTitle, "Comment");
            }

        }
    }
}
