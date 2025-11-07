using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PXLHotelDemo.ModelValidators
{
    public class HotelRoomNumberValidator : Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            List<ModelValidationResult> result = new List<ModelValidationResult>();

            if (context.Model is not null) 
            {
                if (int.TryParse(context.Model.ToString(), out int number))
                {
                    if (number < 10 || number > 100)
                    {
                        result.Add(new("", "The room number should be between 10 and 100."));
                    }
                }
            }

            return result;
        }
    }
}
