
namespace Restaurante.Shared.Wrapper;

public class ResultList<T>: Result
{
    public IEnumerable<T> Items { get; set; } = default!;

    public static ResultList<T> Fail()
    {
        return new ResultList<T>(){
            Succeeded = false, Message = new List<string>(){"❌"}
        };
    }
    public static ResultList<T> Fail(string message)
    {
        return new ResultList<T>(){
            Succeeded = false, Message = new List<string>(){message}
        };
    }
    public static ResultList<T> Fail(List<string> messages)
    {
        return new ResultList<T>(){
            Succeeded = false, Message = messages
        };
    }

    public static ResultList<T> Success(IEnumerable<T> items, string message)
    {
        return new ResultList<T>(){
            Succeeded = true, Message = new List<string>(){"❌"},
            Items = items
        };
    }

    public static ResultList<T> Success(IEnumerable<T> items, List<string> message)
    {
        return new ResultList<T>(){
            Succeeded = true,
            Message = message,
            Items = items
            };
        }
}
