using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Application.Model
{
    public class StateMasterModel
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }
    }
}
