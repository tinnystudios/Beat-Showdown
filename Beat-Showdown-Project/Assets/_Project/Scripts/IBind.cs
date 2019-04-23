/// <summary>
/// Implement IBind<T> to declare a need for a class
/// </summary>
public interface IBind<T> where T : class
{
    void Bind(T dependency);
}