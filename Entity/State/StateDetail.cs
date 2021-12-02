using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Entity.State
{
 
    public class StateDetail
    {
        [Key]
        public int Id { get; set; }

        public int CountryId { get; set; }

        public string StateName { get; set; }

        public Boolean IsActive { get; set; }
                  
    }

}
