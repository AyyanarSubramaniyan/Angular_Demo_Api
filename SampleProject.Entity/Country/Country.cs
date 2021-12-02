using System;
using System.Collections.Generic;

namespace Entity
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Boolean IsActive { get; set; }
        public ICollection<State> States { get; set; }
    }
}
