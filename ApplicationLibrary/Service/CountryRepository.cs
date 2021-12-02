using DataLibraryProject;
using Entity;
using Entity.Country;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ApplicationLibrary.Model;
using AutoMapper;

namespace ApplicationLibrary.Service
{
    public interface ICountryRepository
    {
        void Add(CountryDetail c);
        void Update(CountryDetail c);
        void Remove(int Id);
        IEnumerable<CountryModel> GetCountryDetails();
        CountryModel FindById(int id);
    }
    public class CountryRepository : ICountryRepository
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;
        public CountryRepository(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       
        public void Add(CountryDetail c)
        {
            _context.CountryDetails.Add(c);
            _context.SaveChanges();
        }

        public void Update(CountryDetail c)
        {
            _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public CountryModel FindById(int id)
        {
           // var results = (from r in _context.CountryDetails where r.Id == id select r).FirstOrDefault();
            var results = _mapper.Map<CountryModel>(_context.CountryDetails.Find(id));
            return results;
        }

        public IEnumerable<CountryModel> GetCountryDetails()
        {
            return _mapper.Map<IEnumerable<CountryModel>>(_context.CountryDetails);
        }

        public void Remove(int Id)
        {
            CountryDetail obj = _context.CountryDetails.Find(Id);
            _context.Remove(obj);
            _context.SaveChanges();

        }
    }
}
