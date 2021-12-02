using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entity;
using ApplicationLibrary.Service;
using ApplicationLibrary.Model;
using ApplicationLibrary.Validation;
using FluentValidation.Results;
using FluentValidation;
using SampleProject.Application.Model;

namespace API_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private IStateRepository _context;
        public StateController(IStateRepository context)
        {
            _context = context;
        }
        // GET: api/StateDetails
        [HttpGet]
        public IEnumerable<StateReadModel> GetStatesDetails()
        {
            return _context.GetStateDetails();
        }
        // GET: api/StateDetails/5
        [HttpGet("{id}")]
        public ActionResult<StateReadModel> GetStateDetail(int id)
        {
            var stateDetail = _context.FindById(id);

            if (stateDetail == null)
            {
                return NotFound();
            }
            return stateDetail;
        }
        // PUT: api/StateDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutStateDetail(int id, StateMasterModel stateDetail)
        {
            if (id != stateDetail.Id)
            {
                return BadRequest();
            }

            try
            {                
                _context.Update(stateDetail);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateDetailExists(id))                
                    return NotFound();              
                else                
                    throw;                
            }
            return NoContent();
        }
        // POST: api/StateDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public StateMasterModel PostStateDetail(StateMasterModel stateDetail)
        {            
            _context.Add(stateDetail);
            return stateDetail;
        }
        // DELETE: api/StateDetails/5
        [HttpDelete("{id}")]
        public IEnumerable<StateReadModel> DeleteStateDetail(int id)
        {
            _context.Remove(id);
            var stateDetail = _context.GetStateDetails();
            return stateDetail;
        }
        private bool StateDetailExists(int id)
        {
            var stateDetails = _context.FindById(id);
            if (stateDetails == null)
                return false;
            else
                return true;
        }
    }
}
