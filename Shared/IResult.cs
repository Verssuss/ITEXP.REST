namespace Shared
{
    public interface IResult
    {
        List<string> Messages { get; set; }
        bool Succeeded { get; set; }
        List<string> Warnings { get; set; }
    }

    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }
}