public interface IBind<T> where T : class
{
    void Bind(T dependency);
}