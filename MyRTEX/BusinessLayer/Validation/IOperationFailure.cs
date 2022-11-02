namespace MyRTEX.BusinessLayer.Validation
{
    public interface IOperationFailure
    {
        string PropertyName { get; }   
        string Message { get; }
        string Code { get; }

    }
}
