using System;
using System.Collections.Generic;

namespace Entity
{
    public class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsPublic { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
