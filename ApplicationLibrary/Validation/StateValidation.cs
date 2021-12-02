using Entity.State;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLibrary.Validation
{ 
    public class StateValidation : AbstractValidator<StateDetail>
    {
        public StateValidation()
        {
            RuleFor(c => c.StateName).NotNull();
            RuleFor(c => c.StateName).NotEmpty();
        }
        private bool CheckId(int? id)
        {
            return !id.HasValue || id.Value > 0;
        }
    }
}
