using FluentValidation;
using SampleProject.Application.Model;

namespace ApplicationLibrary.Validation
{
    public class CountryValidation : AbstractValidator<CountryMasterModel>
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
