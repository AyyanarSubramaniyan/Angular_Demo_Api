using ApplicationLibrary.Model;
using FluentValidation;
using SampleProject.Application.Model;

namespace ApplicationLibrary.Validation
{
    public class StateValidation : AbstractValidator<StateMasterModel>
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
