namespace CleanArchitecture.Template.SharedKernel.Exceptions
{
    public class FilterValueConversionException : ArgumentException
    {
        public FilterValueConversionException(object value, Type targetType, Exception innerException)
            : base($"Failed to convert value '{value}' to target type '{targetType}'.", innerException)
        {
        }
    }
}
