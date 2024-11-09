using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CleanArchitecture.Template.Api.ModelBinders
{
    public class EnumModelBinder<T> : IModelBinder where T : struct, Enum
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).FirstValue;

            // Guard clause for null or empty value
            if (string.IsNullOrEmpty(value))
                return SetModelErrorAndFail(bindingContext, $"The value for '{bindingContext.ModelName}' cannot be null or empty.");

            // Guard clause for successful parsing
            if (Enum.TryParse<T>(value, true, out var parsedEnum))
            {
                bindingContext.Result = ModelBindingResult.Success(parsedEnum);
                return Task.CompletedTask;
            }

            var allowedValues = string.Join(", ", Enum.GetNames(typeof(T)));
            return SetModelErrorAndFail(bindingContext, $"The value '{value}' is not valid for {typeof(T).Name}. Allowed values are: {allowedValues}.");
        }

        private Task SetModelErrorAndFail(ModelBindingContext context, string errorMessage)
        {
            context.ModelState.TryAddModelError(context.ModelName, errorMessage);
            context.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }
    }
}
