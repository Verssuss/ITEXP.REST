namespace Shared
{
    public class Result : IResult
    {
        public Result()
        {
        }

        public List<string> Messages { get; set; } = new List<string>();
        public bool Succeeded { get; set; }
        public List<string> Warnings { get; set; } = new List<string>();

        public static IResult Fail()
        {
            return new Result { Succeeded = false };
        }

        public static IResult Fail(string message)
        {
            return new Result { Succeeded = false, Messages = new List<string> { message } };
        }

        public static IResult Fail(List<string> messages)
        {
            return new Result { Succeeded = false, Messages = messages };
        }

        public static Task<IResult> FailAsync()
        {
            return Task.FromResult(Fail());
        }

        public static Task<IResult> FailAsync(string message)
        {
            return Task.FromResult(Fail(message));
        }

        public static Task<IResult> FailAsync(List<string> messages)
        {
            return Task.FromResult(Fail(messages));
        }

        public static IResult Success()
        {
            return new Result { Succeeded = true };
        }

        public static IResult Success(string message)
        {
            return new Result { Succeeded = true, Messages = new List<string> { message } };
        }

        public static IResult Success(string message, List<string> warnings)
        {
            return new Result { Succeeded = true, Messages = new List<string> { message }, Warnings = warnings };
        }

        public static IResult Success(List<string> messages, List<string> warnings)
        {
            return new Result { Succeeded = true, Messages = messages, Warnings = warnings };
        }

        public static Task<IResult> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public static Task<IResult> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }

        public static Task<IResult> SuccessAsync(string message, List<string> warnings)
        {
            return Task.FromResult(Success(message, warnings));
        }

        public static Task<IResult> SuccessAsync(List<string> messages, List<string> warnings)
        {
            return Task.FromResult(Success(messages, warnings));
        }
    }

    public class Result<T> : Result, IResult<T>
    {
        public Result()
        {
        }

        public T Data { get; set; }

        public new static Result<T> Fail()
        {
            return new Result<T> { Succeeded = false };
        }

        public new static Result<T> Fail(string message)
        {
            return new Result<T> { Succeeded = false, Messages = new List<string> { message } };
        }

        public new static Result<T> Fail(List<string> messages)
        {
            return new Result<T> { Succeeded = false, Messages = messages };
        }

        public new static Task<Result<T>> FailAsync()
        {
            return Task.FromResult(Fail());
        }

        public new static Task<Result<T>> FailAsync(string message)
        {
            return Task.FromResult(Fail(message));
        }

        public new static Task<Result<T>> FailAsync(List<string> messages)
        {
            return Task.FromResult(Fail(messages));
        }

        public new static Result<T> Success()
        {
            return new Result<T> { Succeeded = true };
        }

        public new static Result<T> Success(string message)
        {
            return new Result<T> { Succeeded = true, Messages = new List<string> { message } };
        }

        public static Result<T> Success(T data)
        {
            return new Result<T> { Succeeded = true, Data = data };
        }

        public static Result<T> Success(T data, string message)
        {
            return new Result<T> { Succeeded = true, Data = data, Messages = new List<string> { message } };
        }

        public static Result<T> Success(T data, List<string> messages)
        {
            return new Result<T> { Succeeded = true, Data = data, Messages = messages };
        }

        public new static Result<T> Success(string message, List<string> warnings)
        {
            return new Result<T> { Succeeded = true, Messages = new List<string> { message }, Warnings = warnings };
        }

        public static Result<T> Success(T data, string message, List<string> warnings)
        {
            return new Result<T> { Data = data, Succeeded = true, Messages = new List<string> { message }, Warnings = warnings };
        }

        public new static Result<T> Success(List<string> messages, List<string> warnings)
        {
            return new Result<T> { Succeeded = true, Messages = messages, Warnings = warnings };
        }

        public static Result<T> Success(T data, List<string> messages, List<string> warnings)
        {
            return new Result<T> { Data = data, Succeeded = true, Messages = messages, Warnings = warnings };
        }

        public new static Task<Result<T>> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public new static Task<Result<T>> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }

        public static async Task<Result<T>> SuccessAsync(T data)
        {
            return await Task.FromResult(Success(data));
        }

        public static Task<Result<T>> SuccessAsync(T data, string message)
        {
            return Task.FromResult(Success(data, message));
        }

        public new static Task<Result<T>> SuccessAsync(string message, List<string> warnings)
        {
            return Task.FromResult(Success(message, warnings));
        }

        public static Task<Result<T>> SuccessAsync(T data, string message, List<string> warnings)
        {
            return Task.FromResult(Success(data, message, warnings));
        }

        public new static Task<Result<T>> SuccessAsync(List<string> messages, List<string> warnings)
        {
            return Task.FromResult(Success(messages, warnings));
        }

        public static Task<Result<T>> SuccessAsync(T data, List<string> messages, List<string> warnings)
        {
            return Task.FromResult(Success(data, messages, warnings));
        }
    }
}