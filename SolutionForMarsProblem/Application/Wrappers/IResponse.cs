namespace Application.Wrappers;

public interface IResponse
{
    public string Message { get; set; }
    public bool Status { get; set; }
}

public interface IResponse<T> : IResponse
{
    public T Value { get; }
}
