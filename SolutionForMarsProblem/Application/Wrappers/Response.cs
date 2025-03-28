namespace Application.Wrappers;

public class Response<T> : Response, IResponse<T>
{
    public T Value { get; set; } = default!;

    public Response(T value,bool status, string message = "") : base(status, message)
    {
        Value = value;
    }

    public Response(bool status, string message = "") : base(status, message)
    {
    }


}

public class Response : IResponse
{
    public string Message { get; set; }
    public bool Status { get; set; }

    public Response(bool status, string message = "")
    {
        Status = status;
        Message = message;
    }

}


