using DataLibraryProject;
using Entity;
 
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ApplicationLibrary.Model;
using AutoMapper;
using SampleProject.Application.Model;
using ApplicationLibrary.Validation;
using FluentValidation.Results;
using FluentValidation;

namespace ApplicationLibrary.Service
{
    public interface ICountryRepository
    {
        void Add(CountryMasterModel c);
        void Update(CountryMasterModel c);
        void Remove(int Id);
        IEnumerable<CountryReadModel> GetCountryDetails();
        CountryReadModel FindById(int id);
    }
    public class CountryRepository : ICountryRepository
    {
        private readonly SampleProjectDbContext _context;
        private readonly IMapper _mapper;
        CountryValidation _validator = new CountryValidation();
        public CountryRepository(SampleProjectDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;            
        }       
        public void Add(CountryMasterModel c)
        {           
            ValidationResult results = _validator.Validate(c);

            if (!results.IsValid)
                _validator.ValidateAndThrow(c);
            else
                _context.CountryDetails.Add(_mapper.Map<Country>(c));

            _context.SaveChanges();
        }
        public void Update(CountryMasterModel c)
        {           
            ValidationResult results = _validator.Validate(c);

            if (!results.IsValid)
                _validator.ValidateAndThrow(c);
            else
                _context.Entry(_mapper.Map<Country>(c)).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _context.SaveChanges();
        }
        public CountryReadModel FindById(int id)
        {            
            var results = _mapper.Map<CountryReadModel>(_context.CountryDetails.Find(id));
            return results;
        }
        public IEnumerable<CountryReadModel> GetCountryDetails()
        {
            return _mapper.Map<IEnumerable<CountryReadModel>>(_context.CountryDetails);
        }
        public void Remove(int Id)
        {           
            _context.Remove(_context.CountryDetails.Find(Id));
            _context.SaveChanges();
        }
    }
}
