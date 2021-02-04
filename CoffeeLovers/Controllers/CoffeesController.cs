using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeeLovers.Models;
using CoffeeLovers.Properties;
using CoffeeLovers.Helpers;

namespace CoffeeLovers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeesController : ControllerBase
    {
        private readonly CoffeeLoversContext _context;

        public CoffeesController(CoffeeLoversContext context)
        {
            _context = context;
        }

        // GET: api/Coffees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TCoffee>>> GetTCoffees()
        {
            using(var con = _context)
            {
                return await con.TCoffees.Where(c => c.IsDeleted == false).Include("TComments")
                    .Include("TRatings").ToListAsync();
            }
        }

        // GET: api/Coffees/5
        [HttpGet("{id}")]
        public ActionResult<TCoffee> GetTCoffee(int id)
        {
            using (var con = _context)
            {
                var tCoffee = con.TCoffees
                    .Where(c => c.CoffeeId == id
                    && c.IsDeleted == false)
                    .Include("TComments")
                    .Include("TRatings")
                    .First();

                if (tCoffee == null)
                {
                    return NotFound();
                }

                return tCoffee;
            }
        }



        // POST: api/Coffees
        [HttpPost]
        public async Task<ActionResult<TCoffee>> PostTCoffee(Coffee newCoffee)
        {
            TCoffee coffee;
            //check validity, Name and Brand
            if (string.IsNullOrWhiteSpace(newCoffee.CoffeeName) ||
                string.IsNullOrWhiteSpace(newCoffee.CoffeeBrand))
            {
                //return validation failure
                ValidationProblemDetails vpd = new ValidationProblemDetails();
                vpd.Detail = "Coffee Name and Coffee Brand must be supplied";
                return ValidationProblem(vpd);
            }
            else
            {
                coffee = new TCoffee(newCoffee.CoffeeBrand, newCoffee.CoffeeName);
            }

            try
            {
                using (var con = _context)
                {
                    //check for dupes
                    var dupes = await con.TCoffees.Where(c => c.CoffeeName == coffee.CoffeeName && c.CoffeeBrand == coffee.CoffeeBrand).ToListAsync();

                    if (dupes != null && dupes.Any())
                    {
                        //return duplication failure
                        ValidationProblemDetails vpd = new ValidationProblemDetails();
                        vpd.Detail = "Duplicate Coffee";
                        return ValidationProblem(vpd);
                    }
                    con.TCoffees.Add(coffee);
                    await con.SaveChangesAsync();
                    return CreatedAtAction("GetTCoffee", new { id = coffee.CoffeeId }, coffee);
                }
            }
            catch (Exception)
            {
                return Problem(Resources.ErrorSavingNewCoffee, $"{newCoffee.CoffeeBrand} {newCoffee.CoffeeName} ", null, Resources.ErrorSavingCoffeeTitle, "Coffee");
            }

        }

        // DELETE: api/Coffees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTCoffee(int id)
        {
            //mark coffee as deleted. 
            using (var con = _context)
            {
                var tCoffee = await con.TCoffees.FindAsync(id);
                if (tCoffee == null)
                {
                    return NotFound();
                }

                tCoffee.IsDeleted = true;
                con.TCoffees.Update(tCoffee);
                await con.SaveChangesAsync();

                return NoContent();
            }
        }
    }
}
