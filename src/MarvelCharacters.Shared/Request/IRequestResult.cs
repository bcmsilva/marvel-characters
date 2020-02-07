namespace MarvelCharacters.Shared.Request
{
    public interface IRequestResult<T>
    {
        bool Success { get; set; }
        string Message { get; set; }
        T Data { get; set; }
    }
}
