namespace Application.Wrappers;

public class Response<T>
{
    public T Value { get; set; }
    public string Message { get; set; }
    public bool Status { get; set; }

    public Response(T value, bool status, string message = "")
    {
        Status = status;
        Value = value;
        Message = message;
    }

}

public class Response
{
    public string Message { get; set; }
    public bool Status { get; set; }

    public Response(bool status, string message = "")
    {
        Status = status;
        Message = message;
    }

}


