using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entity.Country
{
     
    public class CountryDetail
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Boolean IsActive { get; set; } 
       
    }
}
