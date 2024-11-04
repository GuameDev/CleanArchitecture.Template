namespace CleanArchitecture.Template.SharedKernel.Requests
{
    public class DynamicFilterRequest<TPropertyNameEnum> where TPropertyNameEnum : Enum
    {
        public required TPropertyNameEnum Property { get; set; }
        public required FilterOperator Operator { get; set; }
        public required string Value { get; set; }

    }
}
