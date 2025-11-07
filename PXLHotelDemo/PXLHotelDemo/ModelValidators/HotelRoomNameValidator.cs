using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PXLHotelDemo.ModelValidators
{
    public class HotelRoomNameValidator : Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            List<ModelValidationResult> result = new List<ModelValidationResult>();

            if (context.Model.ToString() != null)
            {
                string input = context.Model.ToString();

                foreach (char c in input)
                {
                    if (char.IsDigit(c))
                    {
                        result.Add(new("", "No digits allowed in the room name.")); break;
                    }
                }
            }
            else
            {
                result.Add(new("", "Room name is required"));
            }

            return result;
        }
    }
}
