using DataLibraryProject;
using Entity.State;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using ApplicationLibrary.Model;

namespace ApplicationLibrary.Service
{
    public interface IStateRepository
    {
        void Add(StateDetail c);
        void Update(StateDetail c);
        void Remove(int Id);
        IEnumerable<StateModel> GetStateDetails();
        StateModel FindById(int id);
    }

    public class StateRepository : IStateRepository
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;
        public StateRepository(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public void Add(StateDetail c)
        {
            _context.StatesDetails.Add(c);
            _context.SaveChanges();
        }

        public StateModel FindById(int id)
        {
           // var results = (from r in _context.StatesDetails where r.Id == id select r).FirstOrDefault();

            var results = _mapper.Map<StateModel>(_context.StatesDetails.Find(id));
            return results;
        }

        public IEnumerable<StateModel> GetStateDetails()
        {            
            return _mapper.Map<IEnumerable<StateModel>>(_context.StatesDetails);
        }

        public void Remove(int Id)
        {
            StateDetail obj = _context.StatesDetails.Find(Id);
            _context.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(StateDetail c)
        {
            _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
