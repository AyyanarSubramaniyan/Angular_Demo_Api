using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLibraryProject;
using Entity.State;
using ApplicationLibrary.Service;
using ApplicationLibrary.Model;
using ApplicationLibrary.Validation;
using FluentValidation.Results;
using FluentValidation;

namespace API_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateDetailsController : ControllerBase
    {
        private IStateRepository _context;

        public StateDetailsController(IStateRepository context)
        {
            _context = context;
        }

        // GET: api/StateDetails
        [HttpGet]
        public IEnumerable<StateModel> GetStatesDetails()
        {
            return _context.GetStateDetails();
        }

        // GET: api/StateDetails/5
        [HttpGet("{id}")]
        public ActionResult<StateModel> GetStateDetail(int id)
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
        public IActionResult PutStateDetail(int id, StateDetail stateDetail)
        {
            if (id != stateDetail.Id)
            {
                return BadRequest();
            }

            try
            {
                StateValidation validator = new StateValidation();
                ValidationResult results = validator.Validate(stateDetail);

                if (!results.IsValid)
                    validator.ValidateAndThrow(stateDetail);
                else                   
                _context.Update(stateDetail);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateDetailExists(id))
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

        // POST: api/StateDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public StateDetail PostStateDetail(StateDetail stateDetail)
        {
            StateValidation validator = new StateValidation();
            ValidationResult results = validator.Validate(stateDetail);

            if (!results.IsValid)
                validator.ValidateAndThrow(stateDetail);
            else               
            _context.Add(stateDetail);

            return stateDetail;
        }

        // DELETE: api/StateDetails/5
        [HttpDelete("{id}")]
        public IEnumerable<StateModel> DeleteStateDetail(int id)
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
