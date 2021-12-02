using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLibraryProject;
using Entity.Country;
using ApplicationLibrary.Service;
using Entity;
using ApplicationLibrary;
using AutoMapper;
using ApplicationLibrary.Model;
using ApplicationLibrary.Validation;
using FluentValidation;
using FluentValidation.Results;

namespace API_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryDetailsController : ControllerBase
    {
        private ICountryRepository _context;

        public CountryDetailsController(ICountryRepository context)
        {
            _context = context;
        }

        // GET: api/CountryDetails
        [HttpGet]
        public IEnumerable<CountryModel> GetCountryDetails()
        {
            return _context.GetCountryDetails();
            //  return _context.GetCountryDetails();
        }

        // GET: api/CountryDetails/5
        [HttpGet("{id}")]
        public ActionResult<CountryModel> GetCountryDetail(int id)
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
        public IActionResult PutCountryDetail(int id, CountryDetail countryDetail)
        {
            if (id != countryDetail.Id)
            {
                return NotFound();
            }

            try
            {
                CountryValidation validator = new CountryValidation();
                ValidationResult results = validator.Validate(countryDetail);

                if (!results.IsValid)
                    validator.ValidateAndThrow(countryDetail);
                else                     
                _context.Update(countryDetail);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryDetailExists(id))
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

        // POST: api/CountryDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public CountryDetail PostCountryDetail(CountryDetail countryDetail)
        {
            CountryValidation validator = new CountryValidation();
            ValidationResult results = validator.Validate(countryDetail);          

            if (!results.IsValid)            
                validator.ValidateAndThrow(countryDetail);           
            else           
                _context.Add(countryDetail);         

            return countryDetail;
        }

        // DELETE: api/CountryDetails/5
        [HttpDelete("{id}")]
        public IEnumerable<CountryModel> DeleteCountryDetail(int id)
        {
            _context.Remove(id);

            //  var countryDetail = _context.GetCountryDetails();
            return _context.GetCountryDetails();
        }

        private bool CountryDetailExists(int id)
        {
            var countryDetail = _context.FindById(id);
            if (countryDetail == null)
                return false;
            else
                return true;

        }
    }
}
