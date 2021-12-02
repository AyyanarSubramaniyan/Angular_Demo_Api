using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entity;
using ApplicationLibrary.Service;
using ApplicationLibrary.Model;
using ApplicationLibrary.Validation;
using FluentValidation;
using FluentValidation.Results;
using SampleProject.Application.Model;

namespace API_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryRepository _context;
        public CountryController(ICountryRepository context)
        {
            _context = context;
        }
        // GET: api/CountryDetails
        [HttpGet]
        public IEnumerable<CountryReadModel> GetCountryDetails()
        {
            return _context.GetCountryDetails();            
        }
        // GET: api/CountryDetails/5
        [HttpGet("{id}")]
        public ActionResult<CountryReadModel> GetCountryDetail(int id)
        {
            var countryDetail = _context.FindById(id);

            if (countryDetail == null)
            {
                return NotFound();
            }
            return countryDetail;
        }

        // PUT: api/CountryDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutCountryDetail(int id, CountryMasterModel countryDetail)
        {
            if (id != countryDetail.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(countryDetail);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryDetailExists(id))               
                    return NotFound();                
                else                
                    throw;               
            }
            return NoContent();
        }

        // POST: api/CountryDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public CountryMasterModel PostCountryDetail(CountryMasterModel countryDetail)
        {
            _context.Add(countryDetail);
            return countryDetail;
        }
        // DELETE: api/CountryDetails/5
        [HttpDelete("{id}")]
        public IEnumerable<CountryReadModel> DeleteCountryDetail(int id)
        {
            _context.Remove(id);
            return _context.GetCountryDetails();
        }
        private bool CountryDetailExists(int id)
        { 
            if (_context.FindById(id) == null)
                return false;
            else
                return true;
        }
    }
}
