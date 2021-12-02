using DataLibraryProject;
using System.Collections.Generic;
using AutoMapper;
using ApplicationLibrary.Model;
using SampleProject.Application.Model;
using Entity;
using ApplicationLibrary.Validation;
using FluentValidation.Results;
using FluentValidation;

namespace ApplicationLibrary.Service
{
    public interface IStateRepository
    {
        void Add(StateMasterModel c);
        void Update(StateMasterModel c);
        void Remove(int Id);
        IEnumerable<StateReadModel> GetStateDetails();
        StateReadModel FindById(int id);
    }

    public class StateRepository : IStateRepository
    {
        private readonly SampleProjectDbContext _context;
        private readonly IMapper _mapper;
        StateValidation _validator = new StateValidation();
        public StateRepository(SampleProjectDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Add(StateMasterModel c)
        {
            ValidationResult results = _validator.Validate(c);

            if (!results.IsValid)
                _validator.ValidateAndThrow(c);
            else
                _context.StatesDetails.Add(_mapper.Map<State>(c));
            _context.SaveChanges();


        }
        public void Update(StateMasterModel c)
        {
            ValidationResult results = _validator.Validate(c);

            if (!results.IsValid)
                _validator.ValidateAndThrow(c);
            else
                _context.Entry(_mapper.Map<State>(c)).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _context.SaveChanges();
        }
        public StateReadModel FindById(int id)
        {
            var results = _mapper.Map<StateReadModel>(_context.StatesDetails.Find(id));
            return results;
        }
        public IEnumerable<StateReadModel> GetStateDetails()
        { 
            IEnumerable<StateReadModel> k = _mapper.Map<IEnumerable<StateReadModel>>(_context.StatesDetails);
            foreach (StateReadModel s in k)
            {              
                s.CountryName = _context.CountryDetails.Find(s.CountryId).Name;                
            }
            return k;
        }
        public void Remove(int Id)
        {
            _context.Remove(_context.StatesDetails.Find(Id));
            _context.SaveChanges();
        }

    }
}
