namespace CleanArchitecture.Template.SharedKernel.Requests
{
    public class DynamicFilterRequest<TPropertyNameEnum> where TPropertyNameEnum : Enum
    {
        public required TPropertyNameEnum PropertyName { get; set; }
        public required FilterOperator Operator { get; set; }
        public required object Value { get; set; }

    }
}
