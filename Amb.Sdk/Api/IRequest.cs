namespace Amb.Sdk.Api
{
    public interface IRequest
    {
        T GetRequest<T>(string path);

        T PostRequest<T>(string path, string body);
    }
}