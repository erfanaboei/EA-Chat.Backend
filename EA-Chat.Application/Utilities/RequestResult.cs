using Common.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EA_Chat.Application.Utilities;

public class RequestResult
{
    public bool IsSuccess { get; set; }
    public RequestResultStatusCode StatusCode { get; set; }
    public string Message { get; set; }

    public RequestResult(bool isSuccess, RequestResultStatusCode statusCode, string message = null)
    {
        IsSuccess = isSuccess;
        StatusCode = statusCode;
        Message = message ?? statusCode.ToDisplay();
    }

    #region Implicit Operator

    public static implicit operator RequestResult(OkResult result)
    {
        return new RequestResult(true, RequestResultStatusCode.Success);
    }

    public static implicit operator RequestResult(BadRequestResult result)
    {
        return new RequestResult(false, RequestResultStatusCode.BadRequest);
    }

    public static implicit operator RequestResult(BadRequestObjectResult result)
    {
        var message = result.Value!.ToString();
        if (result.Value is SerializableError errors)
        {
            var errorMessages = errors.SelectMany(r => (string[])r.Value).Distinct();
            message = string.Join(" | ", errorMessages);
        }

        return new RequestResult(false, RequestResultStatusCode.BadRequest, message);
    }

    public static implicit operator RequestResult(ContentResult result)
    {
        return new RequestResult(true, RequestResultStatusCode.Success, result.Content);
    }

    public static implicit operator RequestResult(NotFoundResult result)
    {
        return new RequestResult(false, RequestResultStatusCode.NotFound);  
    }

    #endregion
}

public class RequestResult<TData> : RequestResult where TData : class
{
    public TData Data { get; set; }
    
    public RequestResult(bool isSuccess, RequestResultStatusCode statusCode, TData? data, string message = null) :
        base(isSuccess, statusCode, message)
    {
        Data = data;
    }

    #region Implicit Operators

    public static implicit operator RequestResult<TData>(TData data)
    {
        return new RequestResult<TData>(true, RequestResultStatusCode.Success, data);
    }

    public static implicit operator RequestResult<TData>(OkResult result)
    {
        return new RequestResult<TData>(true, RequestResultStatusCode.Success, null);
    }
    
    public static implicit operator RequestResult<TData>(OkObjectResult result)
    {
        return new RequestResult<TData>(true, RequestResultStatusCode.Success, (TData)result.Value);
    }
    
    public static implicit operator RequestResult<TData>(BadRequestResult result)
    {
        return new RequestResult<TData>(false, RequestResultStatusCode.BadRequest, null);
    }

    public static implicit operator RequestResult<TData>(BadRequestObjectResult result)
    {
        var message = result.Value!.ToString();
        if (result.Value is SerializableError errors)
        {
            var errorMessages = errors.SelectMany(r => (string[])r.Value).Distinct();
            message = string.Join(" | ", errorMessages);
        }

        return new RequestResult<TData>(false, RequestResultStatusCode.BadRequest,null, message);
    }

    public static implicit operator RequestResult<TData>(ContentResult result)
    {
        return new RequestResult<TData>(true, RequestResultStatusCode.Success, null, result.Content);
    }

    public static implicit operator RequestResult<TData>(NotFoundResult result)
    {
        return new RequestResult<TData>(false, RequestResultStatusCode.NotFound, null);  
    }

    public static implicit operator RequestResult<TData>(NotFoundObjectResult result)
    {
        return new RequestResult<TData>(false, RequestResultStatusCode.NotFound, (TData)result.Value);
    }
    
    #endregion
}