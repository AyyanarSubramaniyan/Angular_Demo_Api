using ApplicationLibrary.Service;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Entity.Country;

namespace ApplicationLibrary.Validation
{
    public class CountryValidation : AbstractValidator<CountryDetail>
    {
        public CountryValidation()
        {
            RuleFor(c => c.Name).NotNull();
            RuleFor(c => c.Name).NotEmpty();
        }
        private bool CheckId(int? id)
        {
            return !id.HasValue || id.Value > 0;
        }
    }



}
