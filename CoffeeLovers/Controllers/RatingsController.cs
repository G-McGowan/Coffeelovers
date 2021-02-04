using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeeLovers.Models;
using CoffeeLovers.Helpers;
using CoffeeLovers.Properties;

namespace CoffeeLovers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly CoffeeLoversContext _context;

        public RatingsController(CoffeeLoversContext context)
        {
            _context = context;
        }

        // GET: api/Ratings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TRating>>> GetTRatings()
        {
            using (var con = _context)
            {
                return await _context.TRatings.ToListAsync();
            }
        }


        // PUT: api/Ratings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTRating(int id, Rating tRating)
        {
            if (id != tRating.RatingID)
            {
                return BadRequest();
            }

            if (tRating.RatingScore < 1 || tRating.RatingScore > 5)
            {
                ValidationProblemDetails vpd = new ValidationProblemDetails();
                vpd.Detail = Resources.RatingOutOfRange;
                return ValidationProblem(vpd);

            }

            try
            {
                using (var con = _context)
                {
                    //check for record
                    var existingRating = con.TRatings.FirstOrDefault(x => x.RatingId == tRating.RatingID);
                    if (existingRating == null)
                    {
                        throw new DbUpdateConcurrencyException(Resources.NoRatingFoundInDB);
                    }
                    existingRating.CoffeeId = tRating.CoffeeId;
                    existingRating.Rating = (byte)tRating.RatingScore;


                    con.Entry(existingRating).State = EntityState.Modified;
                    await con.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Problem("Error updating Rating", $"id:{id}, Rating:ID- {tRating.RatingID}, Coffee- {tRating.CoffeeId}, {e.Message}", null, Resources.RatingUpdateError, null);
            }

            //204
            return NoContent();
        }


        private bool TRatingExists(int id)
        {
            using (var con = _context)
            {
                return con.TRatings.Where(x => x.RatingId == id).Any();
            }
        }
    }
}
