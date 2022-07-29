namespace MyRTEX.BusinessLayer.Validation
{
    public class OperationFailure : IOperationFailure
    {
        public string PropertyName { get; set; }

        public string Message { get; set; }

        public string Code { get; set; }
    }
}
