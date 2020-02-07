using MarvelCharacters.Shared.Request;

namespace MarvelCharacters.Domain.Queries.Outputs
{
    public class RequestResult<T> : IRequestResult<T>
    {
        public RequestResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
