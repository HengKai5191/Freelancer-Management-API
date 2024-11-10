using Freelancer_Management_API.DBContext;
using Freelancer_Management_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Freelancer_Management_API.Controllers
{
    public class FreeLancersController : Controller
    {
        private readonly FreeLancerDBContext _context;

        public FreeLancersController(FreeLancerDBContext context)
        {
            this._context = context;
        }

        #region Validation&Utilities Functions

        public bool isvalidFreeLancer(MC_FreeLancer freelancer) {

            return !(freelancer.FL_Username == null || freelancer.FL_Email == null || freelancer.FL_PhoneNumber == null);
        }
        private bool FreelancerExists(int PN_FL_Id)
        {
            return _context.Freelancers.Any(e => e.FL_Id == PN_FL_Id);
        }
        #endregion

        #region selection
        // GET: api/freelancers
        [HttpGet("GetFreeLancer")]
        public ActionResult<IEnumerable<MC_FreeLancer>> GetFreelancers()
        {

            return _context.Freelancers.ToList();
        }

        // GET: api/freelancers/5
        [HttpGet("GetFreeLancer/{PN_FL_Id}")]
        public async Task<ActionResult<MC_FreeLancer>> GetFreelancer(int PN_FL_Id)
        {
            var freelancer = await _context.Freelancers.FindAsync(PN_FL_Id);

            if (freelancer == null)
            {
                return NotFound();
            }

            return freelancer;
        }
        #endregion

        #region Insert
        // POST: api/freelancers
        [HttpPost("InsertFreeLancer")]
        public async Task<ActionResult<MC_FreeLancer>> CreateFreelancer([FromBody] MC_FreeLancer freelancer)
        {
            if (!isvalidFreeLancer(freelancer))
            {
                return BadRequest();
            }
            _context.Freelancers.Add(freelancer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region Update
        // PUT: api/freelancers/5
        [HttpPut("UpdateFreeLancer/{PN_FL_Id}")]
        public async Task<IActionResult> UpdateFreelancer(int PN_FL_Id, [FromBody] MC_FreeLancer freelancer)
        {
            if (PN_FL_Id != freelancer.FL_Id && !isvalidFreeLancer(freelancer))
            {
                return BadRequest();
            }

            _context.Entry(freelancer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FreelancerExists(PN_FL_Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        #endregion  

        #region deletion
        // DELETE: api/freelancers/5
        [HttpDelete("deleteFreeLancer/{PN_FL_Id}")]
        public async Task<IActionResult> DeleteFreelancer(int PN_FL_Id)
        {
            var freelancer = await _context.Freelancers.FindAsync(PN_FL_Id);
            if (freelancer == null)
            {
                return NotFound();
            }

            _context.Freelancers.Remove(freelancer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

    }
}