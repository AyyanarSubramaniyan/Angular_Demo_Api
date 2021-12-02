using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLibrary.Model
{
    public class StateModel
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }
    }


}
