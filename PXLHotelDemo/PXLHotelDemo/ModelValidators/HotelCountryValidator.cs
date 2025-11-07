
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PXLHotelDemo.ModelValidators
{
    public class HotelCountryValidator : Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            List<ModelValidationResult> list = new List<ModelValidationResult>();
            if (context.Model is null || context.Model.ToString() != "BE" || context.Model.ToString() != "NL")
            {
                list.Add(new ModelValidationResult( "", "Can only be BE/NL"));
            }
            return list;
        }
    }
}
